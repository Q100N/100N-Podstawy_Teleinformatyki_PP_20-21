using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
       
    }
}
