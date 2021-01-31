using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietaApp.Core.Dtos;
using DietaApp.Core;
using DietaApp.Core.Interfaces;
using DietaApp.Database;
using DietaApp.Database.Entities;
using DietaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Controllers
{
    public class DayController : Controller
    {

        private readonly IManager mManager;
        private readonly ViewModelMapper mViewModelMapper;
        private readonly DietaAppDbContext _dietaAppDbContext;
        public DayController(IManager Manager, ViewModelMapper viewModelMapper, DietaAppDbContext dietaAppDbContext)
        {
            mManager = Manager;
            mViewModelMapper = viewModelMapper;
            _dietaAppDbContext = dietaAppDbContext;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult NavigationOfDays(string filterString)
        {
            var dayDtos = mManager.GetAllDays(filterString);
            var dayViewModels = mViewModelMapper.Map(dayDtos);

            return View(dayViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AddDay(string dayName, List<Day2Dto> meals)
        {
            var existingDay = _dietaAppDbContext
                 .Days
                .Where(i => i.Name == dayName).FirstOrDefault();


            if (existingDay != null || dayName == null)
            {

                throw new Exception("Dzień o danej tej nazwie już istnieje");

            }

            var day = new Day
            {
                Name = dayName
            };
            _dietaAppDbContext.Add<Day>(day);
            _dietaAppDbContext.SaveChanges();

        int DayId = day.Id;
            List<int> IdMealsList = new List<int>();
            foreach(var posilek in meals)
            {
                IdMealsList.Add(Int32.Parse(posilek.mealName));;
            }
            for(int i=0;i<meals.Count();i++)
            {
                var bindingsTable = new MealsInDay
                {
                    DayId = DayId,
                    MealId = IdMealsList[i]
                };
                _dietaAppDbContext.AddAsync<MealsInDay>(bindingsTable);

                if (ModelState.IsValid)
                {
                    _dietaAppDbContext.SaveChanges();
                    ////return RedirectToAction("NavigationOfProducts");
                    //ConfirmationViewModel confirmationViewModel = new ConfirmationViewModel
                    //{
                    //    name = nazwaDnia,
                    //    table = "Dniami dietetycznymi",
                    //    controler = "Day",
                    //    method = "NavigationOfDays"

                    };
                    //return RedirectToAction("Confirmation", "Home", confirmationViewModel);

                }
            


            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> AddDay(MealListVm model)
        {

            if(model!=null)
            {
                MealListVm retMeal = new MealListVm
                {
                    meals=new List<Meal>(
                        await _dietaAppDbContext.Meals.ToListAsync()
                        ),
                    Meals = new SelectList(
                        await _dietaAppDbContext.Meals.OrderBy(m => m.Name).ToListAsync(), "Id", "Name")
                };
                return View(retMeal);
            }
            else
            {
                return NotFound();
            }
            return NotFound();
        }
        public IActionResult Delete(int dayId)
        {
            mManager.DeleteDay(new DayDto { Id = dayId });
            var dayDtos = mManager.GetAllDays(null);
            var dayViewModels = mViewModelMapper.Map(dayDtos);
            return View("NavigationOfDays", dayViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> ListOfMealsInDay(string dayId)
        {
            int IdDay = Int32.Parse(dayId);
            DayViewModel currentDay;
            try
            {
                if (dayId == null)
                {
                    return NotFound();
                }

                else
                {

                    var dayDtos = mManager.GetAllDays(null);
                    currentDay = mViewModelMapper.Map(dayDtos).ToList().Where(x => x.Id == IdDay).FirstOrDefault(); ;
                    var mealDtos = mManager.GetAllMeals(null);
                    var mealViewModels = mViewModelMapper.Map(mealDtos).ToList();


                    var mealsInDayDtos = mManager.GetAllMealsInDay(null);
                    var mealsInDayViewModels = mViewModelMapper.Map(mealsInDayDtos).ToList().Where(x => x.DayId == IdDay).ToList();
                    foreach (var meal in mealsInDayViewModels)
                    {
                        meal.Meal = mealViewModels.Where(x => x.Id == meal.MealId).FirstOrDefault();
                    }

                    //currentMeal = mealViewModels.Where(x=>x.Id == IdMeal)[IdMeal];
                    currentDay.mealsInDay = mealsInDayViewModels;

                };
                return View(currentDay);
            }
            catch (NullReferenceExeption ex)
            {
                return NotFound(ex);
            }
        }
    }


}
