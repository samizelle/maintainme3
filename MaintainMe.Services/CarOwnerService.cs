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
                new Customer()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    CityStZip = model.CityStZip
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CarOwnerListItem> GetCarOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CarOwnerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Address = e.Address,
                                    CityStZip = e.CityStZip
                                }
                        );
                return query.ToArray();
            }
        }

        public CarOwnerDetail GetCarOwnerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);
                return
                    new CarOwnerDetail
                    {
                        CustomerId = entity.CustomerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Address = entity.Address,
                        CityStZip = entity.CityStZip
                    };
            }
        }

        public IEnumerable<CarListItem> GetCarOwnerCar(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cars
                    .Where(e => e.CustomerId == customerId)
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
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Address = model.Address;
                entity.CityStZip = model.CityStZip;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCarOwner(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
