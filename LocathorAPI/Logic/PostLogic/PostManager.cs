using DemoProjekatAPI.Data;
using DemoProjekatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjekatAPI.Logic.PostLogic
{
    public class PostManager :IPostManager
    {
        private readonly BrzoDoLokacijeDbContext _context;
        public PostManager(BrzoDoLokacijeDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<int> AddNewPost(Post post)
        {
            if (post.postId != 0)
                throw new Exception("Wrong HTTP method, did you mean to use PUT?");
            _context.Posts.Add(post);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePost(Post post,int userId)
        {
            if (post.postId <= 0)
            {
                throw new ArgumentOutOfRangeException("Post Id is out of range");
            }
            var existingPost = await _context.Posts.FirstOrDefaultAsync(x => x.postId == post.postId);
            if (existingPost==null)
            {
                throw new ArgumentNullException("This post does not exist");
            }
/*            if (existingPost.UserId != userId)
            {
                throw new Exception("This user cannot modify this post");
            }*/

            existingPost.UserId = post.UserId;
            existingPost.Title = post.Title;
            existingPost.Latitude = post.Latitude;
            existingPost.Longitude = post.Longitude;
            existingPost.Description = post.Description;
            existingPost.CreatedDate = post.CreatedDate;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePost(Post post)
        {
            if (post.postId <= 0)
            {
                throw new ArgumentOutOfRangeException("Post Id is out of range");
            }

            var fetchedPost = await _context.Posts.FirstOrDefaultAsync(x=>x.postId==post.postId);
            if(fetchedPost == null)
            {
                throw new ArgumentNullException("This post does not exist");
            }

            _context.Posts.Remove(fetchedPost);
            return await _context.SaveChangesAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == postId);
            if (post == null)
                throw new Exception("Post with id " + postId + " not found");
            return post;
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetPostByUser(int userId)
        {
            return await _context.Posts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<int> GetPostLikeNumber(int postId)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == postId);
            if (post == null)
                throw new Exception("Post does not exist");
            return await _context.Likes.Where(x => x.postId == postId).CountAsync();
        }

        public async Task<bool> LikeOrDislikePost(int postId, int userId)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == postId);
            if (post == null)
                throw new Exception("This post does not exist");
            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
                throw new Exception("This user does not exist");

            bool liked = false;
            var like = await _context.Likes.Where(x => x.postId == postId && x.userId == userId).FirstOrDefaultAsync();
            if (liked = like == null)
                _context.Add(new Like { postId = postId, userId = userId });
            else
                _context.Likes.Remove(like);

            await _context.SaveChangesAsync();
            return liked;
        }
    }
}
