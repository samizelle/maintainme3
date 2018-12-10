using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;
using MaintainMe.Models;

namespace MaintainMe.Services
{
    public class CarOwnerService
    {
        private readonly Guid _userId;

        public CarOwnerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCarOwner(CarOwnerCreate model)
        {
            var entity =
                new CarOwner()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    CityStZip = model.CityStZip
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CarOwners.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CarOwnerListItem> GetCarOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CarOwners
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CarOwnerListItem
                                {
                                    CarOwnerId = e.CarOwnerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Address = e.Address,
                                    CityStZip = e.CityStZip
                                }
                        );
                return query.ToArray();
            }
        }

        public CarOwnerDetail GetCarOwnerById(int carOwnerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CarOwners
                        .Single(e => e.CarOwnerId == carOwnerId && e.OwnerId == _userId);
                return
                    new CarOwnerDetail
                    {
                        CarOwnerId = entity.CarOwnerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Address = entity.Address,
                        CityStZip = entity.CityStZip
                    };
            }
        }

        public IEnumerable<CarListItem> GetCarOwnerCar(int CarOwnerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cars
                    .Where(e => e.CarOwnerId == CarOwnerId)
                    .Select(e =>
                    new CarListItem
                    {
                        CarId = e.CarId,
                        CarModel = e.CarModel,
                        CarMake = e.CarMake
                    });

                return query.ToArray();
            }
        }

        public bool UpdateCarOwner(CarOwnerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CarOwners
                        .Single(e => e.CarOwnerId == model.CarOwnerId && e.OwnerId == _userId);

                entity.CarOwnerId = model.CarOwnerId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Address = model.Address;
                entity.CityStZip = model.CityStZip;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCarOwner(int carOwnerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CarOwners
                        .Single(e => e.CarOwnerId == carOwnerId && e.OwnerId == _userId);

                ctx.CarOwners.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
