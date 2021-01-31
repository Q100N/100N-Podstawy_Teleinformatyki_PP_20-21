using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Core
{
    public class MealDto : BaseEntityDto
    {

        public string Name { get; set; }

        public List<DishesInMealDto> DishesInMeal { get; set; }

        public List<MealsInDayDto> MealsInDay { get; set; }


    }
}
