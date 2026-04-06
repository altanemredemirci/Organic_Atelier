using System.ComponentModel.DataAnnotations;

namespace WEBUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name ="Ad")]
        public string FirstName { get; set; }

        [Display(Name ="Soyad")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage ="Email zorunludur.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name ="Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Şifre Doğrulama")]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}
