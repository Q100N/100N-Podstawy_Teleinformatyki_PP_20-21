using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class MealRepository : BaseRepository<Meal>, IMealRepository
    {
        protected override DbSet<Meal> DbSet => mDbContext.Meals;


        public MealRepository(DietaAppDbContext dbContext) : base(dbContext)
        {
        }


        public IEnumerable<Meal> GetAllMeals()
        {

            return DbSet.Select(x => x);
        }


    }
}
