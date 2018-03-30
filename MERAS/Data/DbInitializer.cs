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

			var supervisor = new Supervisor[]
			{
			new Supervisor{LastName="Awedh", FirstName="Mohammad", DepartmentID="EE", Email="mhawedh@kau.edu.sa", Phone="0555031660"}
			};
			foreach (Supervisor d in supervisor)
			{
				context.Supervisors.Add(d);
			}
			context.SaveChanges();

			var company = new Company[]
			{
			new Company{Name="Company A", ContactPhone="0544444433",  ContactEmail="contact@companya.com", ContactFirstName="conactA", ContactLastName="CompanyA", Address="Jeddah, SA"}
			};

			foreach (Company d in company)
			{
				context.Companies.Add(d);
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
