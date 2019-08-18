using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Intillegio.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public ShopController(IShopService shopService, UserManager<IntillegioUser> currentUser)
        {
            _shopService = shopService;
            _currentUser = currentUser;
        }

        public IActionResult AllProducts()
        {
            var allProducts = _shopService.GetAllProducts();
            return this.View(allProducts);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var productDetails = await _shopService.GetProductDetailsAsync(id);
            if (productDetails == null)
            {
                return RedirectToAction(ActionConstants.Products);
            }

            return View("ProductDetails", productDetails);
        }

        public IActionResult ShoppingCart()
        {
            return this.View();
        }
    }
}
