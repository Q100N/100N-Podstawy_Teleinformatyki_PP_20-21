using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    public interface IMealRepository : IRepository<Meal>
    {
        IEnumerable<Meal> GetAllMeals();
    }
}
