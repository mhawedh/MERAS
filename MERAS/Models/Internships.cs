using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERAS.Models
{
    public class Internships
    {

		[Display(Name = "Internships ID")]
		public int InternshipsID { get; set; }

		[Required]
		[StringLength(45)]
		[Display(Name = "Internships Description")]
		public string FirstName { get; set; }

		public int DepartmentID { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ApplyStartDay { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ApplyFinishtDay { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime StartDay { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime FinishtDay { get; set; }
		
		[Required]
		[StringLength(45)]
		[Display(Name = "Country")]
		public string Country { get; set; }

		[Required]
		[StringLength(45)]
		[Display(Name = "City")]
		public string City { get; set; }

		public ICollection<Department> Departments { get; set; }

	}
}
