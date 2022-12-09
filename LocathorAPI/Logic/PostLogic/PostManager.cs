using DemoProjekatAPI.Data;
using DemoProjekatAPI.Models;
using LocathorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjekatAPI.Logic.PostLogic
{
    public class PostManager : IPostManager
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

        public async Task<ActionResult<Post>> AddNewPost(Post post)
        {
            if (post.postId != 0)
                throw new Exception("Wrong HTTP method, did you mean to use PUT?");

            User user = await _context.Users.Where(x => x.Username == post.Username).FirstOrDefaultAsync();
            if (user == null)
                throw new Exception("User does not exist");
            post.UserId = user.UserId;

            post.CreatedDate = DateTime.Now;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<int> UpdatePost(Post post, int userId)
        {
            if (post.postId <= 0)
            {
                throw new ArgumentOutOfRangeException("Post Id is out of range");
            }
            var existingPost = await _context.Posts.FirstOrDefaultAsync(x => x.postId == post.postId);
            if (existingPost == null)
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

            var fetchedPost = await _context.Posts.FirstOrDefaultAsync(x => x.postId == post.postId);
            if (fetchedPost == null)
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
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == postId)!;
            if (post == null)
                throw new Exception("Post does not exist");
            return await _context.Likes.Where(x => x.postId == postId).CountAsync();
        }

        public async Task<bool> LikeOrDislikePost(int postId, int userId)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == postId);
            if (post == null)
                throw new Exception("This post does not exist");
            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId)!;
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

        public async Task<bool> CommentOnPost(Comment comment)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == comment.postId);
            if (post == null)
                throw new Exception("This post does not exist");
            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == comment.userId)!;
            if (user == null)
                throw new Exception("This user does not exist");

            comment.date = DateTime.Now;

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return true;
        }

        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsFromPost(int postId)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.postId == postId);
            if (post == null)
                throw new Exception("This post does not exist");

            List<Comment> comments = new List<Comment>();
            comments = await _context.Comments.Where(x => x.postId == postId).ToListAsync();

            return comments;

        }

        public async Task<bool> ChangePostPhoto(Post post)
        {
            var newPost = await _context.Posts.Where(x => x.postId == post.postId).FirstOrDefaultAsync();
            if (newPost == null)
            {
                throw new Exception("This post does not exist");
            }

            newPost.PhotoUrl = post.PhotoUrl;
            _context.SaveChanges();
            return true;
        }

        public async Task<ActionResult<IEnumerable<object>>> GetMostLiked()
        {
            var liked = await _context.Likes.GroupBy(x => x.postId).Select(g => new { post = g.Key, count = g.Count() }).OrderBy(o => o.count).Select(g => g.post).Take(20).ToListAsync();
            return await _context.Posts.Where(x=> liked.Contains(x.postId)).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Post>>> PinpointPosts(double la1, double lo1, double r)
        {
            var posts = await _context.Posts.Where(x => (x.Latitude < la1 + r && x.Latitude > la1 - r) && (x.Longitude < lo1 + r && x.Longitude > lo1 - r)).ToListAsync();
            return posts;
        }

        public async Task<bool> IsLiked(int userId, int postId)
        {
            User user = await _context.Users.Where(x=>x.UserId==userId).FirstOrDefaultAsync();
            if (user == null)
                throw new Exception("User doesnt exist");

            Post post = await _context.Posts.Where(x => x.postId == postId).FirstOrDefaultAsync();
            if (post == null)
                throw new Exception("Post doesnt exist");

            var liked = await _context.Likes.Where(x => x.postId == postId && x.userId == userId).FirstOrDefaultAsync();
            return liked!=null;
        }

        public async Task<ActionResult<IEnumerable<Post>>> PostsByUser(string username)
        {
            var User = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
            if (User == null)
                throw new Exception("this user does not exist");

            return await _context.Posts.Where(x => x.UserId == User.UserId).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Post>>> SearchPosts(string title)
        {
            List<Post> post = await _context.Posts.Where(x => x.Title.Contains(title)).ToListAsync();
            return post;
        }

        public class PostLikes
        {
            public Post? post { get; set; }
            public int likes { get; set; }
        }
    }
}
