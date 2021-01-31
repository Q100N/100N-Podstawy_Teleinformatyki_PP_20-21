using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Core
{
    public class ShoppingListDto : BaseEntityDto
    {
        public string Name { get; set; }

        //public virtual DayDto Day { get; set; }

        public List<DaysInShoppingListDto> DaysInShoppingList { get; set; }

    }
}
