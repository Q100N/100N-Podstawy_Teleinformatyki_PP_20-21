using DietaApp.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DietaApp
{
    public class DaysListViewModel
    {
        public List<Day> days { get; set; }
        public SelectList Days { get; set; }

    }
}
