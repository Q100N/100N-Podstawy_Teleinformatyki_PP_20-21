using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class ProductsInDishRepository : BaseRepository<ProductsInDish>, IProductsInDishRepository
    {
        protected override DbSet<ProductsInDish> DbSet => mDbContext.ProductsInDishes;

        public ProductsInDishRepository(DietaAppDbContext dbContext) : base(dbContext)
        {

        }
        //Ieunmerable -> Mozemy przechodzic pokolei po elementach

        public IEnumerable<ProductsInDish> GetAllProductsInDish()
        {
            return DbSet.Select(x => x);
        }

    }
}
