using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    public interface IDishRepository : IRepository<Dish>
    {
        IEnumerable<Dish> GetAllDishes();
    }
}
