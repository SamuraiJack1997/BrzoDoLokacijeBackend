using DemoProjekatAPI.Data;
using DemoProjekatAPI.Filters;
using DemoProjekatAPI.Logic.PostLogic;
using DemoProjekatAPI.Models;
using LocathorAPI.Models;
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
                return await _postManager.GetAllPosts();
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            Post post;
            try
            {
                post = await _postManager.GetPostById(id);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
            return post;
        }

        [HttpPost("postLikeNumber")]
        public async Task<ActionResult<int>> GetLikeNumber([FromBody] ReqBody req)
        {
            try
            {
                return await _postManager.GetPostLikeNumber(req.postId);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("like")]
        public async Task<ActionResult<bool>> Like([FromBody] ReqBody req)
        {
            try
            {
                return await _postManager.LikeOrDislikePost(req.postId, req.userId);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsFromUser(int userId)
        {
            return await _postManager.GetPostByUser(userId);
        }

        [HttpPost("comment")]
        public async Task<ActionResult<bool>> CommentPost([FromBody]Comment comment)
        {
            try
            {
                return await _postManager.CommentOnPost(comment);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<Comment>>> GetPostComments(int postId)
        {
            try
            {
                return await _postManager.GetCommentsFromPost(postId);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }

    public class ReqBody
    {
        public int postId { get; set; }
        public int userId { get; set; }
    }
}
