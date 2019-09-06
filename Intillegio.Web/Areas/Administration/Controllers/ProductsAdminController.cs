using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    public class ProductsAdminController : AdminController
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

        public async Task<IActionResult> AddProduct()
        {
            var categories = await _productsService.GetAllCategories();
            var deptList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select",
                    Value = ""
                }
            };
            deptList.AddRange(categories.Select(category => new SelectListItem { Text = category.CategoryName }));
            ViewBag.Category = deptList;

            return View(GlobalConstants.AdminAreaPath + "ProductsAdmin/AddProduct.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AdminProductBindingModel model)
        {
            await _productsService.AddProductAsync(model);
           
            return RedirectToAction("ProductsAdmin");
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

        public async Task<IActionResult> EditProduct(int id)
        {
            var editDetails = await _productsService.GetProductDetailsForAdminEditAsync(id);

            return View("EditProduct", editDetails);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(int id, AdminEditProductBindingModel model)
        {
            await _productsService.ProductEditAsync(model, id);
            return RedirectToAction("ProductsAdmin");
        }
    }
}