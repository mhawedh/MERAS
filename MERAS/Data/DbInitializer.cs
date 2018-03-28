using MERAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERAS.Data
{
	public static class DbInitializer
	{
		public static void Initialize(MerasContext context)
		{
			context.Database.EnsureCreated();

			// Look for any students.
			if (context.Students.Any())
			{
				return;   // DB has been seeded
			}

			var department = new Department[]
			{
			new Department{ID="EE", Name="Electrical and Computer Engineering"},
			new Department{ID="IE", Name="Industerial Engineering"}
			};
			foreach (Department d in department)
			{
				context.Departments.Add(d);
			}
			context.SaveChanges();

			var students = new Student[]
			{
			new Student{FirstName="Amnah",LastName="Samkari"},
			new Student{FirstName="Asmaa",LastName="Faisal"},
			new Student{FirstName="Fatimah",LastName="Bukhari"}
			};
			foreach (Student s in students)
			{
				context.Students.Add(s);
			}
			context.SaveChanges();

			
		}
	}
}
