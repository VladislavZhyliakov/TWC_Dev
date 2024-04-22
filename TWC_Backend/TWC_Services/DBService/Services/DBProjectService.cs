using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;

namespace TWC_Services.DBService.Services
{
    public class DBProjectService : IDBProjectService
    {
        private DataContext _context;

        public DBProjectService(DataContext context) { _context = context; }
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
    }
}
