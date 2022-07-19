using BlogSiteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(string id);
        Task CreateCategory(Category NewCategory);
        Task UpdateCategory(string id, Category UpdateCategory);
        Task DeleteCategory(string id);
    }
}
