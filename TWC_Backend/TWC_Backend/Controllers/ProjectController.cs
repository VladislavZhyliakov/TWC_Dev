using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.HashService;
using TWC_Services.DBService.Interfaces;
using TWC_Services.DBService.Services;

namespace TWC_Backend.Controllers
{
    public class ProjectController : Controller
    {
        private IDBProjectService _dBprojectService;
        private IMapper<Project, ProjectCreationDTO> _projectMapper;

        public ProjectController(IDBProjectService dBprojectService, IMapper<Project, ProjectCreationDTO> projectMapper)
        {
            _dBprojectService = dBprojectService;
            _projectMapper = projectMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjectsAsync()
        {
            try
            {
                return Ok(await _dBprojectService.GetAllProjectsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Project>> GetProjectByIdAsync(int id)
        {
            return Ok(_dBprojectService.GetProjectByIdAsync(id));
        }
    }
}
