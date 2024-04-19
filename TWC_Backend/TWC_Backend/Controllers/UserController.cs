using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.HashService;
using TWC_Services.DBService.Interfaces;
using TWC_Services.DBService.Services;

namespace TWC_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IDBUserService _dBUserService;
        private IDBPasswordSaltService _dBPasswordSaltService;
        private IMapper<User, UserRegistrationDTO> _registrationMapper;
        private IHashService _hashService;

        public UserController(IDBUserService dBUserService, IDBPasswordSaltService dBPasswordSaltService, IMapper<User, UserRegistrationDTO> mapper, IHashService hashService) 
        {
            _dBUserService = dBUserService;
            _dBPasswordSaltService = dBPasswordSaltService;
            _registrationMapper = mapper;
            _hashService = hashService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            try
            {
                return Ok(await _dBUserService.GetAllUsersAsync());
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
                return Ok(await _dBUserService.GetUserByIdAsync(id));
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

                var user = await _dBUserService.GetUserByEmailAsync(userAuthenticationDTO.Email);

                if (user == null)
                    throw new Exception("User with this email does not exist!");

                var salt = await _dBPasswordSaltService.GetSaltByUserIdAsync(user.Id);

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

                if (await _dBUserService.GetUserByEmailAsync(userRegistrationDTO.Email) != null)
                    throw new Exception("User with this email already exists!");

                byte[] salt;
                userRegistrationDTO.Password = _hashService.HashPassword(userRegistrationDTO.Password, out salt);

                User user = await _dBUserService.AddUserAsync(_registrationMapper.Unmap(userRegistrationDTO));

                PasswordSalt passwordSalt = new PasswordSalt {
                    Salt = salt,
                    UserId = user.Id
                };

                await _dBPasswordSaltService.AddSaltAsync(passwordSalt);

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
                await _dBUserService.DeleteUserAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
