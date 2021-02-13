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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDemoContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from car in context.Car
                             join brand in context.Brand
                             on car.BrandId equals brand.Id
                             join color in context.Color on car.ColorId equals color.Id
                             join rental in context.Rental on car.RentalId equals rental.Id
                             join customer in context.Customer on car.CustomerId equals customer.Id

                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 Description = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 CompanyName = customer.CompanyName
                             };

                return result.ToList();
            }
        }
    }
}
