using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class MealsInDay : BaseEntity
    {
        public int DayId { get; set; }

        public Day Day { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }


    }
    }
