using System;
using System.Linq;
using DietaApp.Core;
using DietaApp.Core.Interfaces;
using DietaApp.Database;
using Microsoft.AspNetCore.Mvc;

namespace DietaApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IManager mManager;
        private readonly ViewModelMapper mViewModelMapper;
        private readonly DietaAppDbContext _dietaAppDbContext;


        public ProductController(IManager Manager, ViewModelMapper viewModelMapper, DietaAppDbContext dietaAppDbContext)
        {
            mManager = Manager;
            mViewModelMapper = viewModelMapper;
            _dietaAppDbContext = dietaAppDbContext;
        }

        public IActionResult NavigationOfProducts(string filterString)
        {
            var productsDtos = mManager.GetAllProducts(filterString);
            var productViewModel = mViewModelMapper.Map(productsDtos);

            return View(productViewModel);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productVm)
        {
            var existingDish = _dietaAppDbContext
                    .Products
                    .Where(i => i.Name == productVm.Name).FirstOrDefault();


            if (existingDish != null || productVm.Name == null)
            {
                ViewBag.not = true;
                return View("AddProduct");

            }
            var dto = mViewModelMapper.Map(productVm);
            //mManager.AddNewProduct(dto);

            if (ModelState.IsValid)
            {
                mManager.AddNewProduct(dto);
                //return RedirectToAction("NavigationOfProducts");
                ConfirmationViewModel confirmationViewModel = new ConfirmationViewModel
                {
                    name = "produkt.",
                    table = "Produktami",
                    controler = "Product",
                    method = "NavigationOfProducts"

                };
                return RedirectToAction("Confirmation", "Home", confirmationViewModel);
            }

            return View("AddProduct");

        }

        public IActionResult View(int productId)
        {

            return RedirectToAction("Index", "Product", new { productId = productId });
        }

        public IActionResult Delete(int productId)
        {

            mManager.DeleteProduct(new ProductDto { Id = productId });

            var productDtos = mManager.GetAllProducts(null);
            var productViewModels = mViewModelMapper.Map(productDtos);
            return View("NavigationOfProducts", productViewModels);
        }


    }
}
