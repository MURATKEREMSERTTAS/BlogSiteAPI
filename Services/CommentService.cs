using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services
{
    public class CommentService: ICommentService
    {
        private readonly IMongoCollection<Comment> mongoCollection;

        public CommentService(IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            mongoCollection = database.GetCollection<Comment>(databaseSetting.CommentCollectionName);
        }

        public async Task<List<Comment>> GetComments() =>
            await mongoCollection.Find(x => true).ToListAsync();

        public async Task<Comment> GetComment(string id) =>
            await mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateComment(Comment NewComment) =>
            await mongoCollection.InsertOneAsync(NewComment);

        public async Task UpdateComment(string id, Comment UpdateComment) =>
            await mongoCollection.ReplaceOneAsync(x => x.Id == id, UpdateComment);

        public async Task DeleteComment(string id) =>
            await mongoCollection.DeleteOneAsync(x => x.Id == id);
     }
}
