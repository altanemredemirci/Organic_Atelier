using System.ComponentModel.DataAnnotations;

namespace WEBUI.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email zorunludur.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
