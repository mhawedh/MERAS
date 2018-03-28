using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERAS.Models
{
    public class Company
    {
		[Key]
		public int ID { get; set; }

		[StringLength(45)]
		[Required]
		[Display(Name = "Company Name")]
		public string Name { get; set; }

		[StringLength(100)]
		[Required]
		[Display(Name = "Company Address")]
		public string Address { get; set; }

		[Required]
		[StringLength(45)]
		[Display(Name = "Contact Last Name")]
		public string ContactLastName { get; set; }

		[Required]
		[StringLength(45, ErrorMessage = "First name cannot be longer than 45 characters.")]
		[Display(Name = "Contact First Name")]
		public string ContactFirstName { get; set; }

		[Phone]
		public int ContactPhone { get; set; }

		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string ContactEmail { get; set; }

		// Navigation Property
		public ICollection<Internships> InternshipsList { get; set; }
		
	}
}
