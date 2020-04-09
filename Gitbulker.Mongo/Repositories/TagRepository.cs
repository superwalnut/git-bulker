using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gitbulker.Mongo.Repositories
{
    public class TagRepository : ITagRepository
    {        
        private readonly IMongoCollection<Model.Entities.Tag> _collection;

        public TagRepository(IMongoCollection<Model.Entities.Tag> collection)
        {
            _collection = collection;
        }

        public async Task<Model.Entities.Tag> GetTagById(string id)
        {
            var objId = new ObjectId(id);
            return await _collection.Find(x => x.Id == objId).FirstOrDefaultAsync();
        }

        public async Task<Model.Entities.Tag> GetTagByName(string name)
        {
            return await _collection.Find(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Model.Entities.Tag>> GetAll()
        {
            return await _collection.Find("{}").ToListAsync();
        }

        public async Task SaveTag(Model.Entities.Tag tag)
        {
            if (tag.Id == ObjectId.Empty)
            {
                await _collection.InsertOneAsync(tag);
            }
            else
            {
                await _collection.ReplaceOneAsync(x => x.Id == tag.Id, tag);
            }
        }
    }
}
