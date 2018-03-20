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
		public int StudentID { get; set; }

		[Required]
		[StringLength(45, ErrorMessage = "First name cannot be longer than 45 characters.")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[StringLength(45)]
		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		public int CreditHrs { get; set; }

		public string Department { get; set; }

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

		//public ICollection<Enrollment> Enrollments { get; set; }
	}
}
