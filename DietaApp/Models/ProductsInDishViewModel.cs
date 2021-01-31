using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp
{
    public class ProductsInDishViewModel : BaseViewModel
    {
        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public int DishId { get; set; }

        public DishViewModel Dish { get; set; }

        public int ProductWeight { get; set; }

    }
}
