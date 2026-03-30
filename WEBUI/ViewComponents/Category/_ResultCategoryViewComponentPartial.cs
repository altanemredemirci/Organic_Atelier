using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WEBUI.ViewComponents.Category
{
    public class _ResultCategoryViewComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _ResultCategoryViewComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryService.GetAll());
        }
    }
}
