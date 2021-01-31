using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class DishesInMealRepository : BaseRepository<DishesInMeal>, IDishesInMealRepository
    {
        protected override DbSet<DishesInMeal> DbSet => mDbContext.DishesInMeals;

        public DishesInMealRepository(DietaAppDbContext dbContext) : base(dbContext)
        {

        }
        //Ieunmerable -> Mozemy przechodzic pokolei po elementach

        public IEnumerable<DishesInMeal> GetAllDishesInMeal()
        {
            return DbSet.Select(x => x);
        }

    }
}
