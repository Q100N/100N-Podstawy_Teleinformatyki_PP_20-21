using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    public interface IProductsInDishRepository: IRepository<ProductsInDish>
    {
        IEnumerable<ProductsInDish> GetAllProductsInDish();
    }
}
