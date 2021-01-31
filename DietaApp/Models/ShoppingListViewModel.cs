using DietaApp.Database;
using DietaApp.Database.Entities;
using System.Collections.Generic;

namespace DietaApp
{
    public class ShoppingListViewModel : BaseViewModel
    {
        /*private readonly DietaAppDbContext _dietaAppDbContext;

        public ShoppingListViewModel(DietaAppDbContext dietaAppDbContext)
        {

            _dietaAppDbContext = dietaAppDbContext;
        }
*/
        public string Name { get; set; }

        public List<DaysInShoppingListViewModel> DaysInShoppingList { get; set; }
        public List<ShoppingList> shoppingLists { get; set; }
        public List<Day> days { get; set; }


        public Dictionary<string, int> sumDistinctProduct = new Dictionary<string, int>();
        public Dictionary<string, int> sumWeightProduct = new Dictionary<string, int>();
        public Dictionary<string, string> categoryProduct = new Dictionary<string, string>();
   
    }
    
}
