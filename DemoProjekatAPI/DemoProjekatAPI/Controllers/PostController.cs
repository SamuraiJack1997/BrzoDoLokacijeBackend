using DemoProjekatAPI.Data;
using DemoProjekatAPI.Filters;
using DemoProjekatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjekatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[TokenAuthenticationFilter]
    public class PostController : ControllerBase
    {
        private readonly BrzoDoLokacijeDbContext _context;

        public PostController(BrzoDoLokacijeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddPost([FromBody] Post post)
        {
            _context.Posts.Add(post);
            return await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdatePost([FromBody] Post post)
        {
            var existingPost = _context.Posts.FirstOrDefault(x => x.postId == post.postId); ;
            if (existingPost != null)
            {
                existingPost.UserId = post.UserId;
                existingPost.Title = post.Title;
                existingPost.Latitude = post.Latitude;
                existingPost.Longitude = post.Longitude;
                existingPost.Description = post.Description;
                existingPost.CreatedDate = post.CreatedDate;

                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeletePost([FromBody] Post post)
        {
            _context.Posts.Remove(post);
            return await _context.SaveChangesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsFromUser(int userId)
        {
            return await _context.Posts.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
