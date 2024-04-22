using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.Mapper
{
    public class ProjectCreationMapper : IMapper<Project, ProjectCreationDTO>
    {
        public ProjectCreationDTO Map(Project data)
        {
            //Дописати витягування тегів
            return new ProjectCreationDTO
            {
                Name = data.Name,
                MaxMembers = data.MaxMembers,
                Description = data.Description,
            };
        }

        public Project Unmap(ProjectCreationDTO data)
        {
            return new Project
            {
                Name = data.Name,
                MaxMembers = data.MaxMembers,
                Description = data.Description,              
            };
        }
    }
}
