using Microsoft.EntityFrameworkCore;
using MERAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERAS.Data
{
    public class MerasContext : DbContext
	{
		public MerasContext(DbContextOptions<MerasContext> options) : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Supervisor> Supervisors { get; set; }
		public DbSet<Internships> InternshipsList { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<ApplyForList> ApplyForLists { get; set; }

		/* To specify singular table names, add the following highlighted code:
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Supervisor>().ToTable("Supervisor");
			modelBuilder.Entity<Department>().ToTable("Department");
			modelBuilder.Entity<Student>().ToTable("Student");
		}
		*/
	}
}
