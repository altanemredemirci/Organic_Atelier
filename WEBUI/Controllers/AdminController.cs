using Microsoft.AspNetCore.Mvc;

namespace WEBUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
