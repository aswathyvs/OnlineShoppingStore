using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoppingStore.Data.Repository;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public ProductsController(ILogger<HomeController> logger,
            IRepository<Category> categoryRepository,
            IRepository<Product> productRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(string categorySlug = "", int p = 1)
        {
            _logger.LogInformation($"Started list");
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categorySlug;

            if (categorySlug == "")
            {
                ViewBag.TotalPages = (int)Math.Ceiling((decimal)_productRepository.Count() / pageSize);
                var products = _productRepository.GetAll();
                return View(products.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize));
            }

            Category category = _categoryRepository.GetAll().Where(c => c.Slug == categorySlug).FirstOrDefault();
            if (category == null) return RedirectToAction("Index");

            var productsByCategory = _productRepository.GetAll().Where(p => p.CategoryId == category.Id);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)productsByCategory.Count() / pageSize);

            return View(productsByCategory.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize));
        }
    }
}
