using BlogSiteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments();
        Task<Comment> GetComment(string id);
        Task CreateComment(Comment NewComment);
        Task UpdateComment(string id, Comment UpdateComment);
        Task DeleteComment(string id);
    }
}
