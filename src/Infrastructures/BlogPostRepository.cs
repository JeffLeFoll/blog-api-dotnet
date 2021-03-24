using BlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Infrastructures
{
    public interface BlogPostRepository
    {
        List<BlogPost> FindAll();
        BlogPost FindById(String id);
        BlogPost Create(BlogPost entity);
        BlogPost Update(BlogPost entity);
        void RemoveById(String id);
        void RemoveAll();
        List<BlogPost> Find(String field, String param);



    }
}
