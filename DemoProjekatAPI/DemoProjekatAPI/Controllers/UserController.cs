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
    public class UserController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public UserController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetSecurityTypes()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Login(User user)
        {
            var successfulLogin = await _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefaultAsync();
            if (successfulLogin == null)
                return false;
            else
                return true;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddNewUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

    }
}
