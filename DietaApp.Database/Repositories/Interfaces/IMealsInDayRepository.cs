using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    public interface IMealsInDayRepository : IRepository<MealsInDay>
    {
        IEnumerable<MealsInDay> GetAllMealsInDay();
    }
}
