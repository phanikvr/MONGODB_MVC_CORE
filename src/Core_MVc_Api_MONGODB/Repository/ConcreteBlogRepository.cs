using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_MVc_Api_MONGODB.Model;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Core_MVc_Api_MONGODB.Core;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Core_MVc_Api_MONGODB.Repository
{
    public class ConcreteBlogRepository : IBlogRepository
    {
        private readonly IMongoDatabase _db;
        public ConcreteBlogRepository(IOptions<AppSettings> appSettins)
        {
            var client = new MongoClient(appSettins.Value.MongoConnection.ConnectionString);
            _db = client.GetDatabase(appSettins.Value.MongoConnection.Database);
        }
        public async Task AddBlog(Blog newBlog)
        {
            await _db.GetCollection<Blog>("blogColNested").InsertOneAsync(newBlog);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _db.GetCollection<Blog>("blogColNested").Find<Blog>(_ => true).ToListAsync();
        }

        public async Task<Blog> GetBlog(string id)
        {
            var filter = Builders<Blog>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _db.GetCollection<Blog>("blogColNested").Find(filter).SingleOrDefaultAsync();
        }

        public async Task RemoveAllBlogs()
        {
            await _db.DropCollectionAsync("blogColNested");
        }

        public async Task<bool> RemoveBlog(string id)
        {
            var filter = Builders<Blog>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await _db.GetCollection<Blog>("blogColNested").DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }

        public async Task UpdateBlog(string id, IEnumerable<KeyValuePair<string, string>> keyValues)
        {
            var filter = Builders<Blog>.Filter.Eq("_id", ObjectId.Parse(id));
            //// var doc = new UpdateDocument(BsonSerializer.Deserialize<BsonDocument>(body));
            //var doc = new UpdateDocument(keyValues);
            //var result = await _db.GetCollection<Blog>("blogColNested").UpdateOneAsync(filter, doc);

            var updateDoc = keyValues.Select(item => { return Update.Set(item.Key, BsonValue.Create(item.Value)); });
            //var updateDoc = Builders<Blog>.Update.Set("Title", "Changes using Code");
            //var result = _db.GetCollection<Blog>("blogColNested").UpdateOne(filter, updateDoc);
            foreach (var item in keyValues)
            {
                await _db.GetCollection<Blog>("blogColNested").UpdateOneAsync(filter, Builders<Blog>.Update.Set(item.Key, item.Value));
            }
        }

        public async Task<bool> PostComment(string id, BlogComment comment)
        {
            // we assume that an user can comment n number of times, So do not allow him to edit an existing comment.
            var filter = Builders<Blog>.Filter.Eq("_id", ObjectId.Parse(id));
            //var result = await _db.GetCollection<Blog>("blogColNested").UpdateOneAsync(filter, Builders<Blog>.Update.Set("Comments", BsonValue.Create(comment)));
            var result = await _db.GetCollection<Blog>("blogColNested").UpdateOneAsync(filter,
                Builders<Blog>.Update.Push("Comments", comment));
            return result.IsAcknowledged;

        }
    }
}
