using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MERAS.Models
{
	public class Supervisor
    {
		public int ID { get; set; }

		[Required]
		[StringLength(45)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[StringLength(45)]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[StringLength(2)]
		public string DepartmentID { get; set; }

		[Phone]
		public string Phone { get; set; }

		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Display(Name = "Full Name")]
		public string FullName
		{
			get { return LastName + ", " + FirstName; }
		}
		/*
		 * Navigation Property
		 */
		public Department Department { get; set; }
		public ICollection<Student> Students { get; set; }

	}
}
