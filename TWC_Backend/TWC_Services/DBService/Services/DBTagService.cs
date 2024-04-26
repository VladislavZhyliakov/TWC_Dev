using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;

namespace TWC_Services.DBService.Services
{
    public class DBTagService : IDBTagService
    {
        private DataContext _context;

        public DBTagService(DataContext context)
        {
            _context = context;
        }
        public async Task<ProjectTag> AddTagToProjectAsync(Tag tag, Project project)
        {

            try
            {
                ProjectTag projectTag = new ProjectTag()
                {
                    TagId = tag.Id,
                    ProjectId = project.Id,
                    Tag = tag,
                };

                project.Tags.Add(projectTag);

                await _context.SaveChangesAsync();
                return projectTag;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Tag> CreateTagAsync(string tag)
        {
            try
            {
                Tag newTag = new Tag()
                {
                    Name = tag,
                };
                _context.Tags.Add(newTag);
                await _context.SaveChangesAsync();
                return newTag;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex} in DBTagService in function CreateTagAsync");
            }
        }

        public Task<Tag> DeleteTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public Task<Tag> GetTagByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> GetTagByNameAsync(string name)
        {
            try
            {            
                return await _context.Tags.SingleOrDefaultAsync(t => t.Name == name);  
            }
            catch(Exception ex) 
            {
                throw new Exception($"Can't find tag with name: {name}");
            }
        }

        public Task<ProjectTag> RemoveTagFromProjectAsync(Tag tag, Project project)
        {
            throw new NotImplementedException();
        }
    }
}
