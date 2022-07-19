using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tag = BlogSiteAPI.Models.Tag;

namespace BlogSiteAPI.Services
{
    public class TagService : ITagService
    {
        private readonly IMongoCollection<Tag> mongoCollection;

        public TagService(IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);

            mongoCollection = database.GetCollection<Tag>(databaseSetting.TagCollectionName);
        }

        public async Task<List<Tag>> GetTags() =>
            await mongoCollection.Find(x => true).ToListAsync();

        public async Task<Tag> GetTag(string id) =>
            await mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateTag(Tag newTag )=>
            await mongoCollection.InsertOneAsync(newTag);

        public async Task UpdataTag(string id, Tag UpdateTag) =>
            await mongoCollection.ReplaceOneAsync(x => x.Id == id, UpdateTag);

        public async Task DeleteTag(string id) =>
            await mongoCollection.DeleteOneAsync(x => x.Id == id);

    }
}
