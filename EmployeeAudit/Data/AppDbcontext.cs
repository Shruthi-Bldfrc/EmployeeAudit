using EmployeeAudit.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAudit.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<EmployeeAuditTable> EmployeeAudits { get; set; }
	}
}
