using System.ComponentModel.DataAnnotations;

namespace Apprenticeship2.Data.DTO
{
    public class InsertUniversitySupervisorDTO
    {
        [Required]
        [Display(Name = "First Name")] public string firstName { get; set; }

        [Required]
        [Display(Name = "Second Name")]
        public string secondName { get; set; }

        [Required]
        [Display(Name = "Third Name")]
        public string thirdName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "University")]
        public int universityId { get; set; }

    }
}
