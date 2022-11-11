using DemoProjekatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjekatAPI.Logic.PostLogic
{
    public interface IPostManager
    {
        public Task<int> UpdatePost(Post post, int userId);
        public Task<ActionResult<IEnumerable<Post>>> GetAllPosts();
        public Task<int> AddNewPost(Post post);
        public Task<int> DeletePost(Post post);
        public Task<Post> GetPostById(int postId);
        public Task<ActionResult<IEnumerable<Post>>> GetPostByUser(int userId);
        public Task<int> GetPostLikeNumber(int postId);
        public Task<bool> LikeOrDislikePost(int postId, int userId);
    }
}
