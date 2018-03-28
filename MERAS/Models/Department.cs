using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERAS.Models
{
    public class Department
    {
		[Display(Name = "Department ID")]
		[StringLength(2)]
		public string ID { get; set; }

		[Required]
		[StringLength(45, ErrorMessage = "First name cannot be longer than 45 characters.")]
		[Display(Name = "Department Name")]
		public string Name { get; set; }
	}
}
