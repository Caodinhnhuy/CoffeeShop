using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;
        private ShoppingCartRepository shoppingCartRepository;

        public OrdersController(IOrderRepository orderRepository, ShoppingCartRepository shoppingCartRepository)
        {
            this.orderRepository = orderRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0); // Đặt lại số lượng giỏ hàng trên thanh điều hướng
            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}
