using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    public interface IDishesInMealRepository : IRepository<DishesInMeal>
    {
        IEnumerable<DishesInMeal> GetAllDishesInMeal();
    }
}
