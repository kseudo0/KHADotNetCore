using KHADotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KHADotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> blogList = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return Ok(blogList);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel? blog = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(blog);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Savubg Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            BlogModel? blogObj = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blogObj is null)
            {
                return NotFound("No Data Found");
            }
            blogObj.BlogTitle = blog.BlogTitle;
            blogObj.BlogAuthor = blog.BlogAuthor;
            blogObj.BlogContent = blog.BlogContent;

            int result = _db.SaveChanges();
            string message = result > 0 ? "Update successful." : "Update failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? blogObj = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blogObj is null)
            {
                return NotFound("No Data Found");
            }
            _db.Blogs.Remove(blogObj);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Delete successful." : "Delete failed";
            return Ok("Delete Blog");
        }
    }
}
