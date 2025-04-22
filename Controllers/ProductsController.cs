using coffeeshop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace coffeeshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IActionResult Shop()
        {
            var products = _productRepo.GetAllProducts();
            return View(products);
        }
    }
}
