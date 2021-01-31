using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class ProductsInDish : BaseEntity
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }

        public int ProductWeight { get; set; }

    }
    }
