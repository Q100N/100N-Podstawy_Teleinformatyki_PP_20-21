using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp.Core
{
    public class DayDto : BaseEntityDto
    {
        public string Name { get; set; }

        public List<DaysInShoppingListDto> DaysInShoppingListsDto { get; set; }

        public List<MealsInDayDto> MealInDaysDto { get; set; }

    }
}
