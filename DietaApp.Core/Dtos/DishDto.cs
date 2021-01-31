using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Core
{
    public class DishDto : BaseEntityDto
    {
        public string Name { get; set; }

        public List<ProductsInDishDto> ProductsInDish { get; set; }

        public List<DishesInMealDto> DishesInMeal { get; set; }
    }
}
