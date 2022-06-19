using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeekerMiniProject.Models
{
	[Table("JobSeeker", Schema = "dbo")]
	public class JobSeekerViewModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required(ErrorMessage = "Please enter your full name.")]
		[Column(TypeName = "varchar(255)")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter your email.")]
		[EmailAddress]
		[MaxLength(100, ErrorMessage = "Exceeded max length.")]
		[Column(TypeName = "varchar(100)")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter your phone.")]
		[RegularExpression(@"[0-9]+", ErrorMessage = "Please enter a valid phone number.")]
		[MinLength(9, ErrorMessage = "Please enter a valid phone number.")]
		[MaxLength(12, ErrorMessage = "Exceeded max length.")]
		[Column(TypeName = "varchar(14)")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please enter your address.")]
		[Column(TypeName = "varchar(255)")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please enter your skills.")]
		[Column(TypeName = "varchar(4000)")]
		public string Skills { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTimeOffset DateInserted { get; set; }
	}
}

