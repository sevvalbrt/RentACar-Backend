using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {

            _carDal.Add(car);

            return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetBrandId(int brandId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == brandId));
        }

        public IDataResult<Car> GetColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            return new SuccessResult(Messages.ProductUpdated);
        }

    }
}
