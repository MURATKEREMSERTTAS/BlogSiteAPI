using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService contentService;
    
        public ContentController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpGet]
        public async Task<List<Content>> GetContents() =>
            await contentService.GetContents();

        [HttpGet("{id}")]
        public async Task<ActionResult<Content>> GetContent(string id)
        {
            var content = await contentService.GetContent(id);

            if (content == null) return NotFound();
            else return content;
        }

        [HttpPost]
        public async Task<IActionResult> PostContent(Content NewContent)
        {
            await contentService.CreateContent(NewContent);
            return CreatedAtAction(nameof(GetContents), new {id = NewContent.Id},NewContent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContent(string id, Content UpdateContent)
        {
            var content = await contentService.GetContent(id);

            if (content == null) return NotFound();
            else
            {
                UpdateContent.Id = content.Id;
                await contentService.UpdateContent(id, UpdateContent);
                return NoContent();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContent(string id)
        {
            var content = await contentService.GetContent(id);

            if (content is null) return NotFound();
            else
            {
                await contentService.DeleteContent(id);
                return NoContent();
            }
        }
    }
}
