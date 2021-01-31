using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class Dish : BaseEntity
    {

        public string Name { get; set; }

        public List<ProductsInDish> ProductsInDish { get; set; }

        public List<DishesInMeal> DishesInMeal { get; set; }



    }
}
