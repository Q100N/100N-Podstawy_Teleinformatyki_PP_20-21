using System;
using System.Collections.Generic;

namespace DietaApp.Core.Interfaces
{
    public interface IManager
    {
        List<ProductDto> GetAllProducts(string filterString);
        void AddNewProduct(ProductDto product);
        void AddNewMeal(MealDto meal);
        void AddNewDish(DishDto dish);
        bool DeleteProduct(ProductDto product);
        bool DeleteMeal(MealDto meal);
        bool DeleteDay(DayDto day);
        bool DeleteDish(DishDto dish);
        bool DeleteShoppingList(ShoppingListDto shoppingList);
        List<ProductDto> GetAllProducts();
        List<DayDto> GetAllDays(string filterString);
        List<ShoppingListDto> GetAllShoppingList(string filterString);
        public List<ProductDto> GetProductList();
        List<DishDto> GetAllDishes(string filterString);
        List<MealDto> GetAllMeals(string filterString);
        List<DishesInMealDto> GetAllDishesInMeal(string filterString);
        List<ProductDto> GetAllProductsForADish(string dishName, string filterString);
        List<ProductsInDishDto> GetAllProductsInDish(string filterString);
        List<MealsInDayDto> GetAllMealsInDay(string filterString);
        List<DaysInShoppingListDto> GetAllDaysInShoppingList(string filterString);
    }

}
