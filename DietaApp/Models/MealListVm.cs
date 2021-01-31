using DietaApp.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DietaApp.Models
{
    public class MealListVm
    {
        public List<Meal> meals { get; set; }
        public SelectList Meals { get; set; }
        //public int? MealId { get; set; }
        //public string Name { get; set; }
    }
}
