using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Core.Services;
using Labb_2_Blog.Data.Interfaces;
using Labb_2_Blog.Data.Repos;
using Labb_3_Fullstack.Core.Interface;
using Labb_3_Fullstack.Core.Services;
using Labb_3_Fullstack.Data;
using Labb_3_Fullstack.Data.Interfaces;
using Labb_3_Fullstack.Data.Repos;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Labb_2_Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddCors();

            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            //Dependancy Injections Repos
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IAuctionRepo, AuctionRepo>();
            builder.Services.AddScoped<IBidRepo, BidRepo>();



            //Dependancy Injections Services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuctionService, AuctionService>();
            builder.Services.AddScoped<IBidService, BidService>();



            var app = builder.Build();

            //Konfigurerar HTTP pipelinen
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();


        }
    }
}
