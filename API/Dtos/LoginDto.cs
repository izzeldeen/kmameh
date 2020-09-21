using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class LoginDto
    {
      
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
        ErrorMessage = "The Password should be One Upper case one lower Case , non alphanumeric and at least 6 characters ")]
        public string  Password { get; set; }
    }
}