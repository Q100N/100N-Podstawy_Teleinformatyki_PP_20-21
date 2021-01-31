using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{ 
        public class DayRepository : BaseRepository<Day>, IDayRepository
        {
            protected override DbSet<Day> DbSet => mDbContext.Days;

            public DayRepository(DietaAppDbContext dbContext) : base(dbContext)
            {
            }
            public IEnumerable<Day> GetAllDays()
            {

                return DbSet/*.Include(x => x.Prescriptions).ThenInclude(x => x.Medicines)*/.Select(x => x);
            }


        }
    
}
