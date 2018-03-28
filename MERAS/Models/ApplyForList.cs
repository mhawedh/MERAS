using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERAS.Models
{
    public class ApplyForList
    {
		// ApplyForList ID
		public int ID { get; set; }

		public int StudentID { get; set; }

		public int InternshipID { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ApplyDate { get; set; }


		public Student Student { get; set; }

		public Internships Internships { get; set; }
	}
}
