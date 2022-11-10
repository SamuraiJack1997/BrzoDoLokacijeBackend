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
        public Task<ActionResult<IEnumerable<Post>>> FetchAllPosts();
        public Task<int> AddNewPost(Post post);
        public Task<int> DeletePost(Post post);
    }
}
