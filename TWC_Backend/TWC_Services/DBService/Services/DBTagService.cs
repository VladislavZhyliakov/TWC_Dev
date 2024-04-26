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
                throw new Exception($"Exception: {ex}");
            }
        }
        public async Task<bool> RemoveTagFromProjectAsync(Tag tag, Project project)
        {
            try
            {
                var delTag = await _context.ProjectTags.SingleOrDefaultAsync(x => x.ProjectId == project.Id && x.TagId == tag.Id);

                if (delTag == null)
                {
                    return false;
                }

                _context.ProjectTags.Remove(delTag);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex}");
            }
        }

        public async Task<UserTag> AddTagToUserAsync(Tag tag, User user)
        {
            try
            {
                UserTag userTag = new UserTag()
                {
                    TagId = tag.Id,
                    UserId = user.Id,
                    Tag = tag,
                };

                user.Tags.Add(userTag);

                await _context.SaveChangesAsync();
                return userTag;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex}");
            }
        }
        public async Task<bool> RemoveTagFromUserAsync(Tag tag, User user)
        {
            try
            {
                var delTag = await _context.UserTags.SingleOrDefaultAsync(x => x.UserId == user.Id && x.TagId == tag.Id);

                if (delTag == null)
                {
                    return false;
                }

                _context.UserTags.Remove(delTag);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex}");
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
                throw new Exception($"Exception: {ex}");
            }
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(id);
                if (tag == null)
                {
                    return false;
                }

                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex}");
            }
        }

        public async Task<Tag> EditTagAsync(Tag newTag)
        {
            try
            {
                var editedTag = await _context.Tags.FindAsync(newTag.Id);
                if (editedTag == null)
                {
                    return null;
                }

                editedTag.Name = newTag.Name;
                await _context.SaveChangesAsync();

                return editedTag;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex}");
            }
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(id);
                if (tag == null)
                {
                    return null;
                }

                return tag;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex}");
            }
        }

        public async Task<Tag> GetTagByNameAsync(string name)
        {
            try
            {
                var tag = await _context.Tags.SingleOrDefaultAsync(t => t.Name == name);
                if(tag == null)
                {
                    return null;
                }
                return tag;
            }
            catch(Exception ex) 
            {
                throw new Exception($"Exception: {ex}");
            }
        }

        
    }
}
