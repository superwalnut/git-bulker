using System;
using System.Collections.Generic;
using System.IO;
using Gitbulker.Model.Models;
using Gitbulker.Service.Interfaces;
using Newtonsoft.Json;
using System.Linq;

namespace Gitbulker.Service.Services
{
    public class StoreService : IStoreService
    {
        private readonly string _dataFolder = "";

        public StoreService()
        {
            _dataFolder = Path.Combine(Environment.CurrentDirectory, "data", "projects");
        }

        public void CreateProject(string name)
        {
            // create data folder
            CreateDataFolder();

            // create project folder
            CreateProjectFolder(name);            
        }

        public void SaveProject(Project project)
        {
            var projectFilePath = Path.Combine(_dataFolder, project.Id, $"{project.Id}.json");
            var data = JsonConvert.SerializeObject(project);
            using (var writer = new StreamWriter(projectFilePath))
            {
                writer.Write(data);
                writer.Flush();
            }
        }

        public Project LoadProject(string id)
        {
            var projectFilePath = Path.Combine(_dataFolder, id, $"{id}.json");
            if (!File.Exists(projectFilePath))
            {
                throw new FileNotFoundException($"project data file is not found: {id}.json");
            }

            using (var reader = new StreamReader(projectFilePath))
            {
                var data = reader.ReadToEnd();
                var project = JsonConvert.DeserializeObject<Project>(data);
                return project;
            }
        }        

        public void SaveTag(Tag tag)
        {
            List<Tag> tags = new List<Tag>();

            var tagFile = Path.Combine(_dataFolder, tag.ProjectId, "tags.json");
            if(File.Exists(tagFile))
            {
                // append data if file already exist
                using (var reader = new StreamReader(tagFile))
                {
                    var json = reader.ReadToEnd();
                    tags = JsonConvert.DeserializeObject<List<Tag>>(json);
                }
            }

            var foundItem = tags.FirstOrDefault(x => x.Name == tag.Name);

            if (foundItem != null)
            {
                foundItem.Name = tag.Name;
                foundItem.ProjectId = tag.ProjectId;
                foundItem.Repositories = tag.Repositories;
            }
            else
            {
                tags.Add(tag);
            }

            var data = JsonConvert.SerializeObject(tags);
            using (var writer = new StreamWriter(tagFile))
            {
                writer.Write(data);
                writer.Flush();
            }
        }

        private void CreateDataFolder()
        {
            if(!Directory.Exists(_dataFolder))
                Directory.CreateDirectory(_dataFolder);
        }

        private void CreateProjectFolder(string name)
        {
            var projectFolder = Path.Combine(_dataFolder, $"{name}");
            if (!Directory.Exists(projectFolder))
            {
                Directory.CreateDirectory(projectFolder);
            }
        }
    }
}