using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using TokenBasedAuthenticationDemo.Application.Extensions;
using TokenBasedAuthenticationDemo.Infrastructure.Extensions;

namespace TokenBasedAuthenticationDemo.Server
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
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter proper JWT token",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.Http
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "BearerAuth"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", builder =>
            //    {
            //        builder.AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .WithOrigins("*")
            //            .AllowCredentials();
            //    });
            //});

            // Added Application layer
            builder.Services.AddApplictaion();

            // Added Infrastructure layer
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseCors("CorsPolicy");

            app.MapIdentityApi<IdentityUser>();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
