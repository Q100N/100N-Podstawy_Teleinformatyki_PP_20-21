using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp
{
    public class MealsInDayViewModel : BaseViewModel
    {
        public int DayId { get; set; }

        public DayViewModel Day { get; set; }

        public int MealId { get; set; }

        public MealViewModel Meal { get; set; }


    }
}
