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
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                return Ok(await _dBService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/User/{id}")]
        public async Task<ActionResult<List<User>>> GetUserById(int id)
        {
            try
            {
                return Ok(await _dBService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/User/Authentication")]
        public async Task<ActionResult<User>> AuthenticationUser(UserAuthenticationDTO userAuthenticationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid data. Please check the data. Email must be in the correct format and password must be longer than 8 characters!");

                var user = await _dBService.GetUserByEmail(userAuthenticationDTO.Email);

                if (user == null)
                    throw new Exception("User with this email does not exist!");

                var salt = await _dBService.GetSaltByUserId(user.Id);
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
        public async Task<ActionResult<User>> RegistrationUser(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid data. Please check the data. Username must be longer than 3 characters, email must be in the correct format and password must be longer than 8 characters!");

                if (await _dBService.GetUserByEmail(userRegistrationDTO.Email) != null)
                    throw new Exception("User with this email already exists!");

                byte[] salt;
                userRegistrationDTO.Password = _hashService.HashPassword(userRegistrationDTO.Password, out salt);

                User user = await _dBService.AddUser(_registrationMapper.Unmap(userRegistrationDTO));

                PasswordSalt passwordSalt = new PasswordSalt {
                    Salt = salt,
                    UserId = user.Id
                };

                await _dBService.AddSalt(passwordSalt);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            try
            {
                await _dBService.DeleteUser(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
