using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.HashService;
using TWC_Services.DBService.Interfaces;

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
        private readonly ILogger<UserController> _logger;

        public UserController(IDBUserService dBUserService, IDBPasswordSaltService dBPasswordSaltService, IMapper<User, UserRegistrationDTO> mapper, IHashService hashService, ILogger<UserController> logger) 
        {
            _dBUserService = dBUserService;
            _dBPasswordSaltService = dBPasswordSaltService;
            _registrationMapper = mapper;
            _hashService = hashService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            try
            {
                _logger.LogInformation("\nGetAllUsersAsync()\nTrying to return all users.\n");
                return Ok(await _dBUserService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"\nGetAllUsersAsync()\nError during returning all users. Exception message:\n{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/User/{id}")]
        public async Task<ActionResult<List<User>>> GetUserByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("\nGetUserByIdAsync()\nTrying to return user by id.\n");
                return Ok(await _dBUserService.GetUserByIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"\nGetUserByIdAsync()\nError during returning user by id. Exception message:\n{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/User/Authentication")]
        public async Task<ActionResult<User>> AuthenticationUserAsync(UserAuthenticationDTO userAuthenticationDTO)
        {
            try
            {
                _logger.LogInformation("\nAuthenticationUserAsync()\nTrying to authenticate the user.\n");

                if (!ModelState.IsValid)
                {
                    _logger.LogError($"\nAuthenticationUserAsync()\nError during user authentication. Exception message:\nInvalid data. Please check the data. Email must be in the correct format and password must be longer than 8 characters!\n");
                    throw new Exception("Invalid data. Please check the data. Email must be in the correct format and password must be longer than 8 characters!");
                }

                var user = await _dBUserService.GetUserByEmailAsync(userAuthenticationDTO.Email);

                if (user == null)
                {
                    _logger.LogError($"\nAuthenticationUserAsync()\nError during user authentication. Exception message:\nUser with this email does not exist!\n");
                    throw new Exception("User with this email does not exist!");
                }

                var salt = await _dBPasswordSaltService.GetSaltByUserIdAsync(user.Id);

                if (!_hashService.PasswordVerification(userAuthenticationDTO.Password, user.Password, salt.Salt))
                {
                    _logger.LogError($"\nAuthenticationUserAsync()\nError during user authentication. Exception message:\nPassword is wrong!\n");
                    throw new Exception("Password is wrong!");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"\nAuthenticationUserAsync()\nError during user authentication. Exception message:\n{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/User/Registration")]
        public async Task<ActionResult<User>> RegistrationUserAsync(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                _logger.LogInformation("\nRegistrationUserAsync()\nTrying to register the user.\n");

                if (!ModelState.IsValid)
                {
                    _logger.LogError($"\nRegistrationUserAsync()\nError during user registration. Exception message:\nInvalid data. Please check the data. Username must be longer than 3 characters, email must be in the correct format and password must be longer than 8 characters!\n");
                    throw new Exception("Invalid data. Please check the data. Username must be longer than 3 characters, email must be in the correct format and password must be longer than 8 characters!");
                }

                if (await _dBUserService.GetUserByEmailAsync(userRegistrationDTO.Email) != null)
                { 
                    _logger.LogError($"\nRegistrationUserAsync()\nError during user registration. Exception message:\nUser with this email already exists!\n");
                    throw new Exception("User with this email already exists!");
                }

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
                _logger.LogError($"\nRegistrationUserAsync()\nError during user registration. Exception message:\n{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("\nDeleteUserByIdAsync()\nTrying to delete the user by id.\n");

                await _dBUserService.DeleteUserAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"\nDeleteUserByIdAsync()\nError during user deletion. Exception message:\n{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }
    }
}
