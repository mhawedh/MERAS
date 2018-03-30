using Microsoft.EntityFrameworkCore;
using MERAS.Models;

namespace MERAS.Data
{
	public class MerasContext : DbContext
	{
		public MerasContext(DbContextOptions<MerasContext> options) : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Supervisor> Supervisors { get; set; }
		public DbSet<Internship> Internships { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<ApplyForList> ApplyForLists { get; set; }

		/* To specify singular table names, add the following highlighted code: */
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().ToTable("Student");
			modelBuilder.Entity<Supervisor>().ToTable("Supervisor");
			modelBuilder.Entity<Internship>().ToTable("Internship");
			modelBuilder.Entity<Company>().ToTable("Company");
			modelBuilder.Entity<Department>().ToTable("Department");
			modelBuilder.Entity<ApplyForList>().ToTable("ApplyForList");
		}
		
	}
}
