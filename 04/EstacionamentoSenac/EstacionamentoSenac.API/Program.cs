using EstacionamentoSenac.API.Controllers.Data;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoSenac.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=EstacionamentoSenacDB;Trusted_Connection=True;";

            builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddCors(options =>
            {

                options.AddPolicy("Permitir tudo", policy =>
                
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
            });

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors("Permitir tudo");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
