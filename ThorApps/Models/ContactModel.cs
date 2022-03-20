using System.ComponentModel.DataAnnotations;

namespace ThorApps.Models
{
    public class ContactModel
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required,EmailAddress(ErrorMessage ="Enter a valid email address")]
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage ="Type your message")]
        [MinLength(150,ErrorMessage ="Type at least 150 characters")]
        public string Message { get; set; }
    }
}
