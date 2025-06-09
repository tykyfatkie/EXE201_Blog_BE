using BlogApi.Data;
using BlogApi.DTOs;
using BlogApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Blogs
        [HttpPost]
        public async Task<ActionResult<BlogDto>> CreateBlog(CreateBlogDto createBlogDto)
        {
            // Kiểm tra nếu không có giá trị cho ImageUrl thì mặc định là null
            string imageUrl = string.IsNullOrEmpty(createBlogDto.ImageUrl) ? null : createBlogDto.ImageUrl;

            var blog = new Blog
            {
                UserId = createBlogDto.UserId,
                Title = createBlogDto.Title,
                Content = createBlogDto.Content,
                ImageUrl = imageUrl  // Nếu không có ảnh, giá trị này sẽ là null
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            var blogDto = new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                ImageUrl = blog.ImageUrl,  // Nếu không có ảnh, sẽ trả về null
                CreatedAt = blog.CreatedAt
            };

            return CreatedAtAction(nameof(CreateBlog), new { id = blog.Id }, blogDto);
        }


        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDto>>> GetBlogs()
        {
            var blogs = await _context.Blogs.Include(b => b.User).ToListAsync();
            var blogsDto = blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                ImageUrl = b.ImageUrl,  // Đây là null nếu không có ảnh
                CreatedAt = b.CreatedAt,
                User = new UserDto
                {
                    Id = b.User.Id,
                    Username = b.User.Username,
                    CreatedAt = b.User.CreatedAt
                }
            }).ToList();

            return Ok(blogsDto);
        }

        // PUT: api/Blogs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, CreateBlogDto createBlogDto)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            blog.Title = createBlogDto.Title;
            blog.Content = createBlogDto.Content;
            blog.ImageUrl = null;  // Không cần thay đổi ảnh, giữ mặc định là null

            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Blogs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
