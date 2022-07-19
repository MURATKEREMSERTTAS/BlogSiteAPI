using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> mongoCollection;

        public UserService(IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);

            mongoCollection = database.GetCollection<User>(databaseSetting.UserCollectionName);
        }

        public async Task<List<User>> GetUsers() =>
            await mongoCollection.Find(x => true).ToListAsync();

        public async Task<User> GetUser(string id) =>
            await mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateUser(User user)=>
            await mongoCollection.InsertOneAsync(user);

        public async Task UpdateUser(string id,User updateUser)=>
            await mongoCollection.ReplaceOneAsync(x=>x.Id == id, updateUser);

        public async Task DeleteUser(string id) =>
            await mongoCollection.DeleteOneAsync(x => x.Id == id);

    }
}
