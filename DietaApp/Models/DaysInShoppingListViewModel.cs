using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp
{
    public class DaysInShoppingListViewModel : BaseViewModel
    {

        public int DayId { get; set; }

        public DayViewModel Day { get; set; }

        public int ShoppingListId { get; set; }

        public ShoppingListViewModel ShoppingList { get; set; }

    }
}