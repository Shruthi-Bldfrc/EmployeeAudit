
using EmployeeAudit.Data;
using EmployeeAudit.RepositoryLayer.RepositoryDeclarations;
using EmployeeAudit.RepositoryLayer.RepositoryImplementations;
using EmployeeAudit.ServiceLayer.ServicesDeclaration;
using EmployeeAudit.ServiceLayer.ServicesImplementataion;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAudit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeAuditDatabase")));

			builder.Services.AddControllers();
			builder.Services.AddScoped<IEmployeeService, EmployeeService>();
			builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
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


            app.MapControllers();

            app.Run();
        }
    }
}
