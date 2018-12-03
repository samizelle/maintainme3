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
                    Make = model.Make,
                    Model = model.Model
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
                                    Make = e.Make,
                                    Model = e.Model
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
