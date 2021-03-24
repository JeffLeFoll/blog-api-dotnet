using BlogApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApiTests.Infrastructures;
using BlogApi.Models;
using NUnit.Framework;
using NFluent;

namespace BlogApi.Controllers.Tests
{
    [TestFixture]
    public class BlogPostControllerTests
    {
        [Test]
        public void GetAllBlogPostsTest()
        {
            var dataStore = new List<BlogPost> { new BlogPost("1", "titre 1", "bla bla bla", "2021-03-20", null, "Jeff"), new BlogPost("2", "titre 2", "Lorem ipsum", "2021-03-24", null, "Jeff") };
            var repo = new BlogPostRepositoryList(dataStore);
            var controller = new BlogPostController(null, repo);

            var result = controller.GetAllBlogPosts();

            Check.That(result.Value).ContainsExactly(dataStore);
        }

        [Test]
        public void GetBlogPost()
        {
            BlogPost blogPost1 = new("1", "titre 1", "bla bla bla", "2021-03-20", null, "Jeff");
            BlogPost blogPost2 = new("2", "titre 2", "Lorem ipsum", "2021-03-24", null, "Jeff");
            var dataStore = new List<BlogPost> { blogPost1, blogPost2 };
            var repo = new BlogPostRepositoryList(dataStore);
            var controller = new BlogPostController(null, repo);

            var result = controller.GetBlogPost("1");

            Check.That(result.Value).IsEqualTo(blogPost1);
        }

        [Test]
        public void AddBlogPost()
        {
            var dataStore = new List<BlogPost>();
            var repo = new BlogPostRepositoryList(dataStore);
            var controller = new BlogPostController(null, repo);

            BlogPost blogPost = new("1", "titre 1", "bla bla bla", "2021-03-20", null, "Jeff");
            controller.AddBlogPost(blogPost);

            Check.That(dataStore).HasSize(1);
            Check.That(dataStore).ContainsExactly(blogPost);
        }

        [Test]
        public void UpdateBlogPost()
        {
            BlogPost blogPost1 = new("1", "titre 1", "bla bla bla", "2021-03-20", null, "Jeff");
            BlogPost blogPost2 = new("2", "titre 2", "Lorem ipsum", "2021-03-24", null, "Jeff");
            var dataStore = new List<BlogPost> { blogPost1, blogPost2 };
            var repo = new BlogPostRepositoryList(dataStore);
            var controller = new BlogPostController(null, repo);

            blogPost1.Title = "Titre 1 Fixed";
            controller.UpdateBlogPost(blogPost1);

            Check.That(dataStore.Extracting("Title")).ContainsExactly("titre 2", "Titre 1 Fixed");
        }

        [Test]
        public void DeleteAllBlogPosts()
        {
            BlogPost blogPost1 = new("1", "titre 1", "bla bla bla", "2021-03-20", null, "Jeff");
            BlogPost blogPost2 = new("2", "titre 2", "Lorem ipsum", "2021-03-24", null, "Jeff");
            var dataStore = new List<BlogPost> { blogPost1, blogPost2 };
            var repo = new BlogPostRepositoryList(dataStore);
            var controller = new BlogPostController(null, repo);

            controller.DeleteAllBlogPosts();

            Check.That(dataStore).IsEmpty();
        }

        [Test]
        public void DeleteBlogPost()
        {
            BlogPost blogPost1 = new("1", "titre 1", "bla bla bla", "2021-03-20", null, "Jeff");
            BlogPost blogPost2 = new("2", "titre 2", "Lorem ipsum", "2021-03-24", null, "Jeff");
            var dataStore = new List<BlogPost> { blogPost1, blogPost2 };
            var repo = new BlogPostRepositoryList(dataStore);
            var controller = new BlogPostController(null, repo);

            controller.DeleteBlogPost("2");

            Check.That(dataStore).ContainsExactly(blogPost1);
        }
    }

}