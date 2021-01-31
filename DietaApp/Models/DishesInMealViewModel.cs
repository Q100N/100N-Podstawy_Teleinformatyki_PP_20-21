using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp
{
    public class DishesInMealViewModel : BaseViewModel
    {

        public int DishId { get; set; }

        public DishViewModel Dish { get; set; }

        public int MealId { get; set; }

        public MealViewModel Meal { get; set; }

    }
}