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
                             join c in context.Car on r.CarId equals c.Id
                             join cu in context.Customer on r.CustomerId equals cu.Id
                             join u in context.User on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CarName = c.Description,
                                 CompanyName = cu.CompanyName,
                                 CarId = c.Id,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
