using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Core
{
    public class DaysInShoppingListDto : BaseEntityDto
    {

        public int DayId { get; set; }

        public DayDto Day { get; set; }

        public int ShoppingListId { get; set; }

        public ShoppingListDto ShoppingList { get; set;}

    }
    }
