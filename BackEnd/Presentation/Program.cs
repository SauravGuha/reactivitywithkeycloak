
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Persistence;
using Presentation.Middleware;
using System.Reflection;

namespace Presentation
{
    /// <summary>
    /// Startup class for the Reactivity App API application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Reactivity App API",
                    Version = "v1",
                    Description = "An API for managing reactive activities and user presence.",
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            builder.Services.AddCors(options =>
            {
                var whiteListed = builder.Configuration.GetSection("CorsOrigins").Get<string[]>() ?? [];
                options.AddDefaultPolicy(pb =>
                {
                    pb.AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials()
                      .WithOrigins(whiteListed);
                });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {
                jwtOptions.Authority = builder.Configuration.GetSection("Jwt:issuer").Value;
                jwtOptions.Audience = builder.Configuration.GetSection("Jwt:audience").Value;
                if (builder.Configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value == "Development")
                {
                    jwtOptions.RequireHttpsMetadata = false;
                }
            });
            builder.Services.AddAuthorization(authorizationOptions =>
            {
                var defaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                authorizationOptions.DefaultPolicy = defaultPolicy;
            });
            builder.Services.AddMiddleWareService();
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistence(builder.Configuration);

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            app.UseAppMiddleware();
            app.UseCors();
            if (!app.Environment.IsDevelopment())
                app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers().RequireAuthorization();

            app.Services.InitializePersistence();

            app.Run();
        }
    }
}
