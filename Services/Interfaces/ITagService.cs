using BlogSiteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<Tag>> GetTags();

        Task<Tag> GetTag(string id);

        Task CreateTag(Tag newTag);

        Task UpdataTag(string id, Tag UpdateTag);

        Task DeleteTag(string id);
    }
}
