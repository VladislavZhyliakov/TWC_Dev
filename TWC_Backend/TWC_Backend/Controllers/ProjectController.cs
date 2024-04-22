using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;

namespace TWC_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private IDBProjectService _dbProjectService;
        private IDBUserService _dbUserService;
        private IMapper<Project, ProjectCreationDTO> _projectMapper;

        public ProjectController(
            IDBProjectService dbProjectService,
            IDBUserService dbUserService,
            IMapper<Project, ProjectCreationDTO> projectMapper)
        {
            _dbProjectService = dbProjectService;
            _projectMapper = projectMapper;
            _dbUserService = dbUserService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<Project>>> GetAllProjectsAsync()
        {
            try
            {
                return Ok(await _dbProjectService.GetAllProjectsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Project>> GetProjectByIdAsync(int id)
        {
            return Ok(_dbProjectService.GetProjectByIdAsync(id));
        }
        [HttpPut]
        [Route("Member")]
        public async Task<ActionResult<Project>> AddUserToProjectAsync(ProjectMemberDTO projectMemberDTO)
        {
            return await ModifyProjectMembershipAsync(projectMemberDTO, add: true);
        }

        [HttpDelete]
        [Route("Member")]
        public async Task<ActionResult<Project>> RemoveUserFromProjectAsync(ProjectMemberDTO projectMemberDTO)
        {
            return await ModifyProjectMembershipAsync(projectMemberDTO, add: false);
        }

        private async Task<ActionResult<Project>> ModifyProjectMembershipAsync(ProjectMemberDTO projectMemberDTO, bool add)
        {
            try
            {
                Project project = await _dbProjectService.GetProjectByIdAsync(projectMemberDTO.ProjectId);
                User user = await _dbUserService.GetUserByIdAsync(projectMemberDTO.UserId);

                Project editedProject;
                if (add)
                    editedProject = await _dbProjectService.AddMemberToProjectAsync(user, project);
                else
                    editedProject = await _dbProjectService.RemoveMemberFromProjectAsync(user, project);

                return Ok(editedProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
