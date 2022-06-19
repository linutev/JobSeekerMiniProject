using System;
using System.ComponentModel.DataAnnotations;

namespace JobSeekerMiniProject.Models
{
	public class JobSeekerViewmodel
	{
		[Required(ErrorMessage = "Please enter your full name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter your email.")]
		[EmailAddress]
		[MaxLength(100, ErrorMessage = "Exceeded max length.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter your phone.")]
		[RegularExpression(@"[0-9]+", ErrorMessage = "Please enter a valid phone number.")]
		[MinLength(9, ErrorMessage = "Please enter a valid phone number.")]
		[MaxLength(12, ErrorMessage = "Exceeded max length.")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please enter your address.")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please enter your skills.")]
		public string Skills { get; set; }
	}
}

