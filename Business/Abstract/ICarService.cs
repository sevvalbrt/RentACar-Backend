using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);

        void Delete(Car car);

        void Update(Car car);

        List<Car> GetAll();

        List<Car> GetById(int carId);

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        List<Car> GetByUnitPrice(decimal min, decimal max);

        List<CarDetailDto> GetCarDetails();
    }
}
