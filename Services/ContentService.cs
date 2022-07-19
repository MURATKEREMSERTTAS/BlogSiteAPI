using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services
{
    public class ContentService : IContentService
    {
        private readonly IMongoCollection<Content> mongoCollection;

        public ContentService(IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);

            mongoCollection = database.GetCollection<Content>(databaseSetting.ContentCollectionName);
        }

        public async Task<List<Content>> GetContents() =>
            await mongoCollection.Find(x => true).ToListAsync();

        public async Task<Content> GetContent(string id) =>
            await mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateContent(Content NewContent) =>
            await mongoCollection.InsertOneAsync(NewContent);

        public async Task UpdateContent(string id, Content UpdateContent) =>
            await mongoCollection.ReplaceOneAsync(x => x.Id == id, UpdateContent);

        public async Task DeleteContent(string id) =>
            await mongoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
