﻿using System;
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
                    LastName = model.LastName
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
                                    LastName = e.LastName
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
                        .Single(e => e.CarOwnerId == carOwnerId/* && e.OwnerId == _userId*/);
                return
                    new CarOwnerDetail
                    {
                        CarOwnerId = entity.CarOwnerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName
                    };
            }
        }

        public bool UpdateCarOwner(CarOwnerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CarOwners
                        .Single(e => e.CarOwnerId == model.CarOwnerId/* && e.OwnerId == _userId*/);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

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
                        .Single(e => e.CarOwnerId == carOwnerId/* && e.OwnerId == _userId*/);

                ctx.CarOwners.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}