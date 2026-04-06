using System.ComponentModel.DataAnnotations;

namespace WEBUI.Models
{
    public class ResetPasswordViewModel
    {
        public string token { get; set; }
        public string userId { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Yeni Şifre Doğrulama")]
        [Compare("NewPassword")]
        public string ReNewPassword { get; set; }
    }
}
