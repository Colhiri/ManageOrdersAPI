using ManageOrdersAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace ManageOrdersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ManageOrdersDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // builder.WebHost.ConfigureKestrel(serverOptions =>
            // {
            //     serverOptions.ListenAnyIP(5001, listenOptions =>
            //     {
            //         listenOptions.UseHttps();
            //     });
            // 
            //     serverOptions.ListenLocalhost(5001, listenOptions =>
            //     {
            //         listenOptions.UseHttps();
            //     });
            // });
            // builder.WebHost.UseKestrel();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.MapControllers();

            app.Run();
        }
    }
}