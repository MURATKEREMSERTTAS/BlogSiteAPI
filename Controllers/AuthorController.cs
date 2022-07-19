using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public async Task<List<Author>> GetAuthors() =>
            await authorService.GetAuthors();

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(string id)
        {
            var author = await authorService.GetAuthor(id);

            if (author == null) return NotFound();
            else return author;
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthor(Author NewAuthor)
        {
            await authorService.CreateAuthor(NewAuthor);
            return CreatedAtAction(nameof(GetAuthors), new { id = NewAuthor.Id }, NewAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(string id,Author UpdateAuthor)
        {
            var author = await authorService.GetAuthor(id);

            if(author == null) return NotFound();
            else
            {
                UpdateAuthor.Id = author.Id;
                await authorService.UpdateAuthor(id,UpdateAuthor);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAuthor(string id)
        {
            var author = await authorService.GetAuthor(id);

            if (author == null) return NotFound();
            else
            {
                await authorService.DeleteAuthor(id);
                return NoContent();
            }
        }

    }
}
