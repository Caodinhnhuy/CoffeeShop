using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(ShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var items = _shoppingCartRepository.GetAllShoppingCartItems();
            _shoppingCartRepository.ShoppingCartItems = items;
            
            ViewBag.TotalCart = _shoppingCartRepository.GetShoppingCartTotal();
            
            return View(items);
        }

        public RedirectToActionResult AddToShoppingCart(int pId)
        {
            var product = _productRepository.GetProductDetail(pId);

            if (product != null)
            {
                _shoppingCartRepository.AddToCart(product);
                int cartCount = _shoppingCartRepository.GetAllShoppingCartItems().Count();
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pId)
        {
            var product = _productRepository.GetProductDetail(pId);

            if (product != null)
            {
                _shoppingCartRepository.RemoveFromCart(product);
                int cartCount = _shoppingCartRepository.GetAllShoppingCartItems().Count();
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }
    }
}
