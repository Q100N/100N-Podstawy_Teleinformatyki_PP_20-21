using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class DietaAppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ProductsInDish> ProductsInDishes{ get; set; }
        public DbSet<DishesInMeal> DishesInMeals { get; set; }
        public DbSet<MealsInDay> MealsInDays { get; set; }
        public DbSet<DaysInShoppingList> DaysInShoppingLists { get; set; }

        public DietaAppDbContext(DbContextOptions options) : base(options)
        {

        }

    }

}
