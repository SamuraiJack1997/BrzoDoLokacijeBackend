using DemoProjekatAPI.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjekatAPI.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private List<Token> tokenList;
        private readonly IServiceScopeFactory _scopeFactory;

        public TokenManager(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            tokenList = new List<Token>();
        }

        public bool Authenticate(string username, byte[] password)
        {
            if (username != "" && password.Length>0)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<BrzoDoLokacijeDbContext>();
                    var user = context.Users.Where(x => x.Username == username && x.Hash == password).FirstOrDefault();
                    return user != null;
                }
            }
            return false;
        }

        public Token GenerateToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddDays(7)
            };
            tokenList.Add(token);
            return token;
        }

        public bool VerifyToken(string token)
        {
            Console.WriteLine("Token:"+token);
            Console.WriteLine("Tokens:");
            foreach(var t in tokenList)
                Console.WriteLine(t.Value);

            return tokenList.Any(x => x.Value == token);
        }
    }
}
