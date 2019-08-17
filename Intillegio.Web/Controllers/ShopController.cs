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

        public IActionResult Products()
        {
            var allProducts = _shopService.GetAllProducts();
            return this.View(allProducts);
        }

        public IActionResult ShoppingCart()
        {
            return this.View();
        }
    }
}
