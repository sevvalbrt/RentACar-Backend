using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.RentDate == null)
            {
                return new ErrorResult(Messages.NotCarRented);
            }
            else
            {
                _rentalDal.Add(rental);

                return new SuccessResult(Messages.CarRented);
            }
        }

        
    }
}
