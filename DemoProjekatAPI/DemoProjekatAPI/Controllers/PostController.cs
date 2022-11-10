using DemoProjekatAPI.Data;
using DemoProjekatAPI.Filters;
using DemoProjekatAPI.Logic.PostLogic;
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
    //[TokenAuthenticationFilter]
    public class PostController : ControllerBase
    {
        private readonly IPostManager _postManager;

        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            try
            {
                return await _postManager.FetchAllPosts();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddPost([FromBody] Post post)
        {
            try
            {
                return await _postManager.AddNewPost(post);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<int>> UpdatePost([FromBody] Post post,[FromHeader]int userId)
        {
            try
            {
                return await _postManager.UpdatePost(post, userId);
            }
            catch (ArgumentOutOfRangeException ae)
            {
                return BadRequest(ae.Message);
            }
            catch(ArgumentNullException ane)
            {
                return NotFound(ane.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeletePost([FromBody]Post post)
        {
            try
            {
                return await _postManager.DeletePost(post);
            }
            catch (ArgumentOutOfRangeException aoe)
            {
                return BadRequest(aoe.Message);
            }
            catch (ArgumentNullException ane)
            {
                return NotFound(ane.Message);
            }
        }
/*
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost("postLikeNumber")]
        public async Task<ActionResult<int>> GetLikeNumber([FromBody] ReqBody req)
        {
            var likes = await _context.Likes.Where(x => x.postId == req.postId).CountAsync();
            return Ok(likes);
        }

        [HttpPost("like")]
        public async Task<ActionResult<bool>> Like([FromBody] ReqBody req)
        {
            bool liked = false;
            var like = await _context.Likes.Where(x => x.postId == req.postId && x.userId == req.userId).FirstOrDefaultAsync();
            if(liked = like==null)
                _context.Add(new Like{ postId=req.postId, userId=req.userId});
            else
                _context.Likes.Remove(like);

            await _context.SaveChangesAsync();
            return liked;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsFromUser(int userId)
        {
            return await _context.Posts.Where(x => x.UserId == userId).ToListAsync();
        }*/


    }

    public class ReqBody
    {
        public int postId { get; set; }
        public int userId { get; set; }
    }
}
