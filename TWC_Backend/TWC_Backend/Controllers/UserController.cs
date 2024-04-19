using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService;
using TWC_Services.HashService;

namespace TWC_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IDBService _dBService;
        private IMapper<User, UserRegistrationDTO> _registrationMapper;
        private IHashService _hashService;

        public UserController(IDBService dBService, IMapper<User, UserRegistrationDTO> mapper, IHashService hashService) 
        {
            _dBService = dBService;
            _registrationMapper = mapper;
            _hashService = hashService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            try
            {
                return Ok(await _dBService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/User/{id}")]
        public async Task<ActionResult<List<User>>> GetUserByIdAsync(int id)
        {
            try
            {
                return Ok(await _dBService.GetUserByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/User/Authentication")]
        public async Task<ActionResult<User>> AuthenticationUserAsync(UserAuthenticationDTO userAuthenticationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid data. Please check the data. Email must be in the correct format and password must be longer than 8 characters!");

                var user = await _dBService.GetUserByEmailAsync(userAuthenticationDTO.Email);

                if (user == null)
                    throw new Exception("User with this email does not exist!");

                var salt = await _dBService.GetSaltByUserIdAsync(user.Id);

                if (!_hashService.PasswordVerification(userAuthenticationDTO.Password, user.Password, salt.Salt))
                {
                    throw new Exception("Password is wrong!");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/User/Registration")]
        public async Task<ActionResult<User>> RegistrationUserAsync(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid data. Please check the data. Username must be longer than 3 characters, email must be in the correct format and password must be longer than 8 characters!");

                if (await _dBService.GetUserByEmailAsync(userRegistrationDTO.Email) != null)
                    throw new Exception("User with this email already exists!");

                byte[] salt;
                userRegistrationDTO.Password = _hashService.HashPassword(userRegistrationDTO.Password, out salt);

                User user = await _dBService.AddUserAsync(_registrationMapper.Unmap(userRegistrationDTO));

                PasswordSalt passwordSalt = new PasswordSalt {
                    Salt = salt,
                    UserId = user.Id
                };

                await _dBService.AddSaltAsync(passwordSalt);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            try
            {
                await _dBService.DeleteUserAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
