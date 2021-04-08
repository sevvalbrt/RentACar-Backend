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
        //public List<CarDetailDto> GetCarDetails()
        //{
        //    using (ReCapDemoContext context = new ReCapDemoContext())
        //    {
        //        var result = from car in context.Car
        //                     join brand in context.Brand on car.BrandId equals brand.Id
        //                     join color in context.Color on car.ColorId equals color.Id

        //                     select new CarDetailDto
        //                     {
        //                         Description = car.Description,
        //                         BrandName = brand.BrandName,
        //                         ColorName = color.ColorName,
        //                         DailyPrice = car.DailyPrice,
        //                     };

        //        return result.ToList();
        //    }
        //}

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from c in filter is null ? context.Car : context.Car.Where(filter)
                             join b in context.Brand on c.BrandId equals b.BrandId
                             join cl in context.Color on c.ColorId equals cl.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ColorId=cl.ColorId,
                                 BrandId=b.BrandId,
                                 Description = c.Description,
                                 ColorName = cl.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath = context.CarImage.Where(x => x.CarId == c.Id).FirstOrDefault().ImagePath
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandId(int brandId)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from car in context.Car
                             join brand in context.Brand on car.BrandId equals brand.BrandId
                             join color in context.Color on car.ColorId equals color.ColorId

                             select new CarDetailDto
                             {
                                 BrandId=brand.BrandId,
                                 Description = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear=car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = context.CarImage.Where(x => x.CarId == car.Id).FirstOrDefault().ImagePath
                             };

                return result.Where(c => c.BrandId == brandId).ToList();
            }
        }

        public List<CarDetailDto> GetCarsByColorId(int colorId)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from car in context.Car
                             join brand in context.Brand on car.BrandId equals brand.BrandId
                             join color in context.Color on car.ColorId equals color.ColorId

                             select new CarDetailDto
                             {
                                 ColorId = color.ColorId,
                                 Description = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = context.CarImage.Where(x => x.CarId == car.Id).FirstOrDefault().ImagePath
                             };

                return result.Where(c => c.ColorId == colorId).ToList();
            }
        }

    }
}
