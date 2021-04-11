using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, ReCapDemoContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetail()
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from user in context.User
                             join customer in context.Customer
                             on user.Id equals customer.UserId
                             select new CustomerDetailDto
                             {
                                 UserId=user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName
                             };
                return result.ToList();
            }
        }



    }
}
