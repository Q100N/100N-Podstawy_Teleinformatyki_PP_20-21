using DietaApp.Core;
using DietaApp.Core.Dtos;
using DietaApp.Core.Interfaces;
using DietaApp.Database;
using DietaApp.Database.Entities;
using DietaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace DietaApp.Controllers
{
    public class ShoppingListController : Controller
    {

        private readonly IManager mManager;
        private readonly ViewModelMapper mViewModelMapper; //Mapowanie z Dto na ViewModel
        private readonly DietaAppDbContext _dietaAppDbContext;

        public ShoppingListController(IManager Manager, ViewModelMapper viewModelMapper, DietaAppDbContext dietaAppDbContext)
        {
            mManager = Manager;
            mViewModelMapper = viewModelMapper;
            _dietaAppDbContext = dietaAppDbContext;
        }


        //public async Task<IActionResult> NavigationOfShoppingList2(ShoppingListViewModel model)
        //{

        //    try
        //    {
        //        if (model != null)
        //        {
        //            //var biuro = await _biuroService.Biura.Where(e => e.Cena == 4).ToListAsync();

        //            ShoppingListViewModel returnday= new ShoppingListViewModel
        //            {
        //                days= new List<Day>(
        //                    await _dietaAppDbContext.Days.ToListAsync()),
        //            };

        //            return View(returnday);
        //        }
        //        return NotFound();

        //    }
        //    catch (NullReferenceExeption ex)
        //    {
        //        return NotFound(ex);
        //    }
        //}

        //public async Task<IActionResult> NavigationOfShoppingList(string filter)
        //{
        //    var shoppingListDto = mManager.GetAllShoppingList(filter);
        //    var shoppingViewModels = mViewModelMapper.Map(shoppingListDto);
        //    return View(shoppingViewModels);
           
        //}
        public IActionResult NavigationOfShoppingList(string filterString)
        {
            var shopingDtos = mManager.GetAllShoppingList(filterString);
            var shopingViewModels = mViewModelMapper.Map(shopingDtos);
            return View(shopingViewModels);
        }


       [HttpGet]
        public async Task<IActionResult> DaysInSL(string shoppingListId)
        {
            int IdShoppingList = Int32.Parse(shoppingListId);
            ShoppingListViewModel currentShoppingList;
            try
            {
                if (IdShoppingList == null)
                {
                    return NotFound();
                }

                else
                {

                    var shoppingListDtos = mManager.GetAllShoppingList(null);
                    currentShoppingList = mViewModelMapper.Map(shoppingListDtos).ToList().Where(x => x.Id == IdShoppingList).FirstOrDefault(); ;
                    var dayDtos = mManager.GetAllDays(null);
                    var dayViewModels = mViewModelMapper.Map(dayDtos).ToList();


                    var daysIShoppingListDtos = mManager.GetAllDaysInShoppingList(null);
                    var daysInDayViewModels = mViewModelMapper.Map(daysIShoppingListDtos).ToList().Where(x => x.ShoppingListId == IdShoppingList).ToList();
                    foreach (var day in daysInDayViewModels)
                    {
                        day.Day = dayViewModels.Where(x => x.Id == day.DayId).FirstOrDefault();
                    }

                    //currentMeal = mealViewModels.Where(x=>x.Id == IdMeal)[IdMeal];
                    currentShoppingList.DaysInShoppingList = daysInDayViewModels;

                };
                return View(currentShoppingList);
            }
            catch (NullReferenceExeption ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddShoppingList(string shoppingListName, List<ShoppingList2Dto> days)
        {
            var existingShoppingList = _dietaAppDbContext
                .ShoppingLists
                .Where(i => i.Name == shoppingListName).FirstOrDefault();

            if (existingShoppingList != null || shoppingListName == null)
            {

                throw new Exception("Lista zakupowa o danej nazwie już istnieje");

            }
            var shopingList = new ShoppingList
            {
                Name = shoppingListName
            };
            _dietaAppDbContext.Add<ShoppingList>(shopingList);
            _dietaAppDbContext.SaveChanges();
            int shopingId = shopingList.Id;
            List<int> IdDayList = new List<int>();
            foreach (var dzien in days)
            {
                IdDayList.Add(Int32.Parse(dzien.dayName));
            }
            for (int i = 0; i < days.Count(); i++)
            {
                var bindingsTable = new DaysInShoppingList
                {
                    ShoppingListId = shopingId,
                    DayId = IdDayList[i],
                    //DaysAmount = listaDni.Count()
                };
                _dietaAppDbContext.AddAsync<DaysInShoppingList>(bindingsTable);
                _dietaAppDbContext.SaveChanges();
            }
            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> AddShoppingList(DaysListViewModel model)
        {
            if (model != null)
            {
                DaysListViewModel returnDay = new DaysListViewModel
                {
                    Days = new SelectList(
                        await _dietaAppDbContext.Days.OrderBy(d => d.Name).ToListAsync(), "Id", "Name"),
                    days = new List<Day>(
                        await _dietaAppDbContext.Days.ToListAsync())
                };
                return View(returnDay);
            }
            else return NotFound();

        }
        [HttpGet]
        public async Task<IActionResult> ListOfDaysInShoppingList(string shoppingListId)
        {
            int IdShoppingList = Int32.Parse(shoppingListId);


            var CurrentList= _dietaAppDbContext.ShoppingLists
                .Where(sl=>sl.Id==IdShoppingList)
                .Include(disl=>disl.DaysInShoppingList)
                .ThenInclude(d=>d.Day)
                .ThenInclude(mid=>mid.MealInDays)
                .ThenInclude(m=>m.Meal)
                .ThenInclude(dim=>dim.DishesInMeal)
                .ThenInclude(d=>d.Dish)
                .ThenInclude(pid => pid.ProductsInDish)
                .ThenInclude(p=>p.Product)
                .FirstOrDefault();
            int temp = 0;
           
            Dictionary<string, int> sumDistinctProduct = new Dictionary<string, int>();
            Dictionary<string, int> sumWeightProduct = new Dictionary<string, int>();
            Dictionary<string, string> categoryProduct = new Dictionary<string, string>();

            
            foreach (var day in CurrentList.DaysInShoppingList)
            {
                var meals = day.Day.MealInDays;
                foreach (var item in meals)
                {
                    var prod = item.Meal.DishesInMeal;
                    foreach (var meal in prod)
                    {
                        var productsInDish = meal.Dish.ProductsInDish;
                        foreach (var product in productsInDish)
                        {
                            if (sumDistinctProduct.ContainsKey(product.Product.Name))
                            {
                                sumDistinctProduct[product.Product.Name]++;
                            }
                            else
                            {
                                sumDistinctProduct.Add(product.Product.Name, 1);
                            }
                            if (sumWeightProduct.ContainsKey(product.Product.Name))
                            {
                                int actualyValueInDictionary = sumWeightProduct[product.Product.Name];
                                temp = actualyValueInDictionary + product.ProductWeight;
                                sumWeightProduct[product.Product.Name] = temp;
                            }
                            else
                            {
                                sumWeightProduct.Add(product.Product.Name, product.ProductWeight);
                            }
                            if (!categoryProduct.ContainsKey(product.Product.Name))
                            {
                                categoryProduct.Add(product.Product.Name, product.Product.Category);
                            }
                        }
                    }
                }
            }
            ShoppingListViewModel dictionaryViewModel = new ShoppingListViewModel
            {

                sumDistinctProduct = sumDistinctProduct,
                sumWeightProduct = sumWeightProduct,
                categoryProduct= categoryProduct
            };

            return View(dictionaryViewModel);      
        }

        public IActionResult Delete(int shoppingListId)
        {
            mManager.DeleteShoppingList(new ShoppingListDto { Id = shoppingListId });
            var shoppginListDtos = mManager.GetAllShoppingList(null);
            var shoppingListViewModels = mViewModelMapper.Map(shoppginListDtos);
            return View("NavigationOfShoppingList", shoppingListViewModels);

        }
    }
}
