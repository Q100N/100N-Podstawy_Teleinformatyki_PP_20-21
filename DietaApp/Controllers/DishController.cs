using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietaApp.Core;
using DietaApp.Core.Dtos;
using DietaApp.Core.Interfaces;
using DietaApp.Database;
using DietaApp.Database.Entities;
using DietaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
namespace DietaApp.Controllers
{
    public class DishController : Controller
    {
        private readonly IManager mManager;
        private readonly ViewModelMapper mViewModelMapper;
        private readonly DietaAppDbContext _dietaAppDbContext;


        public DishController(IManager Manager, ViewModelMapper viewModelMapper, DietaAppDbContext dietaAppDbContext)
        {
            mManager = Manager;
            mViewModelMapper = viewModelMapper;
            _dietaAppDbContext = dietaAppDbContext;
        }

        public IActionResult NavigationOfDishes(string filterString)
        {

        
            try
            {
                var CurrentList = _dietaAppDbContext
                        .Dishes
                        .Include(pID => pID.ProductsInDish)
                        .ThenInclude(p => p.Product)
                        .ToList();
                if (!string.IsNullOrEmpty(filterString))
                {
                    CurrentList = _dietaAppDbContext
                     .Dishes
                     .Where(i => i.Name.Contains(filterString))
                     .Include(pID => pID.ProductsInDish)
                     .ThenInclude(p => p.Product)
                     .ToList();
                }

                Dictionary<string, int> sumKcalInlDish = new Dictionary<string, int>();
                Dictionary<string, int> IdOfDishes = new Dictionary<string, int>();

                foreach (var item in CurrentList)
                {
                    var NameOfDish = _dietaAppDbContext
                    .Dishes
                    .Where(m => m.Name == item.Name)
                    .FirstOrDefault();
                    int idDish = NameOfDish.Id;
                    IdOfDishes.Add(item.Name, idDish);
                    //sumKcalInlDish.Add(item.Name, product.Product.Kcal);
                    var productsInDish = item.ProductsInDish;
                    int temp = 0;
                            foreach (var product in productsInDish)
                            {
                        if (product.ProductWeight < 100)
                        {
                            int x = product.ProductWeight;
                            float kcal1 = Convert.ToSingle(product.Product.Kcal) * (Convert.ToSingle(x) / 100);
                            temp += Convert.ToInt32(kcal1);
                        }
                        else
                        {
                            int kcal = (product.Product.Kcal) * (product.ProductWeight / 100);
                            temp += kcal;
                        }

                                //sumKcalInlDish[item.Name] = temp;

                    }
                    sumKcalInlDish.Add(item.Name, temp);

                }

                DishViewModel dictionaryViewModel = new DishViewModel
                {
                    sumKcalInDish = sumKcalInlDish,
                    IdOfDish = IdOfDishes
                };
                return View(dictionaryViewModel);
            }
            catch (NullReferenceExeption ex)
            {
                return NotFound(ex);
            }
        }



