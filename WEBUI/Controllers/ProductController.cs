using BLL.Abstract;
using CORE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile[] files)
        {
            if (ModelState.IsValid)
            {

            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(product);
        }
    }
}
