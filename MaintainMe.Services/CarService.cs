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
                    CarOwnerId = model.CarOwnerId,
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
                                    CarOwnerId = e.CarOwnerId,
                                    CarMake = e.CarMake,
                                    CarModel = e.CarModel
                                }
                        );

                return query.ToArray();
            }
        }

        public CarDetail GetCarById(int carId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cars
                        .Single(e => e.CarId == carId && e.OwnerId == _userId);
                return
                    new CarDetail
                    {
                        CarId = entity.CarId,
                        CarOwnerId = entity.CarOwnerId,
                        CarMake = entity.CarMake,
                        CarModel = entity.CarModel
                    };
            }
        }

        public bool UpdateCar(CarEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                        .Cars
                        .Single(e => e.CarId == model.CarId && e.OwnerId == _userId);

                entity.CarOwnerId = model.CarOwnerId;
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
