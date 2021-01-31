using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }

        public int Kcal { get; set; }

        public string Unit { get; set; }

        public string Category { get; set; }

        public List<ProductsInDish> ProductsInDish { get; set; }

    }
}
