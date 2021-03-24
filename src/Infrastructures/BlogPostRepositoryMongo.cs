using BlogApi.Models;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Infrastructures
{
    public class BlogPostRepositoryMongo : BlogPostRepository
    {
        private readonly IMongoCollection<BlogPost> _blogPosts;

        public BlogPostRepositoryMongo(IMongoDatabaseSettings settings)
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            var client = new MongoClient(settings.MONGODB_ADDON_URI);
            var database = client.GetDatabase(settings.MONGODB_ADDON_DB);

            _blogPosts = database.GetCollection<BlogPost>("blogposts");
        }

        public BlogPost Create(BlogPost entity)
        {
            _blogPosts.InsertOne(entity);

            return entity;
        }

        public List<BlogPost> Find(string field, string param) =>
            _blogPosts.Find(Builders<BlogPost>.Filter.Eq(field, param)).ToList();

        public List<BlogPost> FindAll() =>
            _blogPosts.Find(blogPost => true).ToList();

        public BlogPost FindById(string id) =>
            _blogPosts.Find<BlogPost>(blogPost => blogPost._id == id).FirstOrDefault();

        public void RemoveAll() =>
            _blogPosts.DeleteMany(blogPost => true);

        public void RemoveById(string id) =>
            _blogPosts.DeleteOne<BlogPost>(blogPost => blogPost._id == id);

        public BlogPost Update(BlogPost entity)
        {
            _blogPosts.ReplaceOne(blogPost => blogPost._id == entity._id, entity);

            return entity;
        }
            
    }
}
