using BlogApi.Infrastructures;
using BlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApiTests.Infrastructures
{
    class BlogPostRepositoryList : BlogPostRepository
    {
        public List<BlogPost> _dataStore { get; set; }

        public BlogPostRepositoryList(List<BlogPost> dataStore) 
        {
            _dataStore = dataStore;
        }

        public BlogPostRepositoryList()
        {
            _dataStore = new List<BlogPost>();
        }

        public List<BlogPost> FindAll()
        {
            return _dataStore;
        }

        public BlogPost FindById(string id)
        {
            return _dataStore.Find(e => e._id == id);
        }

        public BlogPost Create(BlogPost entity)
        {
            _dataStore.Add(entity);

            return entity;
        }

        public BlogPost Update(BlogPost entity)
        {
            _dataStore.RemoveAll(e => e._id == entity._id);

            _dataStore.Add(entity);

            return entity;
        }

        public void RemoveById(string id)
        {
            _dataStore.RemoveAll(e => e._id == id);
        }

        public void RemoveAll()
        {
            _dataStore.Clear();
        }

        public List<BlogPost> Find(string field, string param)
        {
            return _dataStore.FindAll(e => (string) e.GetType().GetProperty(field).GetValue(e) == param);
        }
    }
}
