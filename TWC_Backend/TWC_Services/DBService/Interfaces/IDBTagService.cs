using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService.Interfaces
{
    public interface IDBTagService
    {
        public Task<List<Tag>> GetAllTagsAsync();
        public Task<Tag> GetTagByIdAsync(int id);
        public Task<Tag> GetTagByNameAsync(string name);
        public Task<Tag> CreateTagAsync(string tag);
<<<<<<< HEAD
        public Task<Tag> EditTagAsync(Tag newTag);
        public Task<bool> DeleteTagAsync(int id);
        public Task<ProjectTag> AddTagToProjectAsync(Tag tag, Project project);
        public Task<bool> RemoveTagFromProjectAsync(Tag tag, Project project);
=======
        public Task<Tag> DeleteTagAsync(int id);
        public Task<ProjectTag> AddTagToProjectAsync(Tag tag, Project project);
        public Task<ProjectTag> RemoveTagFromProjectAsync(Tag tag, Project project);
>>>>>>> 464a754bea53a2637834bb169285a83fc3a68536
    }
}
