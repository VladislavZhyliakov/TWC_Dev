using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService;

namespace TWC_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IDBService _dBService;
        private IMapper<User, UserRegistrationDTO> _registrationMapper;

        public UserController(IDBService dBService, IMapper<User, UserRegistrationDTO> mapper) 
        {
            _dBService = dBService;
            _registrationMapper = mapper;
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
        public async Task<ActionResult<User>> RegistrationUser(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid data. Please check the data. Username must be longer than 3 characters, email must be in the correct format and password must be longer than 8 characters!");

                if (await _dBService.GetUserByEmail(userRegistrationDTO.Email) != null)
                    throw new Exception("User with this email already exists!");

                User user = await _dBService.AddUser(_registrationMapper.Unmap(userRegistrationDTO));

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
