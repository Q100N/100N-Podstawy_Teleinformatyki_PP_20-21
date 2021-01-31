using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietaApp.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DietaApp
{
    public class MealViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        public List<DishesInMealViewModel> dishesInMeal { get; set; }

        public List<MealsInDayViewModel> MealsInDay { get; set; }

        public List<ProductViewModel> products;
        public List<Product> product;
        public Dictionary<int, int> _dishIndex = new Dictionary<int, int>();
        public Dictionary<int, string> _IdOfDishes = new Dictionary<int, string>();
        public Dictionary<int, int> _sumKcalInlDish = new Dictionary<int, int>();

        public Dictionary<string, int> sumKcalInMeal = new Dictionary<string, int>();
        public Dictionary<int, string> IdOfMeal = new Dictionary<int, string>();
        public List<string> getCategory = new List<string>();
        public List<string> getName = new List<string>();
        public List<int> getKcal = new List<int>();
        public List<string> getUnit = new List<string>();
    }
}
