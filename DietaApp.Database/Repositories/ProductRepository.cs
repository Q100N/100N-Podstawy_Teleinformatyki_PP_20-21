using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        protected override DbSet<Product> DbSet => mDbContext.Products;

        public ProductRepository(DietaAppDbContext dbContext) : base(dbContext)
        {


        }


        public IEnumerable<Product> GetAllProducts()
        {
            return DbSet.Select(x => x);
        }
    }
}
