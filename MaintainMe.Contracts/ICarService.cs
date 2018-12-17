using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Models;

namespace MaintainMe.Contracts
{
    public interface ICarService
    {
        bool CreateCar(CarCreate model);
        IEnumerable<CarListItem> GetCars();
        int GetCarOwnerByCarId(int carId);
        IEnumerable<CustomerCarListItem> GetCustomerCarsById(int customerId);
        CarDetail GetCarById(int carId);
        bool UpdateCar(CarEdit model);
        bool DeleteCar(int carId);
        string GetCustomerName(int id);
    }
}
