using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data.Interfaces;
using GoshaDudar.Data.Models;
using GoshaDudar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoshaDudar.Controllers
{
    public class CarsController : Controller
    {

        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory allCategories)
        {
            this._allCars = allCars;
            this._allCategories = allCategories;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            string CurrCategory = string.Empty;
            IEnumerable<Car> Cars = null;

            if (string.IsNullOrEmpty(category))
             Cars = _allCars.GetAllCars.OrderBy(i => i.Id);
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    Cars = _allCars.GetAllCars.Where(i => i.Category.CategoryName.Equals("Электромобили"))
                        .OrderBy(i => i.Id);
                    CurrCategory = "Електрические автомобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    Cars = _allCars.GetAllCars.Where(i => i.Category.CategoryName.Equals("Классические автомобили"))
                        .OrderBy(i => i.Id);
                    CurrCategory = "Топливные автомобили";
                }


            }

            var CarObj = new CarsListViewModel
            {
                AllCars = Cars,
                CurrentCategory = CurrCategory
            };

            ViewBag.Title = "Страница с автомобилями";

            return View(CarObj);
        }

    }
}
