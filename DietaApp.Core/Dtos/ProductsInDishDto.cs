using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace  DietaApp.Core
{
    public class ProductsInDishDto : BaseEntityDto
        {
            public int ProductId { get; set; }

            public ProductDto Product { get; set; }

            public int DishId { get; set; }

            public DishDto Dish { get; set; }

            public int ProductWeight { get; set; }

        }
    }
