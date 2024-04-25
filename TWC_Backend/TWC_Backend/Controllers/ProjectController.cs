using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;
using TWC_DatabaseLayer;
using Microsoft.AspNetCore.Components.Forms;

namespace TWC_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private IDBProjectService _dbProjectService;
        private IDBUserService _dbUserService;
        private IMapper<Project, ProjectCreationDTO> _projectMapper;
        private IDBTagService _dbTagService;

        public ProjectController(
            IDBProjectService dbProjectService,
            IDBUserService dbUserService,
            IMapper<Project, ProjectCreationDTO> projectMapper,
            IDBTagService dBTagService
            )
        {
            _dbProjectService = dbProjectService;
            _projectMapper = projectMapper;
            _dbUserService = dbUserService;
            _dbTagService = dBTagService;
        }

        [HttpGet]
        [Route("GetAllProjects")]
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

        [HttpPost]
        [Route("AddProject")]
        public async Task<ActionResult<Project>> AddProject(ProjectCreationDTO project)
        {
            try
            {
                Project newProject = await _dbProjectService.CreateProjectAsync(project);

                if (newProject == null)
                {
                    return NotFound("Project or projects fields not found");
                }

                return Ok(newProject);
            }
            catch (Exception ex)
            {
                return BadRequest("Can't create the project");
            }
        }

        [HttpPut]
        [Route("EditProject")]
        public async Task<ActionResult<Project>> EditProject(ProjectEditDTO editProject)
        {
            try
            {
                Project edited = await _dbProjectService.EditProjectAsync(editProject);

                if (edited == null)
                {
                    return NotFound("Project not found");
                }

                return Ok(await _dbProjectService.GetAllProjectsAsync());
            }
            catch (Exception ex) 
            { 
                return BadRequest("Can't edit the project");            
            }
        }

        [HttpDelete]
        [Route("DeleteProject")]
        public async Task<ActionResult<Project>> DeleteProject(int projectId)
        {
            try
            {
                await _dbProjectService.DeleteProjectAsync(projectId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't delete the project");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Project>> GetProjectByIdAsync(int id)
        {
            try
            {
                Project project = await _dbProjectService.GetProjectByIdAsync(id);

                if (project == null)
                {
                    return NotFound("Project not found");
                }

                return Ok(project);
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("AddMember")]
        public async Task<ActionResult<Project>> AddUserToProjectAsync(ProjectMemberDTO projectMemberDTO)
        {
            return await ModifyProjectMembershipAsync(projectMemberDTO, add: true);
        }

        [HttpDelete]
        [Route("RemoveMember")]
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
