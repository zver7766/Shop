using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data.Models;

namespace GoshaDudar.Data.Interfaces
{
   public interface IAllCars
    {
        IEnumerable<Car> GetAllCars { get; }

        IEnumerable<Car> GetFavCars { get; }

        Car GetExactCar(int carId);
    }
}
