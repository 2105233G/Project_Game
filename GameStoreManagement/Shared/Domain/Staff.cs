using GameStoreManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreManagement.Shared.Domain
{
    public class Staff : BaseDomainModel, IValidatableObject
    {

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name does not meet length requirements")]
        public string? Name { get; set; }
        [Required]
        [RegularExpression(@"^[STFGstfg]\d{7}[A-Za-z]", ErrorMessage = "NRIC does not meet NRIC requirements")]
        public string? NRIC { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string? Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DOB.HasValue)
            {
                DateTime currentDate = DateTime.Now;
                int age = currentDate.Year - DOB.Value.Year;

                // Check if the staff is younger than 16 years old
                if (age < 16)
                {
                    yield return new ValidationResult("Staff must be 16 years old or above.", new[] { nameof(DOB) });
                }
            }
        }
    }
}
