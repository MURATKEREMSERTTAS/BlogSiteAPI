using BlogSiteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAuthors();
        Task<Author> GetAuthor(string id);
        Task CreateAuthor(Author NewAuthor);
        Task UpdateAuthor(string id, Author UpdateAuthor);
        Task DeleteAuthor(string id);
    }
}
