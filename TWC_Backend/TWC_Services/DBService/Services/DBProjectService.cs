using Microsoft.EntityFrameworkCore;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;

namespace TWC_Services.DBService.Services
{
    public class DBProjectService : IDBProjectService
    {
        private DataContext _context;

        public DBProjectService(DataContext context) {
            _context = context; 
        }
        public async Task<Project> CreateProjectAsync(ProjectCreationDTO project)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> DeleteProjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> EditProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByNameAsync(string name)
        {
            try
            {
                Project project = await _context.Projects.SingleOrDefaultAsync(x => x.Name.Equals(name));

                return project;

            }
            catch (Exception ex)
            {
                throw new Exception($"cant found {typeof(Project).Name} by name. Messege error: " + ex.Message);
            }
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            try
            {
                Project project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);

                return project;

            }
            catch (Exception ex)
            {
                throw new Exception($"cant found {typeof(Project).Name} by id. Messege error: " + ex.Message);
            }
        }
        private async Task<Project> AddMemberToProjectAsync(User user, Project project, bool isOwner)
        {
            ProjectMember existingMember = await _context.ProjectMembers
                .FirstOrDefaultAsync(pm => pm.ProjectId == project.Id && pm.UserId == user.Id);

            if (existingMember != null)
            {
                return project;
            }

            ProjectMember newProjectMember = new ProjectMember
            {
                ProjectId = project.Id,
                UserId = user.Id,
                IsOwner = isOwner
            };

            await _context.ProjectMembers.AddAsync(newProjectMember);
            await _context.SaveChangesAsync();

            await _context.Entry(project).Collection(p => p.Members).LoadAsync();

            return project;
        }

        public async Task<Project> AddMemberToProjectAsync(User user, Project project)
        {
            return await AddMemberToProjectAsync(user, project, isOwner: false);
        }

        public async Task<Project> RemoveMemberFromProjectAsync(User user, Project project)
        {
            ProjectMember memberToRemove = await _context.ProjectMembers
                .FirstOrDefaultAsync(pm => pm.ProjectId == project.Id && pm.UserId == user.Id);

            if(memberToRemove == null)
            {
                return project;
            }
            if(memberToRemove.IsOwner)
            {
                throw new Exception("You can not remove owner User from Project members");
            }

            _context.ProjectMembers.Remove(memberToRemove);
            await _context.SaveChangesAsync();

            await _context.Entry(project).Collection(p => p.Members).LoadAsync();

            return project;
        }
    }
}
