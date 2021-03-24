using BlogApi.Infrastructures;
using BlogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly ILogger<BlogPostController> _logger;
        private readonly BlogPostRepository _blogPostRepository;

        public BlogPostController(ILogger<BlogPostController> logger, BlogPostRepository blogPostRepository)
        {
            _logger = logger;
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public ActionResult<List<BlogPost>> GetAllBlogPosts() =>
            _blogPostRepository.FindAll();

        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetBlogPost(string id)
        {
            var blogPost = _blogPostRepository.FindById(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }
        [HttpGet("author/{name}")]
        public ActionResult<List<BlogPost>> GetBlogPostFromAuthor(string name)
        {
            var blogPosts = _blogPostRepository.Find("author", name);

            if (blogPosts == null || !blogPosts.Any())
            {
                return NotFound();
            }

            return blogPosts;
        }

        [HttpPost]
        public ActionResult<BlogPost> AddBlogPost(BlogPost blogPost)
        {
            _blogPostRepository.Create(blogPost);

            return CreatedAtRoute("GetBlogPost", new { id = blogPost._id.ToString() }, blogPost);
        }

        [HttpPut]
        public IActionResult UpdateBlogPost(BlogPost blogPost)
        {
            var oldBlogPost = _blogPostRepository.FindById(blogPost._id);

            if (oldBlogPost == null)
            {
                return NotFound();
            }

            _blogPostRepository.Update(blogPost);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteAllBlogPosts() 
        {
            _blogPostRepository.RemoveAll();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlogPost(string id)
        {
            var blogPost = _blogPostRepository.FindById(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            _blogPostRepository.RemoveById(id);

            return NoContent();
        }

    }
}
