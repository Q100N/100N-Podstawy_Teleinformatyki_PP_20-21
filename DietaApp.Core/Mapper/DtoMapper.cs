using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using DietaApp.Database.Entities;

namespace DietaApp.Core.Mapper
{
    public class DtoMapper
    {
        private IMapper mMapper;

        public DtoMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {/*
                config.CreateMap<Medicine, MedicineDto>()
                    .ForMember(x => x.PriceInTotal, opt => opt.MapFrom(y =>y.Price * y.Amount))
                    .ReverseMap();*/
                config.CreateMap<Dish, DishDto>()
                    .ReverseMap();
                config.CreateMap<Day, DayDto>()
                   .ReverseMap();
                config.CreateMap<Meal, MealDto>()
                   .ReverseMap();
                config.CreateMap<DishesInMeal, DishesInMealDto>()
                     .ReverseMap();
                config.CreateMap<Product, ProductDto>()
                   .ReverseMap();
                config.CreateMap<ProductsInDish, ProductsInDishDto>()
                    .ReverseMap();
                config.CreateMap<ShoppingList, ShoppingListDto>()
                   .ReverseMap();
                config.CreateMap<DaysInShoppingList, DaysInShoppingListDto>()
                    .ReverseMap();
                config.CreateMap<MealsInDay, MealsInDayDto>()
                    .ReverseMap();
            }
            ).CreateMapper();
        }

        #region Product Maps

        public ProductDto Map(Product product) => mMapper.Map<ProductDto>(product);

        public List<ProductDto> Map(List<Product> products) => mMapper.Map<List<ProductDto>>(products);


        public Product Map(ProductDto product) => mMapper.Map<Product>(product);

        public List<Product> Map(List<ProductDto> products) => mMapper.Map<List<Product>>(products);

        #endregion

        #region ProductsInMeal Maps

        public ProductsInDishDto Map(ProductsInDish productsInDish) => mMapper.Map<ProductsInDishDto>(productsInDish);

        public List<ProductsInDishDto> Map(List<ProductsInDish> productsInDishes) => mMapper.Map<List<ProductsInDishDto>>(productsInDishes);


        public ProductsInDish Map(ProductsInDishDto productsInDish) => mMapper.Map<ProductsInDish>(productsInDish);

        public List<ProductsInDish> Map(List<ProductsInDishDto> productsInDishes) => mMapper.Map<List<ProductsInDish>>(productsInDishes);

        #endregion

        #region Meal Maps

        public MealDto Map(Meal meal) => mMapper.Map<MealDto>(meal);

        public List<MealDto> Map(List<Meal> meals) => mMapper.Map<List<MealDto>>(meals);


        public Meal Map(MealDto meal) => mMapper.Map<Meal>(meal);

        public List<Meal> Map(List<MealDto> meals) => mMapper.Map<List<Meal>>(meals);

        #endregion


        #region Day Maps

        public DayDto Map(Day day) => mMapper.Map<DayDto>(day);

        public List<DayDto> Map(List<Day> days) => mMapper.Map<List<DayDto>>(days);


        public Day Map(DayDto day) => mMapper.Map<Day>(day);

        public List<Day> Map(List<DayDto> days) => mMapper.Map<List<Day>>(days);

        #endregion

        #region Dish Maps

        public DishDto Map(Dish dish) => mMapper.Map<DishDto>(dish);

        public List<DishDto> Map(List<Dish> dishes) => mMapper.Map<List<DishDto>>(dishes);


        public Dish Map(DishDto dish) => mMapper.Map<Dish>(dish);

        public List<Dish> Map(List<DishDto> dishes) => mMapper.Map<List<Dish>>(dishes);

        #endregion

        #region DishesInMeal Maps

        public DishesInMealDto Map(DishesInMeal dishesInMeal) => mMapper.Map<DishesInMealDto>(dishesInMeal);

        public List<DishesInMealDto> Map(List<DishesInMeal> dishesInMeals) => mMapper.Map<List<DishesInMealDto>>(dishesInMeals);


        public DishesInMeal Map(DishesInMealDto dishesInMeal) => mMapper.Map<DishesInMeal>(dishesInMeal);

        public List<DishesInMeal> Map(List<DishesInMealDto> dishesInMeals) => mMapper.Map<List<DishesInMeal>>(dishesInMeals);

        #endregion


        #region ShoppingList Maps

        public ShoppingListDto Map(ShoppingList shoppinglist) => mMapper.Map<ShoppingListDto>(shoppinglist);

        public List<ShoppingListDto> Map(List<ShoppingList> shoppinglists) => mMapper.Map<List<ShoppingListDto>>(shoppinglists);


        public ShoppingList Map(ShoppingListDto shoppinglist) => mMapper.Map<ShoppingList>(shoppinglist);

        public List<ShoppingList> Map(List<ShoppingListDto> shoppinglists) => mMapper.Map<List<ShoppingList>>(shoppinglists);

        #endregion

        #region DaysInShoppingList Maps

        public DaysInShoppingListDto Map(DaysInShoppingList daysInShoppingList) => mMapper.Map<DaysInShoppingListDto>(daysInShoppingList);

        public List<DaysInShoppingListDto> Map(List<DaysInShoppingList> daysInShoppingLists) => mMapper.Map<List<DaysInShoppingListDto>>(daysInShoppingLists);


        public DaysInShoppingList Map(DaysInShoppingListDto daysInShoppingList) => mMapper.Map<DaysInShoppingList>(daysInShoppingList);

        public List<DaysInShoppingList> Map(List<DaysInShoppingListDto> daysInShoppingLists) => mMapper.Map<List<DaysInShoppingList>>(daysInShoppingLists);

        #endregion

        #region MealsInDay Maps

        public MealsInDayDto Map(MealsInDay mealsInDay) => mMapper.Map<MealsInDayDto>(mealsInDay);

        public List<MealsInDayDto> Map(List<MealsInDay> mealsInDays) => mMapper.Map<List<MealsInDayDto>>(mealsInDays);


        public MealsInDay Map(MealsInDayDto mealsInDay) => mMapper.Map<MealsInDay>(mealsInDay);

        public List<MealsInDay> Map(List<MealsInDayDto> mealsInDays) => mMapper.Map<List<MealsInDay>>(mealsInDays);

   

        #endregion

    }
}
