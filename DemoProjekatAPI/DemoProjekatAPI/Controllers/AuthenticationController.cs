using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DemoProjekatAPI.Models;
using DemoProjekatAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DemoProjekatAPI.TokenAuthentication;

namespace DemoProjekatAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly BrzoDoLokacijeDbContext _context;
        private readonly ITokenManager _tokenManager;

        public AuthenticationController(BrzoDoLokacijeDbContext context, ITokenManager tokenManager)
        {
            _context = context;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody]Credentials credentials)
        {
            byte[] hash;
            using (SHA256 sha = SHA256.Create())
                hash = sha.ComputeHash(Encoding.ASCII.GetBytes(credentials.Password));

            if (_tokenManager.Authenticate(credentials.Username, hash))
                return Ok(new { Token = _tokenManager.GenerateToken() });
            else
                return Unauthorized("User is unautherized");
        }

        [HttpPost("verify")]
        public IActionResult Verify([FromBody]Token token)
        {
            if (_tokenManager.VerifyToken(token.Value))
                return Ok(new { valid = true });
            else
                return Unauthorized(new { valid = false });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _context.Users.Add(user);
            byte[] hash;
            using (SHA256 sha = SHA256.Create())
            {
                hash = sha.ComputeHash(Encoding.ASCII.GetBytes(user.Password));
                user.Hash = hash;
            }
            int success = _context.SaveChanges();
            if (success > 0)
                return Authenticate(new Credentials { Username= user.Username, Password=user.Password});
            else
                return Unauthorized("Registration unsuccessful");
        }
    }
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
