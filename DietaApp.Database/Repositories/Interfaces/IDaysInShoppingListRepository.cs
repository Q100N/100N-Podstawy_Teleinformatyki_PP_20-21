using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    //Wykorzystanie napisanych metod
    public interface IDaysInShoppingListRepository : IRepository<DaysInShoppingList>
    {
        IEnumerable<DaysInShoppingList> GetAllDaysInShoppingList();
    }
}
