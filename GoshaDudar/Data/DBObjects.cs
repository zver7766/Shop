using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GoshaDudar.Data
{
    public class DBObjects
    {
        public async static void Initial(AppDBContent content)
        {
            

            if(!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
              // content.Car.RemoveRange(Cars.Select(c => c));
                content.Car.AddRange(Cars.Select(c => c));
            }

            await content.SaveChangesAsync();
        }

        private static List<Car> Car;

        private static List<Car> Cars
        {
            get
            {
                if (Car == null)
                {
                    var list = new Car[]
                    {
                        new Car
                        {
                            Name = "Tesla Model S",
                            ShortDesc = "Fast n Comfortable",
                            LongDesc =
                                "Model S is built for speed and range, with beyond ludicrous acceleration, unparalleled performance and a refined design",
                            Img = "/img/tesla.jpg",
                            Price = 45000,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Электромобили"]
                        },
                        new Car
                        {
                            Name = "BMW M3",
                            ShortDesc = "Fast as Fury",
                            LongDesc =
                                "The M3 is powered by BMW's S58 twin-turbo 3.0-liter inline-six, which produces 473 hp and 406 lb-ft of torque in standard form. It's paired to a six-speed manual or eight-speed automatic transmission that drives the rear wheels exclusively.",
                            Img = "/img/bmw_m3.jpg",
                            Price = 15000,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Классические автомобили"]
                        },
                        new Car
                        {
                            Name = "Nissan Leaf",
                            ShortDesc = "Nothing to say",
                            LongDesc =
                                "Nissan LEAF is a pure electric vehicle powered only by electricity, and its battery can be charged at home. The electric motor that replaces the conventional engine offers a totally different driving experience with quiet and responsive acceleration.",
                            Img = "/img/nissan_leaf.jpg",
                            Price = 10000,
                            IsFavourite = false,
                            Available = false,
                            Category = Categories["Электромобили"]

                        },
                        new Car
                        {
                            Name = "GLE 450",
                            ShortDesc = "A 48-volt mild-hybrid system, and all-wheel drive",
                            LongDesc =
                                "The GLE 450 SUV starts at $62,500, and it comes with a 362-horsepower turbocharged inline-six engine, a 48-volt mild-hybrid system, and all-wheel drive. You can also add power soft-close doors, a sport exhaust, and an adaptive air suspension. All other options carry over.",
                            Img = "/img/gle_450.jpg",
                            Price = 62500,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Классические автомобили"]
                        },
                        new Car
                        {
                            Name = "Mercedes-Benz W140",
                            ShortDesc = "W140 S-Class at Geneva Motor Show in March 1991",
                            LongDesc =
                                "The Mercedes-Benz W140 is a series of flagship vehicles that were manufactured by the German automotive company Mercedes-Benz from 1991 to 1998. Mercedes-Benz unveiled the W140 S-Class at Geneva Motor Show in March 1991 with sales launch in April 1991 and North American launch in August 1991.",
                            Img = "/img/w140.jpg",
                            Price = 45000,
                            IsFavourite = false,
                            Available = false,
                            Category = Categories["Классические автомобили"]
                        }
                    };
                    Car = new List<Car>();
                    foreach (var element in list)
                        Car.Add(element);
                }

                return Car;
            }
        }

        private static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (Category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Электромобили", Description = "Современный вид транспорта"},
                        new Category { CategoryName = "Классические автомобили", Description = "Машины с двигателем внутреннего сгорания" }
                   };
                    Category = new Dictionary<string, Category>();
                    foreach (var element in list) 
                        Category.Add(element.CategoryName,element);
                }

                return Category;
            }
        }
    }
}
