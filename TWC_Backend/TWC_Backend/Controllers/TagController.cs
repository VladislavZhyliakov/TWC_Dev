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
        private readonly ILogger<TagController> _tagControllerLogger;

        public TagController(IDBTagService dBTagService, ILogger<TagController> tagControllerLogger)
        {
            _dbTagService = dBTagService;
            _tagControllerLogger = tagControllerLogger;
        }

        [HttpPost]
        [Route("AddTag")]
        public async Task<ActionResult<Tag>> AddTag(string tagName)
        {
            _tagControllerLogger.LogInformation("\nAddTag()\nTrying to create new project.\n");

            Tag newTag = await _dbTagService.CreateTagAsync(tagName);

            return Ok(newTag);
        }
        [HttpPut]
        [Route("EditTag")]
        public async Task<ActionResult<Tag>> EditTag(Tag newTag)
        {

            Tag editedTag = await _dbTagService.GetTagByIdAsync(newTag.Id);

            return Ok(editedTag);
        }

    }
}
