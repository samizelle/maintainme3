using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;
using MaintainMe.Models;

namespace MaintainMe.Services
{
    public class CarService
    {
        private readonly Guid _userId;

        public CarService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCar(CarCreate model)
        {
            var entity =
                new Car()
                {
                    OwnerId = _userId,
                    CustomerId = model.CustomerId,
                    CarMake = model.CarMake,
                    CarModel = model.CarModel
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cars.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CarListItem> GetCars()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cars
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CarListItem
                                {
                                    CarId = e.CarId,
                                    CustomerId = e.CustomerId,
                                    CustomerLastName = e.Customers.LastName,
                                    CarMake = e.CarMake,
                                    CarModel = e.CarModel
                                }
                        );

                return query.ToArray();
            }
        }

        /*TODO 1
            Write a method called GetCarOwnerByCarId that returns the Car Owner Id.
        */

        public int GetCarOwnerByCarId(int carId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Cars.Single(e => e.CarId == carId);

                return query.CustomerId;
            }
        }

        public CarDetail GetCarById(int carId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cars
                        .Single(e => e.CarId == carId);
                return
                    new CarDetail
                    {
                        CarId = entity.CarId,
                        CustomerId = entity.CustomerId,
                        CustomerLastName = entity.Customers.LastName,
                        CarMake = entity.CarMake,
                        CarModel = entity.CarModel
                    };
            }
        }

        public bool UpdateCar(CarEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cars
                        .Single(e => e.CarId == model.CarId && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.CarMake = model.CarMake;
                entity.CarModel = model.CarModel;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCar(int carId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cars
                        .Single(e => e.CarId == carId && e.OwnerId == _userId);

                ctx.Cars.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
