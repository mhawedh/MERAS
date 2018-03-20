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

		[Phone]
		public int Phone { get; set; }

		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }
	}
}
