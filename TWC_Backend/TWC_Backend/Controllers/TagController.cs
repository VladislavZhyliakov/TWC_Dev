using Microsoft.AspNetCore.Mvc;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;
using TWC_Services.DBService.Services;

namespace TWC_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private IDBTagService _dbTagService;
        public TagController(IDBTagService dBTagService)
        {
            _dbTagService = dBTagService;
        }

        [HttpPost]
        [Route("AddTag")]
        public async Task<ActionResult<Tag>> AddTag(string tagName)
        {

            Tag newTag = await _dbTagService.CreateTagAsync(tagName);

            return Ok(newTag);
        }
    }
}
