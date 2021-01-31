using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp
{
    public class DayViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public List<DaysInShoppingListViewModel> daysInShoppingLists { get; set; }

        public List<MealsInDayViewModel> mealsInDay { get; set; }

    }
}
