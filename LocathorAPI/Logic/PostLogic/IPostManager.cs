using DemoProjekatAPI.Models;
using LocathorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DemoProjekatAPI.Logic.PostLogic.PostManager;

namespace DemoProjekatAPI.Logic.PostLogic
{
    public interface IPostManager
    {
        public Task<int> UpdatePost(Post post, int userId);
        public Task<ActionResult<IEnumerable<Post>>> GetAllPosts();
        public Task<ActionResult<Post>> AddNewPost (Post post);
        public Task<int> DeletePost(Post post);
        public Task<Post> GetPostById(int postId);
        public Task<ActionResult<IEnumerable<Post>>> GetPostByUser(int userId);
        public Task<int> GetPostLikeNumber(int postId);
        public Task<bool> LikeOrDislikePost(int postId, int userId);
        public Task<bool> CommentOnPost(Comment comment);
        public Task<ActionResult<IEnumerable<Comment>>> GetCommentsFromPost(int postId);
        public Task<bool> ChangePostPhoto(Post post);
        public Task<ActionResult<IEnumerable<object>>> GetMostLiked();
        public Task<ActionResult<IEnumerable<Post>>> PinpointPosts(double lat, double longit, double radius);
        public Task<bool> IsLiked(int userId, int postId);
        public Task<ActionResult<IEnumerable<Post>>> PostsByUser(string username);
        public Task<ActionResult<IEnumerable<Post>>> SearchPosts(string title);
    }
}
