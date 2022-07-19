using BlogSiteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Interfaces
{
    public interface IContentService
    {
        Task<List<Content>> GetContents();
        Task<Content> GetContent(string id);
        Task CreateContent(Content NewContent);
        Task UpdateContent(string id, Content UpdateContent);
        Task DeleteContent(string id);
    }
}
