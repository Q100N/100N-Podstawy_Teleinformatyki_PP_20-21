using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        protected override DbSet<Dish> DbSet => mDbContext.Dishes;


        public DishRepository(DietaAppDbContext dbContext) : base(dbContext)
        {
        }


        public IEnumerable<Dish> GetAllDishes()
        {

            return DbSet.Select(x => x);
        }


    }
}
