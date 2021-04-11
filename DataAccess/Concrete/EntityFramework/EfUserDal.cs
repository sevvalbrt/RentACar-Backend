using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapDemoContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaim
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public IResult AddUserAsCustomer()
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {

                var resultUser = context.User.OrderByDescending(u => u.Id).FirstOrDefault();

                if (resultUser.Id != -1)
                {
                    Customer customer = new Customer() { UserId = resultUser.Id, CompanyName = resultUser.FirstName + " " + resultUser.LastName };
                    context.Customer.Add(customer);
                    context.SaveChanges();
                    return new SuccessResult();
                }

                return new ErrorResult();
            }
        }
    }
}