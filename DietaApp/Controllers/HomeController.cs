using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DietaApp.Core;
using DietaApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DietaApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {


            return View();
        }
        [Route("/Home/Confirmation/{name}/{table}/{controler}/{method}")]
        public IActionResult Confirmation(string name, string table, string controler, string method)
        {
            ConfirmationViewModel confirmationViewModel = new ConfirmationViewModel
            {
                name = name,
                table = table,
                controler = controler,
                method = method
            };

            return View(confirmationViewModel);


        }


    }
}
