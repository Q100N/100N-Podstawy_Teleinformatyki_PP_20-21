using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class DishesInMeal : BaseEntity
    {
        public int MealId { get; set; }

        public Meal Meal { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }

        public int ProductWeight { get; set; }

    }
    }
