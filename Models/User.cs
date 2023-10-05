using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Login_and_Registration.Data;

namespace Login_and_Registration.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name requires 2 values as minimum")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [MinLength(2, ErrorMessage = "Last name requires 2 values as minimum")]
        public String Last_Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [UniqueEmail]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(8, ErrorMessage = "Password requires 8 values as minimum")]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Compare("Password")]
        [NotMapped]
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(8, ErrorMessage = "Password requires 8 values as minimum")]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext
        )
        {
            if (value == null)
            {
                return new ValidationResult("Email is required!");
            }

            LoginContext _context = (LoginContext)
                validationContext.GetService(typeof(LoginContext));

            if (_context.Users.Any(e => e.Email == value.ToString()))
            {
                return new ValidationResult("Email must be unique!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
