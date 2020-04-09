using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gitbulker.Mongo.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IMongoCollection<Project> _collection;

        public ProjectRepository(IMongoCollection<Project> collection)
        {
            _collection = collection;
        }

        public async Task<Project> GetProjectById(string id)
        {
            var objId = new ObjectId(id);           
            return await _collection.Find(x => x.Id == objId).FirstOrDefaultAsync();
        }

        public async Task<Project> GetProjectByName(string name)
        {
            return await _collection.Find(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Project>> GetAll()
        {
            return await _collection.Find("{}").ToListAsync();
        }

        public async Task SaveProject(Project project)
        {
            if (project.Id == ObjectId.Empty)
            {
                await _collection.InsertOneAsync(project);
            }
            else
            {
                await _collection.ReplaceOneAsync(x => x.Id == project.Id, project);
            }
        }
    }
}
