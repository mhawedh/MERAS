using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
			
		public int DepartmentID { get; set; }

		[Phone]
		public int Phone { get; set; }

		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Display(Name = "Full Name")]
		public string FullName
		{
			get { return LastName + ", " + FirstName; }
		}

		public Department Department { get; set; }
		public ICollection<Student> Students { get; set; }

	}
}
