
using Microsoft.AspNetCore.Mvc;
using WEBUI.EmailService;

namespace WEBUI.ViewComponents.Contact
{
    public class _SendMailViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new Mail());
        }
    }
}
