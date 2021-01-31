using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Database.Entities
{
    public class ShoppingList : BaseEntity
    {
            
        public string Name { get; set; }

        public List<DaysInShoppingList> DaysInShoppingList { get; set; }

    }
}
