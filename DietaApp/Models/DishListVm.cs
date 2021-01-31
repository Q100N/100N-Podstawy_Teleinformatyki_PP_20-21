using DietaApp.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DietaApp.Models
{
    public class DishListVm
    {
        public List<Dish> dishes { get; set; }
        public SelectList Dishes { get; set; }
        //public int? MealId { get; set; }
        //public string Name { get; set; }
    }
}
