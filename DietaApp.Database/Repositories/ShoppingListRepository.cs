using System;
using System.Collections.Generic;
using System.Linq;
using DietaApp.Database.Entities;
using DietaApp.Database;
using Microsoft.EntityFrameworkCore;

namespace DietaApp.Database
{
    public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
        {
            protected override DbSet<ShoppingList> DbSet => mDbContext.ShoppingLists;

            public ShoppingListRepository(DietaAppDbContext dbContext) : base(dbContext)
            {


            }


            public IEnumerable<ShoppingList> GetAllShoppingLists()
            {
                return DbSet.Select(x => x);
            }

        }
    }

