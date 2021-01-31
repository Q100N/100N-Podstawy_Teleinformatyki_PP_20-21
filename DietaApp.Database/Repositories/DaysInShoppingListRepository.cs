using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class DaysInShoppingListRepository : BaseRepository<DaysInShoppingList>, IDaysInShoppingListRepository
    {
        protected override DbSet<DaysInShoppingList> DbSet => mDbContext.DaysInShoppingLists;

        public DaysInShoppingListRepository(DietaAppDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<DaysInShoppingList> GetAllDaysInShoppingList()
        {            return DbSet.Select(x => x);
        }


    }

}
