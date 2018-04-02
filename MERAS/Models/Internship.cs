using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MERAS.Models
{
	public class Internship
	{

		[Display(Name = "Internships ID")]
		public int ID { get; set; }

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

		[Display(Name = "Start Date")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }

		[Display(Name = "Finish Date")]
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
		/*
		 * Navigation Property
		 */
		public Company Company { get; set; }

		//public ICollection<Student> Students { get; set; }

		public ICollection<Department> Departments { get; set; }

		// Navigation Property
		public ICollection<ApplyForList> ApplyForLists { get; set; }

	}
}