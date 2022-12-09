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

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<BrzoDoLokacijeDbContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("Database")));


            builder.Services.AddScoped<IPostManager, PostManager>();
            builder.Services.AddSingleton<ITokenManager, TokenManager>();

            var app = builder.Build();
            app.Urls.Add(builder.Configuration.GetSection("Service").Get<string>());

            if (app.Environment.IsDevelopment())
            {

            }

            app.UseHttpsRedirection();

            app.Lifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine("Application stopping");
                var serviceDescriptor = builder.Services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(BrzoDoLokacijeDbContext));
                builder.Services.Remove(serviceDescriptor);
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}