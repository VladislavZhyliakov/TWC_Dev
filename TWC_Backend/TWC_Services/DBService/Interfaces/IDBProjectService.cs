﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService.Interfaces
{
    public interface IDBProjectService
    {
        public Task<List<Project>> GetAllProjectsAsync();
        public Task<Project> GetProjectByIdAsync(int id);
        public Task<Project> GetProjectByNameAsync(string name);
        public Task<Project> CreateProjectAsync(ProjectCreationDTO project);
        public Task<Project> EditProjectAsync(Project project);
        public Task<Project> DeleteProjectAsync(int id);
    }
}
