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

		[Display(Name = "Comany ID")]
		public int CompanyID { get; set; }
		
		[Required]
		[StringLength(45)]
		[Display(Name = "Internships Description")]
		public string FirstName { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ApplyStartDate { get; set; }
		
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ApplyFinishtDate { get; set; }
		
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }
		
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime FinishtDate { get; set; }

		
		[Required]
		[StringLength(45)]
		[Display(Name = "Country")]
		public string Country { get; set; }

		[Required]
		[StringLength(45)]
		[Display(Name = "City")]
		public string City { get; set; }

		public Company Companies { get; set; }

		//public ICollection<Student> Students { get; set; }

		public ICollection<Department> Departments { get; set; }

		// Navigation Property
		public ICollection<ApplyForList> ApplyForLists { get; set; }

	}
}
