
using Application;
using Persistence;
using System.Reflection;

namespace Presentation
{
    /// <summary>
    /// Startup class for the Reactivity App API application.
    /// </summary>
    public class Program
    {
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

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistence(builder.Configuration);

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            app.UseCors();
            if (!app.Environment.IsDevelopment())
                app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Services.InitializePersistence();

            app.Run();
        }
    }
}
