using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietaApp
{
    public class ProductViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Wprowadź Nazwę produktu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź ilość Kcal na (100g/ml)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Wprowadź liczbę")]
        public int Kcal { get; set; }
        [Required(ErrorMessage = "Wybierz Jednostkę")]
        public string Unit { get; set; }
        [Required(ErrorMessage = "Wybierz Kategorię")]
        public string Category { get; set; }

        public List<ProductsInDishViewModel> ProductsInDish { get; set; }

    }

    public enum Unit
    {
        gram,
        ml
    }

    public enum Category
    {
        Mięso,
        Nabiał,
        Owoce,
        Warzywa,
        ProduktyZbozowe,
        Napoje,
        Mrożonki,
        Pieczywo
    }

}