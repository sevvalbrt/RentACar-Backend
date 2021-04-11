using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDemoContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from r in filter == null ? context.Rental : context.Rental.Where(filter)
                             join c in context.Car on r.CarId equals c.CarId
                             join cu in context.Customer on r.CustomerId equals cu.Id
                             join u in context.User on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 
                                 FirstName = u.FirstName, 
                                 LastName= u.LastName,
                                 CarName = c.Description,
                                 CarId = c.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }

        public List<RentalDetailDto> UserRentedCars(int id)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from rental in context.Rental
                             join car in context.Car
                             on rental.CarId equals car.CarId
                             join customer in context.Customer
                             on rental.CustomerId equals customer.Id
                             join user in context.User
                             on customer.UserId equals user.Id
                             join brand in context.Brand
                             on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CarName = car.Description,
                                 CarId = car.CarId,
                                 DailyPrice = car.DailyPrice,
                                 ReturnDate = rental.ReturnDate,
                                 RentDate = rental.RentDate,
                                 BrandName = brand.BrandName,
                                 UserId = user.Id
                             };
                return result.Where(r => r.UserId == id).ToList();
            }
        }
    }
}
