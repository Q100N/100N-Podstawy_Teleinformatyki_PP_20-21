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
    public class MealController : Controller
    {
        private readonly IManager mManager;
        private readonly ViewModelMapper mViewModelMapper; //Mapowanie z Dto na VieModel
        private readonly DietaAppDbContext _dietaAppDbContext;


        public MealController(IManager Manager, ViewModelMapper viewModelMapper, DietaAppDbContext dietaAppDbContext)
        {
            mManager = Manager;
            mViewModelMapper = viewModelMapper;
            _dietaAppDbContext = dietaAppDbContext;
        }

        public IActionResult NavigationOfMeals(string filterString)
        {
            try
            {
                var CurrentList = _dietaAppDbContext
                    .Meals
                    .Include(dim => dim.DishesInMeal)
                    .ThenInclude(d => d.Dish)
                    .ThenInclude(pID => pID.ProductsInDish)
                    .ThenInclude(p => p.Product)
                    .ToList();

                if (!string.IsNullOrEmpty(filterString))
                {
                    CurrentList = _dietaAppDbContext
                            .Meals
                            .Where(i => i.Name.Contains(filterString))
                            .Include(dim => dim.DishesInMeal)
                            .ThenInclude(d => d.Dish)
                            .ThenInclude(pID => pID.ProductsInDish)
                            .ThenInclude(p => p.Product)
                            .ToList();
                }

                Dictionary<string, int> sumKcalInMeal = new Dictionary<string, int>();
                Dictionary<int, string> IdOfMeals = new Dictionary<int, string>();
                foreach (var item in CurrentList)
                {
                    var NameofMeal = _dietaAppDbContext
                        .Meals
                        .Where(m => m.Name == item.Name)
                        .FirstOrDefault();
                    int idMeal = NameofMeal.Id;
                    IdOfMeals.Add(idMeal, item.Name);
                    //sumKcalInlDish.Add(item.Name, product.Product.Kcal);
                    var dishInMeal = item.DishesInMeal;
                    int temp = 0;
                    foreach (var dish in dishInMeal)
                    {
                        var productsInDish = dish.Dish.ProductsInDish;

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
                        }
                        
                    }
                    sumKcalInMeal.Add(item.Name, temp);
                }
                MealViewModel dictionaryViewModel = new MealViewModel
                {
                    sumKcalInMeal = sumKcalInMeal,
                    IdOfMeal = IdOfMeals
                };
                return View(dictionaryViewModel);
            }
            catch (NullReferenceExeption ex)
            {
                return NotFound(ex);
            }
            /*                var mealDtos = mManager.GetAllMeals(filterString);
                        var mealViewModels = mViewModelMapper.Map(mealDtos);

                        return View(mealViewModels);*/
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeall(string mealName, List<Meal2Dto> dishes)
        {

            var existingMeal = _dietaAppDbContext
                    .Meals
                    .Where(i => i.Name ==mealName).FirstOrDefault();


                if (existingMeal != null || mealName == null)
                {

                throw new Exception("Posiłek o tej nazwie już istnieje");

            }
            var meal = new Meal
                {
                    Name = mealName
                };
                _dietaAppDbContext.Add<Meal>(meal);
                _dietaAppDbContext.SaveChanges();

                int mealId = meal.Id;
                List<int> IdDishesList = new List<int>();
                foreach (var dish in dishes)
                {
                    IdDishesList.Add(Int32.Parse(dish.dishName)); ;
                }
                for (int i = 0; i < dishes.Count(); i++)
                {
                    var bindingsTable = new DishesInMeal
                    {
                        MealId = mealId,
                        DishId = IdDishesList[i]
                    };
                    _dietaAppDbContext.AddAsync<DishesInMeal>(bindingsTable);
                    _dietaAppDbContext.SaveChanges();
                    //return RedirectToAction("NavigationOfProducts");


                }
            


            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> AddMeal(DishListVm model)
        {

            if (model != null)
            {
                DishListVm retDish = new DishListVm
                {
                    dishes = new List<Dish>(
                        await _dietaAppDbContext.Dishes.ToListAsync()
                        ),
                    Dishes = new SelectList(
                        await _dietaAppDbContext.Dishes.OrderBy(m => m.Name).ToListAsync(), "Id", "Name")
                };
                return View(retDish);
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
        public IActionResult AddMeal()
        {


            return View();
        }

        [HttpPost]
        public IActionResult AddMeal(MealViewModel mealVm)
        {
            var dto = mViewModelMapper.Map(mealVm);
            mManager.AddNewMeal(dto);
            return View("AddMeal");
        }

        [HttpGet]
        public async Task<IActionResult> ListOfProductsInMeal(int mealId)
        {
            /* int MealName = Int32.Parse(mealName);*/
            MealViewModel currentMeal;
            try
            {
                if (mealId == null)
                {
                    return NotFound();
                }

                else
                {
                    var CurrentList = _dietaAppDbContext
                   .Meals
                   .Where(m => m.Id == mealId)
                   .Include(m => m.DishesInMeal)
                   .ThenInclude(d => d.Dish)
                   .ThenInclude(pID => pID.ProductsInDish)
                   .ThenInclude(p => p.Product)
                   .ToList();

                    List<string> getAllCategory = new List<string>();
                    List<string> getAllName = new List<string>();
                    List<int> getAllKcal = new List<int>();
                    List<string> getAllUnit = new List<string>();




                    foreach (var item in CurrentList)
                    {
                        var dim = item.DishesInMeal;
                        foreach (var m in dim)
                        {
                            var d = m.Dish.ProductsInDish;


                            foreach (var p in d)
                            {
                                getAllCategory.Add(p.Product.Category);
                                getAllName.Add(p.Product.Name);
                                getAllKcal.Add(p.Product.Kcal);
                                getAllUnit.Add(p.Product.Unit);
                            }
                        }

                    }
                    currentMeal = new MealViewModel
                    {
                        getCategory = getAllCategory,
                        getName = getAllName,
                        getKcal = getAllKcal,
                        getUnit = getAllUnit
                    };
                    return View(currentMeal);
                };
                return View();
            }
            catch (NullReferenceExeption ex)
            {
                return NotFound(ex);
            }
        }

        public IActionResult DeleteMeal(int mealId)
        {
            mManager.DeleteMeal(new MealDto { Id = mealId });
            //var mealDtos = mManager.GetAllMeals(null);
            //var mealViewModels = mViewModelMapper.Map(mealDtos);
            return RedirectToAction("NavigationOfMeals");

        }

        [HttpGet]
        public async Task<IActionResult> ListOfDishesInMeal(int mealId)
        {
            MealViewModel currentMeal = new MealViewModel { };
            try
            {
                var CurrentList = _dietaAppDbContext
                    .Meals
                    .Where(m => m.Id == mealId)
                    .Include(dIM => dIM.DishesInMeal)
                    .ThenInclude(d => d.Dish)
                    .ThenInclude(pID => pID.ProductsInDish)
                    .ThenInclude(p => p.Product)
                    .FirstOrDefault();


                var dishesInMellDto = mManager.GetAllDishesInMeal(null);
                currentMeal.dishesInMeal = mViewModelMapper.Map(dishesInMellDto).ToList().Where(x => x.MealId == mealId).ToList();
                currentMeal.Name = CurrentList.Name;

                Dictionary<int, int> _dishIndex = new Dictionary<int, int>();
                Dictionary<int, string> _IdOfDishes = new Dictionary<int, string>();
                Dictionary<int, int> _sumKcalInlDish = new Dictionary<int, int>();

                int i=0, k=0, l= 0;
                foreach (var dish in currentMeal.dishesInMeal)
                {
                    int temp = 0;
                    i++;
                    _dishIndex.Add(i, dish.Dish.Id);
                    //_IdOfDishes.Add(dish.Dish.Id, dish.Dish.Id);
                    _IdOfDishes.Add(i, dish.Dish.Name);
                    var dishInMeal = dish.Dish;
                    
                    foreach (var product in dishInMeal.ProductsInDish)
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
                }
                    k++;

                    _sumKcalInlDish.Add(k, temp);
                    
                }
                currentMeal._dishIndex = _dishIndex;
                currentMeal._IdOfDishes = _IdOfDishes;
                currentMeal._sumKcalInlDish= _sumKcalInlDish;

                //IdOfDish = IdOfDishes


                return View(currentMeal);
        }
                catch (NullReferenceExeption ex)
                {
                    return NotFound(ex);
    }
}





        //[HttpGet]
        //public async Task<IActionResult> ListOfDishesInMeal(string mealId)
        //{
        //    int IdMeal = Int32.Parse(mealId);
        //    MealViewModel currentMeal;
        //    try
        //    {
        //        if (mealId == null)
        //        {
        //            return NotFound();
        //        }

        //        else
        //        {

        //            var mealDtos = mManager.GetAllMeals(null);
        //            currentMeal = mViewModelMapper.Map(mealDtos).ToList().Where(x => x.Id == IdMeal).FirstOrDefault(); ;
        //            var dishesDto = mManager.GetAllDishes(null);
        //            var dishesViewModels = mViewModelMapper.Map(dishesDto).ToList();

        //            var dishesInMellDto = mManager.GetAllDishesInMeal(null);
        //            var dishesInMealViewModel = mViewModelMapper.Map(dishesInMellDto).ToList().Where(x => x.MealId == IdMeal).ToList();
        //            foreach (var dish in dishesInMealViewModel)
        //            {
        //                dish.Dish = dishesViewModels.Where(x => x.Id == dish.DishId).FirstOrDefault();
        //            }

        //            //currentMeal = mealViewModels.Where(x=>x.Id == IdMeal)[IdMeal];
        //            currentMeal.dishesInMeal = dishesInMealViewModel;

        //        };
        //            return View(currentMeal);
        //        }
        //    catch (NullReferenceExeption ex)
        //    {
        //        return NotFound(ex);
        //    }
        //}

        //public IActionResult NavigationOfMeals(string filterString)
        //{
        //    try
        //    {
        //        var CurrentList = _dietaAppDbContext
        //            .Meals
        //            .Include(dim => dim.DishesInMeal)
        //            .ThenInclude(d => d.Dish)
        //            .ThenInclude(pID => pID.ProductsInDish)
        //            .ThenInclude(p => p.Product)
        //            .ToList();
        //        int temp = 0;
        //        Dictionary<string, int> sumKcalInMeal = new Dictionary<string, int>();
        //        Dictionary<string, int> IdOfMeals = new Dictionary<string, int>();
        //        foreach (var item in CurrentList)
        //        {
        //            var dishInMeal = item.DishesInMeal;
        //            foreach (var dish in dishInMeal)
        //            {
        //                var productInDish = dish.Dish.ProductsInDish;
        //                foreach (var product in productInDish)
        //                {
        //                    if (sumKcalInMeal.ContainsKey(item.Name))
        //                    {
        //                        int actualyValueInDictionary = sumKcalInMeal[item.Name];
        //                        int kcal = product.Product.Kcal;
        //                        temp = actualyValueInDictionary + kcal;
        //                        sumKcalInMeal[item.Name] = temp;
        //                    }
        //                    else
        //                    {
        //                        var MealOfName = _dietaAppDbContext
        //                            .Meals
        //                            .Where(m => m.Name == item.Name)
        //                            .FirstOrDefault();
        //                        int idMeal = MealOfName.Id;
        //                        IdOfMeals.Add(item.Name, idMeal);
        //                        sumKcalInMeal.Add(item.Name, product.Product.Kcal);
        //                    }
        //                }
        //            }
        //        }
        //        MealViewModel dictionaryViewModel = new MealViewModel
        //        {
        //            sumKcalInMeal = sumKcalInMeal,
        //            IdOfMeal = IdOfMeals
        //        };
        //        return View(dictionaryViewModel);
        //    }
        //    catch (NullReferenceExeption ex)
        //    {
        //        return NotFound(ex);
        //    }
        //    /*                var mealDtos = mManager.GetAllMeals(filterString);
        //                var mealViewModels = mViewModelMapper.Map(mealDtos);

        //                return View(mealViewModels);*/
        //}


    }
    }

    



