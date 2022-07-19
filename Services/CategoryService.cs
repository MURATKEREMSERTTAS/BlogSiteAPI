using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IMongoCollection<Category> mongoCollection;

        public CategoryService(IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);

            mongoCollection = database.GetCollection<Category>(databaseSetting.CategoryCollectionName);
        }

        public async Task<List<Category>> GetCategories() =>
            await mongoCollection.Find(x => true).ToListAsync();

        public async Task<Category> GetCategory(string id) =>
            await mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateCategory(Category NewCategory) =>
            await mongoCollection.InsertOneAsync(NewCategory);

        public async Task UpdateCategory(string id, Category UpdateCategory) =>
            await mongoCollection.ReplaceOneAsync(x => x.Id == id, UpdateCategory);

        public async Task DeleteCategory(string id) =>
            await mongoCollection.DeleteOneAsync(x=>x.Id == id);
    }
}
