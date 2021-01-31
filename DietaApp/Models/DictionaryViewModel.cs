using DietaApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietaApp.Models
{
    public class DictionaryViewModel
    {
        public Dictionary<string, int> sumDistinctProduct=new Dictionary<string, int>();
        public Dictionary<string, int> sumWeightProduct = new Dictionary<string, int>();
        //public List<Product>products;
    }
}
