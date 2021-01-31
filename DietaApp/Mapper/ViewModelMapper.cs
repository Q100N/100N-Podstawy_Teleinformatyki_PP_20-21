using System;
using System.Collections.Generic;
using AutoMapper;
using DietaApp.Core;

namespace DietaApp
{
    public class ViewModelMapper
    {
        private IMapper mMapper;

        public ViewModelMapper()
        {

            mMapper = new MapperConfiguration(config =>
    {
        config.CreateMap<DishDto, DishViewModel>()
        .ReverseMap();
        config.CreateMap<DayDto, DayViewModel>()
       .ReverseMap();
        config.CreateMap<MealDto, MealViewModel>()
       .ReverseMap();
        config.CreateMap<ProductDto, ProductViewModel>()
       .ReverseMap();
        config.CreateMap<ProductsInDishDto, ProductsInDishViewModel>()
        .ReverseMap();
        config.CreateMap<DishesInMealDto, DishesInMealViewModel>()
        .ReverseMap();
        config.CreateMap<ShoppingListDto, ShoppingListViewModel>()
       .ReverseMap();
        config.CreateMap<DaysInShoppingListDto, DaysInShoppingListViewModel>()
        .ReverseMap();
        config.CreateMap<MealsInDayDto, MealsInDayViewModel>()
         .ReverseMap();

    }
    ).CreateMapper();
        }

        #region Product Maps

        public ProductViewModel Map(ProductDto product) => mMapper.Map<ProductViewModel>(product);

        public List<ProductViewModel> Map(List<ProductDto> products) => mMapper.Map<List<ProductViewModel>>(products);


        public ProductDto Map(ProductViewModel product) => mMapper.Map<ProductDto>(product);

        public List<ProductDto> Map(List<ProductViewModel> products) => mMapper.Map<List<ProductDto>>(products);
        #endregion

        #region Dish Maps

        public DishViewModel Map(DishDto dish) => mMapper.Map<DishViewModel>(dish);

        public List<DishViewModel> Map(List<DishDto> dishes) => mMapper.Map<List<DishViewModel>>(dishes);


        public DishDto Map(DishViewModel dish) => mMapper.Map<DishDto>(dish);

        public List<DishDto> Map(List<DishViewModel> dishes) => mMapper.Map<List<DishDto>>(dishes);
        #endregion

        #region DishesInMeal Maps

        public DishesInMealViewModel Map(DishesInMealDto dishesInMeal) => mMapper.Map<DishesInMealViewModel>(dishesInMeal);

        public List<DishesInMealViewModel> Map(List<DishesInMealDto> dishesInMeals) => mMapper.Map<List<DishesInMealViewModel>>(dishesInMeals);


        public DishesInMealDto Map(DishesInMealViewModel dishesInMeal) => mMapper.Map<DishesInMealDto>(dishesInMeal);

        public List<DishesInMealDto> Map(List<DishesInMealViewModel> dishesInMeals) => mMapper.Map<List<DishesInMealDto>>(dishesInMeals);
        #endregion

        #region ProductsList Maps

        public ProductsInDishViewModel Map(ProductsInDishDto productsInDish) => mMapper.Map<ProductsInDishViewModel>(productsInDish);

        public List<ProductsInDishViewModel> Map(List<ProductsInDishDto> productsInDishes) => mMapper.Map<List<ProductsInDishViewModel>>(productsInDishes);


        public ProductsInDishDto Map(ProductsInDishViewModel productsInDish) => mMapper.Map<ProductsInDishDto>(productsInDish);

        public List<ProductsInDishDto> Map(List<ProductsInDishViewModel> productsInDishes) => mMapper.Map<List<ProductsInDishDto>>(productsInDishes);

        #endregion

        #region Meal Maps

        public MealViewModel Map(MealDto meal) => mMapper.Map<MealViewModel>(meal);

        public List<MealViewModel> Map(List<MealDto> meals) => mMapper.Map<List<MealViewModel>>(meals);


        public MealDto Map(MealViewModel meal) => mMapper.Map<MealDto>(meal);

        public List<MealDto> Map(List<MealViewModel> meals) => mMapper.Map<List<MealDto>>(meals);
        #endregion

        #region Day Maps

        public DayViewModel Map(DayDto day) => mMapper.Map<DayViewModel>(day);

        public List<DayViewModel> Map(List<DayDto> days) => mMapper.Map<List<DayViewModel>>(days);


        public DayDto Map(DayViewModel day) => mMapper.Map<DayDto>(day);

        public List<DayDto> Map(List<DayViewModel> days) => mMapper.Map<List<DayDto>>(days);
        #endregion


        #region ShoppingList Maps

        public ShoppingListViewModel Map(ShoppingListDto shoppinglist) => mMapper.Map<ShoppingListViewModel>(shoppinglist);

        public List<ShoppingListViewModel> Map(List<ShoppingListDto> shoppinglists) => mMapper.Map<List<ShoppingListViewModel>>(shoppinglists);


        public ShoppingListDto Map(ShoppingListViewModel shoppinglist) => mMapper.Map<ShoppingListDto>(shoppinglist);

        public List<ShoppingListDto> Map(List<ShoppingListViewModel> shoppinglists) => mMapper.Map<List<ShoppingListDto>>(shoppinglists);
        #endregion

        #region DaysInShoppingList Maps

        public DaysInShoppingListViewModel Map(DaysInShoppingListDto daysInShoppingList) => mMapper.Map<DaysInShoppingListViewModel>(daysInShoppingList);

        public List<DaysInShoppingListViewModel> Map(List<DaysInShoppingListDto> daysInShoppingLists) => mMapper.Map<List<DaysInShoppingListViewModel>>(daysInShoppingLists);


        public DaysInShoppingListDto Map(DaysInShoppingListViewModel daysInShoppingList) => mMapper.Map<DaysInShoppingListDto>(daysInShoppingList);

        public List<DaysInShoppingListDto> Map(List<DaysInShoppingListViewModel> daysInShoppingLists) => mMapper.Map<List<DaysInShoppingListDto>>(daysInShoppingLists);

        #endregion

        #region MealsInDay Maps

        public MealsInDayViewModel Map(MealsInDayDto mealsInDay) => mMapper.Map<MealsInDayViewModel>(mealsInDay);

        public List<MealsInDayViewModel> Map(List<MealsInDayDto> mealsInDays) => mMapper.Map<List<MealsInDayViewModel>>(mealsInDays);


        public MealsInDayDto Map(MealsInDayViewModel mealsInDay) => mMapper.Map<MealsInDayDto>(mealsInDay);

        public List<MealsInDayDto> Map(List<MealsInDayViewModel> mealsInDays) => mMapper.Map<List<MealsInDayDto>>(mealsInDays);

        #endregion

    }
}
