using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDemoContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from rental in context.Rental
                             join car in context.Car on rental.CarId equals car.Id
                             join customer in context.Customer on rental.CustomerId equals customer.Id
                             join brand in context.Brand on rental.BrandId equals brand.Id
                             select new RentalDetailDto
                             {
                                 Description = car.Description,
                                 BrandName=brand.BrandName,
                                 CustomerName=customer.FirstName + " " + customer.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                             };

                return result.ToList();
            }
        }
    }
}
