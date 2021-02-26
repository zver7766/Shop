using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data.Interfaces;
using GoshaDudar.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GoshaDudar.Data.Repository
{
    public class CarRepository : Interfaces.IAllCars
    {
        private readonly AppDBContent appDbContent;

        public CarRepository(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Car> GetAllCars => appDbContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDbContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetExactCar(int carId) => appDbContent.Car.FirstOrDefault(p => p.Id == carId);



    }
}
