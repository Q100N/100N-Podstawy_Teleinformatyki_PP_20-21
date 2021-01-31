using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class Meal : BaseEntity
    {

        public string Name { get; set; }

        public List<DishesInMeal> DishesInMeal { get; set; }

        public List<MealsInDay> MealsInDay { get; set; }



    }
}
