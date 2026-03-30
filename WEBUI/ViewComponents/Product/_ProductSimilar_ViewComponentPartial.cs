using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WEBUI.ViewComponents.Product
{
    public class _ProductSimilar_ViewComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductSimilar_ViewComponentPartial(IProductService productService)
        {
            _productService=productService;
        }

        public IViewComponentResult Invoke(int? Id)
        {
            var products = new List<CORE.Entities.Product>();

            if (Id == null) 
            {
                products = _productService.GetAll().Take(4).ToList();
            }
            else
            {
                products = _productService.GetAll(i => i.Id > Id).Take(4).ToList();
            }

            return View(products);
        }
    }
}
