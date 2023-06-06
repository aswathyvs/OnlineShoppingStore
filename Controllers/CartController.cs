using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.CrossCuttingConcerns.Shared.General.Constants;
using OnlineShoppingStore.Data.Repository;
using OnlineShoppingStore.Infrastructure;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Models.ViewModels;

namespace OnlineShoppingStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product> _productRepository;

        public CartController(ILogger<HomeController> logger,
            IRepository<Product> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                Total = cart.Sum(x => x.Quantity * x.Price),
                DiscountTotal = cart.Sum(x => x.DiscountedAmount),
                GrandTotal= cart.Sum(x => x.Quantity * x.DiscountedPrice)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> Add(Guid id)
        {
            Product product = _productRepository.GetById(m => m.Id == id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            CalculateDiscountedPrice();

            TempData["Success"] = "The product has been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }


        public async Task<IActionResult> Decrease(Guid id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            CalculateDiscountedPrice();

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            CalculateDiscountedPrice();

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }

        private void CalculateDiscountedPrice()
        {
            List<CartItem> newCart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var grandTotal = 0M;
            grandTotal += newCart.Sum(x => x.Quantity * x.Price);

            newCart.ForEach(cartItem =>
            {
                if (grandTotal > OnlineShoppingStoreConstants.AmountApplicableforDiscount)
                {
                    cartItem.DiscountedPrice = cartItem.Price - (cartItem.Price * cartItem.Discount / 100);
                    cartItem.DiscountedAmount = cartItem.Price * cartItem.Discount / 100;

                }
                else
                {
                    cartItem.DiscountedPrice = cartItem.Price;
                    cartItem.DiscountedAmount = 0.00M;

                }
            });

            HttpContext.Session.SetJson("Cart", newCart);
        }
    }
}
