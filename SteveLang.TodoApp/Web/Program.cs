
using SteveLang.TodoApp.Domain.Repositories;
using SteveLang.TodoApp.Persistence;
using SteveLang.TodoApp.Services;
using SteveLang.TodoApp.Services.Interfaces;

namespace SteveLang.TodoApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string DevEnvCorsPolicy = "DevEnvCorsPolicy";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: DevEnvCorsPolicy,
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyOrigin();
                    });
            });
            builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
            builder.Services.AddTransient<ITodoService, TodoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(DevEnvCorsPolicy);
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
