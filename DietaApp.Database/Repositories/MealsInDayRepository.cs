using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class MealsInDayRepository : BaseRepository<MealsInDay>, IMealsInDayRepository
    {
        protected override DbSet<MealsInDay> DbSet => mDbContext.MealsInDays;


        public MealsInDayRepository(DietaAppDbContext dbContext) : base(dbContext)
        {
        }


        //Ieunmerable -> Mozemy przechodzic pokolei po elementach

        public IEnumerable<MealsInDay> GetAllMealsInDay()
        {
            return DbSet.Select(x => x);
        }


    }
}
