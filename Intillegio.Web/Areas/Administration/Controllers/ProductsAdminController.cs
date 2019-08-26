using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ProductsAdminController : BaseController
    {
        private readonly IShopService _productsService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public ProductsAdminController(IShopService productsService, UserManager<IntillegioUser> currentUser)
        {
            _productsService = productsService;
            _currentUser = currentUser;
        }

        public IActionResult ProductsAdmin()
        {
            var allProductsForAdmin = _productsService.GetAllProductsForAdmin();

            return View(GlobalConstants.AdminAreaPath + "ProductsAdmin/ProductsAdmin.cshtml", allProductsForAdmin);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var productDetails = await _productsService.GetProductDetailsForAdminAsync(id);

            if (productDetails == null)
            {
                return RedirectToAction(ActionConstants.ProductsAdmin);
            }

            return View("ProductDetails", productDetails);
        }

        public async Task<IActionResult> DeleteProductDetails(int id)
        {
            var deleteDetails = await _productsService.GetProductDetailsForAdminAsync(id);

            return View("DeleteProduct", deleteDetails);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productsService.DeleteProductAsync(id);
            return RedirectToAction("ProductsAdmin");
        }
    }
}