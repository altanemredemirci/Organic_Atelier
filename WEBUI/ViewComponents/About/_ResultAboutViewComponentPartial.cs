using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WEBUI.ViewComponents.About
{
    public class _ResultAboutViewComponentPartial:ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _ResultAboutViewComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var about = _aboutService.GetOne();

            return View(about);
        }
    }
}
