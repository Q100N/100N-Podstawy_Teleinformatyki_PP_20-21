using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Core.Interfaces;
using DietaApp.Core.Mapper;
using DietaApp.Database;
using DietaApp.Database.Entities;


namespace DietaApp.Core
{
    public class Manager : IManager
    {
        private readonly IDishRepository mDishRepository;
        private readonly IDayRepository mDayRepository;
        private readonly IProductRepository mProductRepository;
        private readonly IProductsInDishRepository mProductsInDishRepository;
        private readonly IMealRepository mMealRepository;
        private readonly IDishesInMealRepository mDishesInMealRepository;
        private readonly IShoppingListRepository mShoppingListRepository;
        private readonly IMealsInDayRepository mMealsInDayRepository;
        private readonly IDaysInShoppingListRepository mDaysInShoppingListRepository;
        private readonly DtoMapper mDtoMapper;

        public Manager(
            IDishRepository dishRepository,
            IDayRepository dayRepository,
            IProductRepository productRepository,
            IProductsInDishRepository productsInDishRepository,
            IMealRepository mealRepository,
            IDishesInMealRepository dishesInMealRepository,
            IMealsInDayRepository mealsInDayRepository,
            IShoppingListRepository shoppingListRepository,
            IDaysInShoppingListRepository daysInShoppingListRepository,
            DtoMapper mapper)
        {
  
            mDtoMapper = mapper;
            mDishRepository = dishRepository;
            mDayRepository = dayRepository;
            mProductRepository = productRepository;
            mProductsInDishRepository = productsInDishRepository;
            mMealRepository = mealRepository;
            mDishesInMealRepository = dishesInMealRepository;
            mMealsInDayRepository = mealsInDayRepository;
            mDaysInShoppingListRepository = daysInShoppingListRepository;
            mShoppingListRepository = shoppingListRepository;
        }
        
       
        public List<ProductDto> GetAllProducts(string filterString)
        {
            var productEntities = mProductRepository.GetAllProducts().ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                productEntities = productEntities.Where(x => x.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(productEntities);
        }

        public List<ProductDto> GetProductList()
        {
            var productEntities = mProductRepository.GetAllProducts().ToList();
            return mDtoMapper.Map(productEntities);
        }
        public void AddNewProduct(ProductDto product)
        {
            var entity = mDtoMapper.Map(product);


            mProductRepository.AddNew(entity);

        }

      
        public bool DeleteProduct(ProductDto product)
        {
            var entity = mDtoMapper.Map(product);

            return mProductRepository.Delete(entity);

        }

        public List<ProductDto> GetAllProductsForADish(string dishName, string filterString)
        {
            var productsEntities = mProductRepository.GetAllProducts().Where(x => x.Name == dishName).ToList(); // Jak wziac wszystkie produkty z danego Posiłku

            if (!string.IsNullOrEmpty(filterString))
            {
                productsEntities = productsEntities
                    .Where(x => x.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(productsEntities);
        }

        public void AddNewDish(DishDto dish)
        {
            var entity = mDtoMapper.Map(dish);
            mDishRepository.AddNew(entity);
        }


        public bool DeleteDish(DishDto dish)
        {
            var entity = mDtoMapper.Map(dish);
            return mDishRepository.Delete(entity);
        }

        public List<DishDto> GetAllDishes(string filterString)
        {
            var dishEntities = mDishRepository.GetAllDishes().ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                dishEntities = dishEntities.Where(x => x.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(dishEntities);
        }

        public void AddNewMeal(MealDto meal)
        {
            var entity = mDtoMapper.Map(meal);
            mMealRepository.AddNew(entity);
        }


        public bool DeleteMeal(MealDto meal)
        {
            var entity = mDtoMapper.Map(meal);
            return mMealRepository.Delete(entity);
        }

        public List<MealDto> GetAllMeals(string filterString)
        {
            var mealEntities = mMealRepository.GetAllMeals().ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                mealEntities = mealEntities.Where(x => x.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(mealEntities);
        }

        public List<DayDto> GetAllDays(string filterString)
        {
            var dayEntities = mDayRepository.GetAllDays().ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                dayEntities = dayEntities.Where(x => x.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(dayEntities);
        }


        public List<ProductsInDishDto> GetAllProductsInDish(string filterString)
        {
            var productListEntities = mProductsInDishRepository.GetAllProductsInDish().ToList();

            return mDtoMapper.Map(productListEntities);
        }

        public List<DishesInMealDto> GetAllDishesInMeal(string filterString)
        {
            var dishesListEntities = mDishesInMealRepository.GetAllDishesInMeal().ToList();

            return mDtoMapper.Map(dishesListEntities);
        }

        public List<MealsInDayDto> GetAllMealsInDay(string filterString)
        {
            var mealsListEntities = mMealsInDayRepository.GetAllMealsInDay().ToList();

            return mDtoMapper.Map(mealsListEntities);
        }


        public List<DaysInShoppingListDto> GetAllDaysInShoppingList(string filterString)
        {
            var daysInShoppingListEntities = mDaysInShoppingListRepository.GetAllDaysInShoppingList().ToList();

                   
            return mDtoMapper.Map(daysInShoppingListEntities);
        }
           
 
        public List<ProductDto> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<ShoppingListDto> GetAllShoppingList(string filterString)
        {
            var shoppingListEntities = mShoppingListRepository.GetAllShoppingLists().ToList();
            if( !string.IsNullOrEmpty(filterString))
            {
                shoppingListEntities = shoppingListEntities.Where(ds => ds.Name.Contains(filterString)).ToList();
            }
            return mDtoMapper.Map(shoppingListEntities);
        }

        public bool DeleteDay(DayDto day)
        {
            var entity = mDtoMapper.Map(day);
            return mDayRepository.Delete(entity);
        }

        public bool DeleteShoppingList(ShoppingListDto shoppingList)
        {
            var entity = mDtoMapper.Map(shoppingList);
            return mShoppingListRepository.Delete(entity);
        }

    }
}
