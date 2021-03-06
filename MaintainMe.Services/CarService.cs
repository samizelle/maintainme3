﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Contracts;
using MaintainMe.Data;
using MaintainMe.Models;

namespace MaintainMe.Services
{
    public class CarService : ICarService
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
                                    CustomerLastName = e.Customer.LastName,
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

        /*public IEnumerable<ListDetailItem> GetCarsByCustomerId()
        {
            List<ListDetailItem> listDetailItem = new List<ListDetailItem>();
            List<int> CustomerId = new List<int>();
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var car in ctx.Cars)
                {
                    if (!CustomerId.Contains(car.CustomerId))
                    {
                        CustomerId.Add(car.CustomerId);
                    }
                }

                foreach (var id in CustomerId)
                {
                    var query = ctx
                        .Customers
                        .Single(e => e.CustomerId == id);
                    listDetailItem.Add(new ListDetailItem
                    {
                        CustomerId = id,
                        car = GetCustomerCarsById(id).ToArray()
                    });

                    return ListDetailItem;
                }
            }
        }*/
        
        public IEnumerable<CustomerCarListItem> GetCustomerCarsById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cars
                    .Where(e => e.CustomerId == customerId)
                    .Select(e =>
                    new CustomerCarListItem
                    {
                        CustomerId = e.CustomerId,
                        CarId = e.CarId,
                        CarMake = e.CarMake,
                        CarModel = e.CarModel
                    });

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
                        .Single(e => e.CarId == carId);
                return
                    new CarDetail
                    {
                        CarId = entity.CarId,
                        CustomerId = entity.CustomerId,
                        LastName = entity.Customer.LastName,
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

        public string GetCustomerName (int id)
        {
            string customerName;
            using (var ctx = new ApplicationDbContext())
            {
                var customer =
                    ctx.
                    Customers.Single(c => c.CustomerId == id);

                customerName = customer.LastName;
            }
            return customerName;
        }
    }
}
