using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);

        IResult Delete(Car car);

        IResult Update(Car car);

        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int carId);

        IDataResult<List<Car>> GetBrandId(int brandId);

        IDataResult<List<Car>> GetColorId(int ColorId);

        IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);


        IDataResult<List<CarDetailDto>> GetCarByBrand(int brandId);

        IDataResult<List<CarDetailDto>> GetCarByColor(int colorId);

        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car,bool>> filter=null);

        IDataResult<List<CarDetailDto>> GetCarDetail(int carId);


    }
}