        public ActionResult Index()
        {

            ViewBag.ProductId = new SelectList(_dietaAppDbContext.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDishh(string dishName, List<Dish3Dto> products)
        {
            var existingDish = _dietaAppDbContext
                    .Dishes
                    .Where(i => i.Name == dishName).FirstOrDefault();


            if (existingDish != null || dishName == null)
            {

                throw new Exception("Danie o tej nazwie już istnieje");

            }
            int DishId;
            var dish = new Dish
            {
                Name = dishName
            };

            _dietaAppDbContext.Add<Dish>(dish);
            _dietaAppDbContext.SaveChanges();
            DishId = dish.Id;


            List<int> IdproductsList = new List<int>();
            foreach (var product in products)
            {
                IdproductsList.Add(Int32.Parse(product.productName));
            }
            for (int i = 0; i < products.Count(); i++)
            {
                var bindingsTable = new ProductsInDish
                {
                    DishId = DishId,
                    ProductWeight = products[i].weight,
                    ProductId = IdproductsList[i]
                };

                _dietaAppDbContext.Add<ProductsInDish>(bindingsTable);
                _dietaAppDbContext.SaveChanges();



            }
            return RedirectToAction("NavigationOfDishes", "Dish");
        }



        [HttpGet]
        public async Task<IActionResult> AddDish(ProductListVM model)
        {


            if (model != null)
            {
                ProductListVM returnProduct = new ProductListVM
                {


                    products = new List<Product>(
                        await _dietaAppDbContext.Products.ToListAsync()),
                    Products = new SelectList(
                        await _dietaAppDbContext.Products.OrderBy(d => d.Name).ToListAsync(), "Id", "Name")
                };
                return View(returnProduct);
            }
            else if (model.ProductId != null)
            {
                RedirectToAction("test", "Meal");
            }
            else
            {
                return NotFound();
            }
            return NotFound();
        }
        public IActionResult test()
        {
            return View();
        }
        public IActionResult AddDish()
        {


            return View();
        }

        [HttpPost]
        public IActionResult AddDish(DishViewModel dishVm)
        {
            var dto = mViewModelMapper.Map(dishVm);
            mManager.AddNewDish(dto);
            return View("AddDish");
        }

        [Route("/Dish/DeleteDish/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            mManager.DeleteDish(new DishDto { Id = dishId });
            //var dishDtos = mManager.GetAllDishes(null);
            //var dishViewModels = mViewModelMapper.Map(dishDtos);
            return RedirectToAction("NavigationOfDishes");

        }

        /*[HttpGet]
        public async Task<IActionResult> ListOfProductsInDish(string dishId)
        {
            int IdDish = Int32.Parse(dishId);
            DishViewModel currentDish;
            try
            {
                if (dishId == null)
                {
                    return NotFound();
                }

                else
                {

                    var dishDtos = mManager.GetAllDishes(null);
                    currentDish = mViewModelMapper.Map(dishDtos).ToList().Where(x => x.Id == IdDish).FirstOrDefault(); ;
                    var productsDto = mManager.GetAllProducts(null);
                    var productsViewModel = mViewModelMapper.Map(productsDto).ToList();


                    var productsInDishDto = mManager.GetAllProductsInDish(null);
                    var productsInDishViewModel = mViewModelMapper.Map(productsInDishDto).ToList().Where(x => x.DishId == IdDish).ToList();
                    foreach (var product in productsInDishViewModel)
                    {
                        product.Product = productsViewModel.Where(x => x.Id == product.ProductId).FirstOrDefault();
                    }

                    //currentMeal = mealViewModels.Where(x=>x.Id == IdMeal)[IdMeal];
                    currentDish.productsInDish = productsInDishViewModel;

                };
                return View(currentDish);
            }
            catch (NullReferenceExeption ex)
            {
                return NotFound(ex);
            }
        }*/


        [HttpGet]
        public IActionResult ListOfProducts(string filterString)
        {
            var dishDtos = mManager.GetAllDishes(filterString);
            var dishViewModels = mViewModelMapper.Map(dishDtos);

            return View(dishViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> ListOfProductsInDish(int dishId)
        {
            /* int MealName = Int32.Parse(mealName);*/
            DishViewModel currentDish;
            try
            {
                if (dishId == null)
                {
                    return NotFound();
                }

                else
                {
                    var CurrentList = await _dietaAppDbContext
                    .Dishes
                    .Where(d => d.Id == dishId)
                    .Include(pID => pID.ProductsInDish)
                    .ThenInclude(p => p.Product)
                    .ToListAsync();

                    List<string> getAllCategory = new List<string>();
                    List<string> getAllName = new List<string>();
                    List<int> getAllKcal = new List<int>();
                    List<string> getAllUnit = new List<string>();
                    List<int> getAllProductWeight = new List<int>();
                    var dishName = CurrentList.FirstOrDefault().Name;
                    foreach (var item in CurrentList)
                    {
                        var productsInDish = item.ProductsInDish;
                        foreach (var product in productsInDish)
                        {
                            getAllCategory.Add(product.Product.Category);
                            getAllName.Add(product.Product.Name);
                            getAllKcal.Add(product.Product.Kcal);
                            getAllUnit.Add(product.Product.Unit);
                            getAllProductWeight.Add(product.ProductWeight);

                        }
                    }


                    currentDish = new DishViewModel
                    {
                        Name = dishName,
                        getCategory = getAllCategory,
                        getName = getAllName,
                        getKcal = getAllKcal,
                        getUnit = getAllUnit,
                        getProductWeight = getAllProductWeight
                    };

                    //foreach (var prodWeidght in currentDish.ProductsInDish)
                    //{
                    //    foreach(var kcal in currentDish.)
                    //    if (prodWeidght.Product.Name == kcal.)
                    //    prodWeidght.ProductWeight
                    //}
                    return View(currentDish);
                };
                return View();
            }
            catch (NullReferenceExeption ex)
            {
                return NotFound(ex);
            }
        }



    }

    //29.01
    //[HttpGet]
    //    public async Task<IActionResult> ListOfProductsInDish(int dishId)
    //    {
    //        /* int MealName = Int32.Parse(mealName);*/
    //        DishViewModel currentDish;
    //        try
    //        {
    //            if (dishId == null)
    //            {
    //                return NotFound();
    //            }

    //            else
    //            {
    //                var CurrentList = await _dietaAppDbContext
    //                .Dishes
    //                .Where(d=>d.Id==dishId)
    //                .Include(pID => pID.ProductsInDish)
    //                .ThenInclude(p => p.Product)
    //                .ToListAsync();

    //                List<string> getAllCategory = new List<string>();
    //                List<string> getAllName = new List<string>();
    //                List<int> getAllKcal = new List<int>();
    //                List<string> getAllUnit = new List<string>();

    //                foreach (var item in CurrentList)
    //                {
    //                    var productsInDish = item.ProductsInDish;
    //                    foreach (var product in productsInDish)
    //                    {
    //                        getAllCategory.Add(product.Product.Category);
    //                        getAllName.Add(product.Product.Name);
    //                        getAllKcal.Add(product.Product.Kcal);
    //                        getAllUnit.Add(product.Product.Unit);

    //                    }
    //                }


    //                currentDish = new DishViewModel
    //                {
    //                    getCategory = getAllCategory,
    //                    getName = getAllName,
    //                    getKcal = getAllKcal,
    //                    getUnit =getAllUnit
    //                };
    //                return View(currentDish);
    //            };
    //            return View();
    //        }
    //        catch (NullReferenceExeption ex)
    //        {
    //            return NotFound(ex);
    //        }
    //    }



    //}

    //public IActionResult NavigationOfDishes(string filterString)
    //{
    //    MealViewModel currentDish;
    //    try
    //    {
    //        var CurrentList = _dietaAppDbContext
    //            .Dishes
    //            .Include(pID => pID.ProductsInDish)
    //            .ThenInclude(p => p.Product)
    //            .ToList();
    //        int temp = 0;
    //        Dictionary<string, int> sumKcalInlDish = new Dictionary<string, int>();
    //        Dictionary<string, int> IdOfDishes = new Dictionary<string, int>();
    //        foreach (var item in CurrentList)
    //        {
    //            var productsInDish = item.ProductsInDish;
    //            foreach (var product in productsInDish)
    //            {
    //                if (sumKcalInlDish.ContainsKey(item.Name))
    //                {
    //                    int actualyValueInDictionary = sumKcalInlDish[item.Name];
    //                    int kcal = product.Product.Kcal;
    //                    temp = actualyValueInDictionary + kcal;
    //                    sumKcalInlDish[item.Name] = temp;
    //                }
    //                else
    //                {
    //                    var DishOfName = _dietaAppDbContext
    //                        .Dishes
    //                        .Where(m => m.Name == item.Name)
    //                        .FirstOrDefault();
    //                    int idDish = DishOfName.Id;
    //                    IdOfDishes.Add(item.Name, idDish);
    //                    sumKcalInlDish.Add(item.Name, product.Product.Kcal);
    //                }
    //            }
    //        }
    //        DishViewModel dictionaryViewModel = new DishViewModel
    //        {
    //            sumKcalInDish = sumKcalInlDish,
    //            IdOfDish = IdOfDishes
    //        };
    //        return View(dictionaryViewModel);
    //    }
    //    catch (NullReferenceExeption ex)
    //    {
    //        return NotFound(ex);
    //    }
    //}
}





