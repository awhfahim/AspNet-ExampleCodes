using System.ComponentModel.DataAnnotations;

namespace BrainStationAssignment.Models
{
    public class UserRegistrationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName Must Be Unique"), Length(5,12)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
    }
}
