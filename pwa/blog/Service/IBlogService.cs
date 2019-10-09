using System.Collections.Generic;
using blog.Models;

namespace blog.Controllers
{
    public interface IBlogService
    {
        List<BlogPost> GetLatestPosts();
        string GetPostText(string link);
    }
}