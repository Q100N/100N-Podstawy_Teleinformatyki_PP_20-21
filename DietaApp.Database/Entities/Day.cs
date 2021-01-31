using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class Day : BaseEntity
    {
        public string Name { get; set; }

        public List<DaysInShoppingList> DaysInShoppingLists { get; set; }

        public List<MealsInDay> MealInDays { get; set; }
    }
}
