using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace  DietaApp.Core
{
    public class DishesInMealDto : BaseEntityDto
        {
            public int MealId { get; set; }

            public MealDto Meal { get; set; }

            public int DishId { get; set; }

            public DishDto Dish { get; set; }


        }
    }
