namespace DietaApp.Core.Dtos
{
    public class Meal2Dto
    {
        public string dishName { get; set; }

    }

    public class Dish2Dto
    {
        public string dishName { get; set; }
        public Dish3Dto products { get; set; }
    }

  

    public class Dish3Dto
    {
        public string productName { get; set; }
        public int weight { get; set; }

    }
    public class Day2Dto
    {
        public string mealName { get; set; }
    }
    public class ShoppingList2Dto
    {
        public string dayName { get; set; }
    }

}
