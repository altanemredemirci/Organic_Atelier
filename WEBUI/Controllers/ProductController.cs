using AutoMapper;
using BLL.Abstract;
using CORE.DTOs.Product;
using CORE.Entities;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Services;

namespace WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,ICategoryService categoryService,IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View(new CreateProductDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO createProductDTO, IFormFile[] files)
        {
            if (ModelState.IsValid)
            {
                Product p = _mapper.Map<Product>(createProductDTO);
                if (files != null)
                {
                    foreach (IFormFile item in files)
                    {
                        p.Images.Add(new Image() { Url = await ImageOperations.UploadImagesAsync(item) });
                    }
                }

                p.CreatedDate = DateTime.Now;
                _productService.Create(p);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(createProductDTO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Bir Ürün Seçiniz";
                return RedirectToAction("Index");
            }

            var product = _productService.GetOne(id.Value);

            if (product == null) 
            {
                TempData["message"] = "Seçili Ürün Bulunamadı.";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(_mapper.Map<UpdateProductDTO>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductDTO updateProductDTO, IFormFile[] files, int[] ImageId)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetOne(updateProductDTO.Id);
                var oldImages = new List<Image>();
                updateProductDTO.Images = product.Images;

                if (files != null)
                {
                    foreach (var imageId in ImageId) 
                    {
                        var Img = product.Images.Where(i => i.Id == imageId).FirstOrDefault();
                        oldImages.Add(Img);
                        ImageOperations.DeleteImage(Img.Url);
                        updateProductDTO.Images.Remove(Img);
                    }
                    

                    foreach (IFormFile item in files)
                    {
                        updateProductDTO.Images.Add(new Image() { Url = await ImageOperations.UploadImagesAsync(item) });
                    }
                }
                updateProductDTO.ModifiedDate = DateTime.Now;

                product = _mapper.Map<Product>(updateProductDTO);
                _productService.Update(product, oldImages);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(updateProductDTO);
        }

        public IActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}
