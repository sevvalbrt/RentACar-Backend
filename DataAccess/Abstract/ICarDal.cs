using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetCarByBrand(int brandId);
        List<CarDetailDto> GetCarByColor(int colorId);

    }
}
