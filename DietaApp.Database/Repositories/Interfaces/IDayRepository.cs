using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    //Wykorzystanie napisanych metod
    public interface IDayRepository : IRepository<Day>
    {
        IEnumerable<Day> GetAllDays();
    }
}
