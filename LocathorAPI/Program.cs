using DemoProjekatAPI.Data;
using DemoProjekatAPI.Logic.PostLogic;
using DemoProjekatAPI.TokenAuthentication;
using Microsoft.EntityFrameworkCore;

namespace LocathorAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<BrzoDoLokacijeDbContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("Database")));

            builder.Services.AddScoped<IPostManager, PostManager>();
            builder.Services.AddSingleton<ITokenManager, TokenManager>();

            var app = builder.Build();
            app.Urls.Add(builder.Configuration.GetSection("Service").Get<string>());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}