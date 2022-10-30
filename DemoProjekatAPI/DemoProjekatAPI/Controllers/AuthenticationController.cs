using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DemoProjekatAPI.Models;
using DemoProjekatAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DemoProjekatAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly BrzoDoLokacijeDbContext _context;

        public AuthenticationController(BrzoDoLokacijeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("login")]
        public string Login([FromBody]Credentials credentials)
        {
            byte[] hash;
            using (SHA256 sha = SHA256.Create())
            {
                hash = sha.ComputeHash(Encoding.ASCII.GetBytes(credentials.Password));
            }
            var user = _context.Users.Where(x => x.Username == credentials.Username && x.Hash == hash).FirstOrDefault();
            if (user == null)
                return "Failed Authentication";
            else
                return "token";
        }

        [HttpPost("register")]
        public byte[] Register([FromBody] User user)
        {
            _context.Users.Add(user);
            byte[] hash;
            using (SHA256 sha = SHA256.Create())
            {
                hash = sha.ComputeHash(Encoding.ASCII.GetBytes(user.Password));
                user.Hash = hash;
            }
            int success = _context.SaveChanges();
            if (success == 0)
                return hash;
            else
                return hash;

        }
    }
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
