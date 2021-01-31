using DietaApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp
{
    public class DishViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public List<DishesInMealViewModel> dishesInMeal{ get; set; }

        public List<ProductsInDishViewModel> productsInDish { get; set; }

        public List<ProductViewModel> products;
        public List<Product> product;
        public List<ProductsInDishViewModel> ProductsInDish { get; set; }

        public Dictionary<string, int> sumKcalInDish = new Dictionary<string, int>();
        public Dictionary<string, int> IdOfDish = new Dictionary<string, int>();

        public List<string> getCategory = new List<string>();
        public List<string> getName = new List<string>();
        public List<int> getKcal = new List<int>();
        public List<string> getUnit = new List<string>();
        public List<int> getProductWeight = new List<int>();

    }
}
