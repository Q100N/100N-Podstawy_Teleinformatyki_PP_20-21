﻿// <auto-generated />
using DietaApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DietaApp.Database.Migrations
{
    [DbContext(typeof(DietaAppDbContext))]
    partial class DietaAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DietaApp.Database.Entities.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.DaysInShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("DaysInShoppingLists");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.DishesInMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("ProductWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("MealId");

                    b.ToTable("DishesInMeals");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.MealsInDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("MealId");

                    b.ToTable("MealsInDays");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.ProductsInDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsInDishes");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.DaysInShoppingList", b =>
                {
                    b.HasOne("DietaApp.Database.Entities.Day", "Day")
                        .WithMany("DaysInShoppingLists")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietaApp.Database.Entities.ShoppingList", "ShoppingList")
                        .WithMany("DaysInShoppingList")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.DishesInMeal", b =>
                {
                    b.HasOne("DietaApp.Database.Entities.Dish", "Dish")
                        .WithMany("DishesInMeal")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietaApp.Database.Entities.Meal", "Meal")
                        .WithMany("DishesInMeal")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.MealsInDay", b =>
                {
                    b.HasOne("DietaApp.Database.Entities.Day", "Day")
                        .WithMany("MealInDays")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietaApp.Database.Entities.Meal", "Meal")
                        .WithMany("MealsInDay")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.ProductsInDish", b =>
                {
                    b.HasOne("DietaApp.Database.Entities.Dish", "Dish")
                        .WithMany("ProductsInDish")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietaApp.Database.Entities.Product", "Product")
                        .WithMany("ProductsInDish")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.Day", b =>
                {
                    b.Navigation("DaysInShoppingLists");

                    b.Navigation("MealInDays");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.Dish", b =>
                {
                    b.Navigation("DishesInMeal");

                    b.Navigation("ProductsInDish");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.Meal", b =>
                {
                    b.Navigation("DishesInMeal");

                    b.Navigation("MealsInDay");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.Product", b =>
                {
                    b.Navigation("ProductsInDish");
                });

            modelBuilder.Entity("DietaApp.Database.Entities.ShoppingList", b =>
                {
                    b.Navigation("DaysInShoppingList");
                });
#pragma warning restore 612, 618
        }
    }
}
