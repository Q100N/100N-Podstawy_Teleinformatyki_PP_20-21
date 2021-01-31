using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Core
{
    public class ProductDto : BaseEntityDto
    {
        public string Name { get; set; }

        public int Kcal { get; set; }

        public string Unit { get; set; }

        public string Category { get; set; }

        public List<ProductsInDishDto> ProductsInDish { get; set; }
    }
}
