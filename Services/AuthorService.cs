using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMongoCollection<Author> mongoCollection;

        public AuthorService(IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);

            mongoCollection = database.GetCollection<Author>(databaseSetting.AuthorCollectionName);
        }

        public async Task<List<Author>> GetAuthors() =>
            await mongoCollection.Find(x => true).ToListAsync();

        public async Task<Author> GetAuthor(string id) =>
            await mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAuthor(Author NewAuthor) =>
            await mongoCollection.InsertOneAsync(NewAuthor);

        public async Task UpdateAuthor(string id, Author UpdateAuthor) =>
            await mongoCollection.ReplaceOneAsync(id, UpdateAuthor);

        public async Task DeleteAuthor(string id) =>
            await mongoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
