using System;
using System.Collections.Generic;
using DietaApp.Database.Entities;

namespace DietaApp.Database
{
    public interface IShoppingListRepository : IRepository<ShoppingList>
    {
        IEnumerable<ShoppingList> GetAllShoppingLists();
    }
}
