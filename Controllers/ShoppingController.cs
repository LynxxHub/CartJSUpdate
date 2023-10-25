using CartApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartApplication.Controllers
{
    [Route("[controller]")]
    public class ShoppingController : Controller
    {
        // Simulate in-memory list of products
        public static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Item 1", Price = 10.00M },
        new Product { Id = 2, Name = "Item 2", Price = 20.00M }
    };

        public static List<CartItem> Cart = new List<CartItem>();

        public ShoppingController()
        {
            Cart = new List<CartItem>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Products);
        }

        [HttpGet("cart")]
        public IActionResult CartView()
        {
            return View(Cart);
        }
    }
}