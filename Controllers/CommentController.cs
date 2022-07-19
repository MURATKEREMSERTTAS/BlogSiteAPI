using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public async Task<List<Comment>> GetComments() =>
            await commentService.GetComments();

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(string id) 
        { 
            var comment = await commentService.GetComment(id);

            if (comment == null) return NotFound();
            else return comment;
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(Comment NewComment)
        {
            await commentService.CreateComment(NewComment);

            return CreatedAtAction(nameof(GetComments), new { id = NewComment.Id }, NewComment);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateComment(string id,Comment UpdateComment)
        {
            var comment = await commentService.GetComment(id);

            if (comment == null) return NotFound();
            else{
                UpdateComment.Id = comment.Id;
                await commentService.UpdateComment(id, UpdateComment);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteComment(string id)
        {
            var comment = await commentService.GetComment(id);

            if (comment == null) return NotFound();
            else
            {
                await commentService.DeleteComment(id);
                return NoContent();
            }
        }

    }
}
