using BLL.Abstract;
using BLL.Concrete;
using CORE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBUI.EmailService;
using WEBUI.Models;

namespace WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IContactService _contactService;
        private readonly IMailService _mailService;

        public HomeController(IProductService productService,IContactService contactService,IMailService mailService)
        {
            _productService=productService;
            _contactService = contactService;
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var model = _contactService.GetById();
            return View(model);
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _productService.GetOne(id);
            if (product == null) 
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult SendMail(EmailService.Mail mail)
        {
            if (ModelState.IsValid)
            {
                string body = $"Sayın ilgili,<br>{mail.Name} isimli kullanıcı {mail.Subject} konusunda bilgi almak istiyor.<br>Mesaj:{mail.Message} Cevaplamak için <a href='{mail.Email}'> adresinden cevaplayabilirsiniz";

                var result = MailHelper.SendMail(body, "altanemre1989@gmail.com", mail.Subject);
                if (result)
                {
                    TempData["message"] = "Emailiniz Başarıyla Gönderilmiştir. En kısa sürede dönüş yapılacaktır.";
                    return RedirectToAction("Contact");
                }
                else
                {
                    TempData["message"] = "Emailiniz Gönderme İşlemi Başarısız. Lütfen tekrar deneyiniz.";
                    return View(mail);
                }
            }

            return View(mail);
        }

        public IActionResult News(string email)
        {
            var model = _mailService.SendMail(email);

            return RedirectToAction("Index");
        }
    }
}
