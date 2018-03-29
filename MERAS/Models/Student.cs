using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERAS.Models
{
    public class Student
    {
		[Display(Name = "Student ID")]
		public int ID { get; set; }

		[Required]
		[StringLength(45)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[StringLength(45, ErrorMessage = "First name cannot be longer than 45 characters.")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		
		public int CreditHrs { get; set; }

		// Foreign Key
		public int SupervisorID { get; set; }

		// Foreign Key
		public int DepartmentID { get; set; }

		public int AssignedInternshipID { get; set; }

		[Phone]
		public int Phone { get; set; }

		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Display(Name = "Full Name")]
		public string FullName
		{
			get
			{
				return LastName + ", " + FirstName;
			}
		}
		/*
		 * Navigation Property
		 */
		public Supervisor Supervisor { get; set; }

		public Department Department { get; set; }

		public ICollection<ApplyForList> ApplyForLists { get; set; }

		
	}
}
