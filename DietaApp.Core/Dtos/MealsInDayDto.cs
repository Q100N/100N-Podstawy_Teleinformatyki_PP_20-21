using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Core
{
    public class MealsInDayDto : BaseEntityDto
    {
        public int DayId { get; set; }

        public DayDto Day { get; set; }

        public int MealId { get; set; }

        public MealDto Meal { get; set; }


    }
}
