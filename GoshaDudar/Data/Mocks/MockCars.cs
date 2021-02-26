using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data.Interfaces;
using GoshaDudar.Data.Models;

namespace GoshaDudar.Data.Mocks
{
    public class MockCars:IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> GetAllCars 
        {
            get
            {
                return new List<Car>
                {
                    new Car{
                        Name = "Tesla Model S",
                        ShortDesc = "Fast n Comfortable",
                        LongDesc = "Model S is built for speed and range, with beyond ludicrous acceleration, unparalleled performance and a refined design", 
                        Img = "/img/tesla.jpg", 
                        Price = 45000,
                        IsFavourite = true,
                        Available = true, 
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDesc = "Fast as Fury",
                        LongDesc = "The M3 is powered by BMW's S58 twin-turbo 3.0-liter inline-six, which produces 473 hp and 406 lb-ft of torque in standard form. It's paired to a six-speed manual or eight-speed automatic transmission that drives the rear wheels exclusively.",
                        Img = "/img/bmw_m3.jpg",
                        Price = 15000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car{
                        Name = "Nissan Leaf",
                        ShortDesc = "Nothing to say",
                        LongDesc = "Nissan LEAF is a pure electric vehicle powered only by electricity, and its battery can be charged at home. The electric motor that replaces the conventional engine offers a totally different driving experience with quiet and responsive acceleration.",
                        Img = "/img/nissan_leaf.jpg",
                        Price = 10000,
                        IsFavourite = false,
                        Available = false,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car{
                        Name = "GLE 450",
                        ShortDesc = "a 48-volt mild-hybrid system, and all-wheel drive",
                        LongDesc = "The GLE 450 SUV starts at $62,500, and it comes with a 362-horsepower turbocharged inline-six engine, a 48-volt mild-hybrid system, and all-wheel drive. You can also add power soft-close doors, a sport exhaust, and an adaptive air suspension. All other options carry over.",
                        Img = "/img/gle_450.jpg",
                        Price = 62500,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car{
                        Name = "Mercedes-Benz W140",
                        ShortDesc = "W140 S-Class at Geneva Motor Show in March 1991",
                        LongDesc = "The Mercedes-Benz W140 is a series of flagship vehicles that were manufactured by the German automotive company Mercedes-Benz from 1991 to 1998. Mercedes-Benz unveiled the W140 S-Class at Geneva Motor Show in March 1991 with sales launch in April 1991 and North American launch in August 1991.",
                        Img = "/img/w140.jpg",
                        Price = 45000,
                        IsFavourite = false,
                        Available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                };

            }
          

        }
    
        public IEnumerable<Car> GetFavCars { get; set; }
        public Car GetExactCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
