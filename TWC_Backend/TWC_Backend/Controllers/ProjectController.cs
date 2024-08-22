using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_Services.Mapper;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TWC_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProjectController : Controller
    {
        private IDBProjectService _dbProjectService;
        private IDBUserService _dbUserService;
        private IMapper<Project, ProjectCreationDTO> _projectMapper;
        private IDBTagService _dbTagService;
        private readonly ILogger<ProjectController> _projectControllerLogger;

        public ProjectController(
            IDBProjectService dbProjectService,
            IDBUserService dbUserService,
            IMapper<Project, ProjectCreationDTO> projectMapper,
            IDBTagService dBTagService,
            ILogger<ProjectController> projectControllerLogger
            )
        {
            _dbProjectService = dbProjectService;
            _projectMapper = projectMapper;
            _dbUserService = dbUserService;
            _dbTagService = dBTagService;
            _projectControllerLogger = projectControllerLogger;
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<ActionResult<List<Project>>> GetAllProjectsAsync()
        {
            try
            {
                _projectControllerLogger.LogInformation("\nGetAllProjectsAsync()\nTrying to return all projects.\n");
                return Ok(await _dbProjectService.GetAllProjectsAsync());
            }
            catch (Exception ex)
            {
                _projectControllerLogger.LogError($"\nGetAllProjectsAsync()\nError during returning all projects. Exception message:\n{ex.Message}\n"); ;
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProject")]
        public async Task<ActionResult<Project>> AddProject(ProjectCreationDTO project)
        {
            try
            {
                _projectControllerLogger.LogInformation("\nAddProject()\nTrying to create a new project.\n");

                Project newProject = await _dbProjectService.CreateProjectAsync(project);

                if (newProject == null)
                {
                    _projectControllerLogger.LogError("\nAddProject()\nError during creation of a new project. Exception message:\nProject or projects' fields not found\n"); ;
                    return NotFound("Project or projects' fields not found");
                }

                return Ok(newProject);
            }
            catch (Exception ex)
            {
                _projectControllerLogger.LogError($"\nAddProject()\nError during creation of a new project. Exception message:\n{ex.Message}\n"); ;
                return BadRequest($"Can't create the project\n{ex.Message}");
            }
        }

        [HttpPut]
        [Route("EditProject")]
        public async Task<ActionResult<Project>> EditProject(ProjectEditDTO editProject)
        {
            try
            {
                _projectControllerLogger.LogInformation("\nEditProject()\nTrying to edit the project.\n");


                Project edited = await _dbProjectService.EditProjectAsync(editProject);

                if (edited == null)
                {
                    _projectControllerLogger.LogError($"\nEditProject()\nError during project editing. Exception message:\nProject not found\n");
                    return NotFound("Project not found");
                }

                return Ok(await _dbProjectService.GetAllProjectsAsync());
            }
            catch (Exception ex) 
            {
                _projectControllerLogger.LogError($"\nEditProject()\nError during project editing. Exception message:\n{ex.Message}\n"); ;
                return BadRequest($"Can't edit the project.\n{ex.Message}");            
            }
        }

        [HttpDelete]
        [Route("DeleteProject")]
        public async Task<ActionResult<Project>> DeleteProject(int projectId)
        {
            try
            {
                _projectControllerLogger.LogInformation("\nDeleteProject()\nTrying to delete the project.\n");

                await _dbProjectService.DeleteProjectAsync(projectId);

                return NoContent();
            }
            catch (Exception ex)
            {
                _projectControllerLogger.LogError($"\nDeleteProject()\nError during project deletion. Exception message:\n{ex.Message}\n");
                return BadRequest($"Can't delete the project.\n{ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Project>> GetProjectByIdAsync(int id)
        {
            try
            {
                _projectControllerLogger.LogInformation("\nGetProjectByIdAsync()\nTrying to get the project by id.\n");

                Project project = await _dbProjectService.GetProjectByIdAsync(id);

                if (project == null)
                {
                    return NotFound("Project not found");
                }

                return Ok(project);
            }catch (Exception ex)
            {
                _projectControllerLogger.LogError($"\nGetProjectByIdAsync()\nError during returning project. Exception message:\n{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AddMember")]
        public async Task<ActionResult<Project>> AddUserToProjectAsync(ProjectMemberDTO projectMemberDTO)
        {
            _projectControllerLogger.LogInformation("\nAddUserToProjectAsync()\nTrying to add user to the project.\n");
            return await ModifyProjectMembershipAsync(projectMemberDTO, add: true);
        }

        [HttpDelete]
        [Route("RemoveMember")]
        public async Task<ActionResult<Project>> RemoveUserFromProjectAsync(ProjectMemberDTO projectMemberDTO)
        {
            _projectControllerLogger.LogInformation("\nRemoveUserFromProjectAsync()\nTrying to remove user from the project.\n");
            return await ModifyProjectMembershipAsync(projectMemberDTO, add: false);
        }

        private async Task<ActionResult<Project>> ModifyProjectMembershipAsync(ProjectMemberDTO projectMemberDTO, bool add)
        {
            try
            {
                _projectControllerLogger.LogInformation("\nModifyProjectMembershipAsync()\nTrying to modify project membership.\n");

                Project project = await _dbProjectService.GetProjectByIdAsync(projectMemberDTO.ProjectId);
                User user = await _dbUserService.GetUserByIdAsync(projectMemberDTO.UserId);

                if(project == null)
                {
                    _projectControllerLogger.LogError($"\nModifyProjectMembershipAsync()\nError during modifying project membership. Exception message:\nThere is no Project with id:{projectMemberDTO.ProjectId}\n");
                    throw new InvalidOperationException($"There is no Project with id:{projectMemberDTO.ProjectId}");
                }
                if (user == null)
                {
                    _projectControllerLogger.LogError($"\nModifyProjectMembershipAsync()\nError during modifying project membership. Exception message:\nThere is no User with id:{projectMemberDTO.UserId}\n");
                    throw new InvalidOperationException($"There is no User with id:{projectMemberDTO.UserId}");
                }

                Project editedProject;
                if (add)
                {
                    editedProject = await _dbProjectService.AddMemberToProjectAsync(user, project);
                }
                else
                {
                    editedProject = await _dbProjectService.RemoveMemberFromProjectAsync(user, project);
                }

                return Ok(editedProject);
            }
            catch (InvalidOperationException ex)
            {
                _projectControllerLogger.LogError($"\nModifyProjectMembershipAsync()\nError during modifying project membership. Exception message:\n{ex.Message}\n");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _projectControllerLogger.LogError($"\nModifyProjectMembershipAsync()\nError during modifying project membership. Exception message:\n{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }
    }
}
