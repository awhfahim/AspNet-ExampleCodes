using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BootstrapThemeIntegration.Areas.Admin.Models
{
    public class UserDetails
    {
        [EmailAddress(ErrorMessage = "Please Provide An Email Address"), Required, Display(Name = "Email Address")]
        public string? Email { get; set; }
        [Required, PasswordPropertyText, MinLength(8, ErrorMessage = "Password Lenght Must be 8 or More")]
        public string? Password { get; set; }
    }
}
