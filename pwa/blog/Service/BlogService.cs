using System.Collections.Generic;
using System.IO;
using System.Linq;
using blog.Models;
using Microsoft.AspNetCore.Hosting;

namespace blog.Controllers
{
    public class BlogService : IBlogService
    {
        private IHostingEnvironment _env;
        public BlogService(IHostingEnvironment env)
        {
            _env = env;
        }
        private List<BlogPost> Posts
        {
            get
            {
                return new List<BlogPost>() {new BlogPost { PostId = 1, Title = "xxx", ShortDescription = "xxx" }};
            }
        }
        public string GetPostText(string link)
        {
            var post = Posts.FirstOrDefault(_ => _.Link == link);
            return File.ReadAllText(
            $"{_env.ContentRootPath}/Posts/{post.PostId}_post.md");
        }
        public List<BlogPost> GetLatestPosts()
        {
            return Posts.OrderByDescending(_ => _.PostId).Take(3).ToList();
        }

        public List<BlogPost> GetOlderPosts(int oldestPostId)
        {
            var posts = Posts.Where(_ => _.PostId < oldestPostId).OrderByDescending(_ => _.PostId).ToList();

            if (posts.Count < 3)
                return posts;

            return posts.Take(3).ToList();
        }
    }
}
