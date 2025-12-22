
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Step1_Backend.Helpers;
using Step1_Backend.Models;
using System.Text;

namespace Step1_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(
    options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
               var key = builder.Configuration["JwtSettings:Key"];
               var secrectKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   IssuerSigningKey = secrectKey,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                   ValidAudience = builder.Configuration["JwtSettings:Audience"],
               };
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
