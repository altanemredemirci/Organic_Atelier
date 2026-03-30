using System.ComponentModel.DataAnnotations;

namespace WEBUI.EmailService
{
    public class Mail
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(150)]
        public string Subject { get; set; }

        [StringLength (500)]
        public string Message { get; set; }
    }
}
