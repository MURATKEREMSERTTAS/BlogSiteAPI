using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public async Task<List<Tag>> GetTags() =>
            await tagService.GetTags();

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(string id)
        {
            var tag = await tagService.GetTag(id);

            if (tag == null) return NotFound();
            else return tag;
        }

        [HttpPost]
        public async Task<IActionResult> PostTag(Tag NewTag)
        {
            await tagService.CreateTag(NewTag);
            return AcceptedAtAction(nameof(GetTags), new { id = NewTag.Id }, NewTag);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(string id, Tag UpdateTag)
        {
            var tag = await tagService.GetTag(id);
            if(tag == null) return NotFound();
            else
            {
                UpdateTag.Id = tag.Id;
                await tagService.UpdataTag(id, UpdateTag);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(string id)
        {
            var tag = await tagService.GetTag(id);
            if(tag is null) return NotFound();
            else
            {
                await tagService.DeleteTag(id);
                return NoContent();
            }
        }
    }
}
