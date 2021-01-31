using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class DaysInShoppingList : BaseEntity
    {

        public int DayId { get; set; }

        public Day Day { get; set; }

        public int ShoppingListId { get; set; }

        public ShoppingList ShoppingList{get; set;}

    }
    }
