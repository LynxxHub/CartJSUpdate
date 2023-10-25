using CartApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartApplication.Controllers
{
    // Controllers/CartApiController.cs
    [Route("api/cart")]
    [ApiController]
    public class CartApiController : Controller
    {

        [HttpPost("add/{productId}")]
        public IActionResult AddToCart(int productId)
        {
            var product = ShoppingController.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return NotFound();

            var cartItem = ShoppingController.Cart.FirstOrDefault(c => c.Product.Id == productId);
            if (cartItem == null)
            {
                ShoppingController.Cart.Add(new CartItem { Product = product, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity += 1;
            }

            return Ok(new { success = true, Message = "Added to cart" });
        }

        public CartApiController()
        {
            
        }

        [HttpPost("remove/{productId}")]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItem = ShoppingController.Cart.FirstOrDefault(c => c.Product.Id == productId);
            if (cartItem == null) return NotFound();

            cartItem.Quantity -= 1;
            if (cartItem.Quantity <= 0)
            {
                ShoppingController.Cart.Remove(cartItem);
            }

            return Ok(new { success = true, Message = "Removed from cart" });
        }
    }
}

