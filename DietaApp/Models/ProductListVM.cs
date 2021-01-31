using DietaApp.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietaApp.Models
{
    public class ProductListVM
    {
        public List<Product> products { get; set; }
        public List<Dish> dishes { get; set; }


        public SelectList Products { get; set; }
        public int? ProductId { get; set; }

        public string Name { get; set; }


    }

}
