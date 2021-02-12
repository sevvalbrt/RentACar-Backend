using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarTest();
            ColorTest();
            BrandTest();
            Console.ReadLine();

        }

        private static void CarTest()
        {
            Car car = new Car();
            car.Id = 3;
            car.BrandId = 1;
            car.ColorId = 2;
            car.ModelYear = 1975;
            car.DailyPrice = 1500;
            car.Description = "Car 3";

            Car car1 = new Car();
            car1.Id = 4;
            car1.BrandId = 2;
            car1.ColorId = 1;
            car1.ModelYear = 1960;
            car1.DailyPrice = 900;
            car1.Description = "Car 4";

            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(car);
            carManager.Add(car1);

            Console.WriteLine("Details Of Cars");
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var cars in result.Data)
                {
                    Console.WriteLine(cars.Description + "/" + cars.BrandName + "/" + cars.ColorName + "/" + cars.DailyPrice);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            Color color = new Color();
            color.Id = 3;
            color.ColorName = "Blue";

            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(color);

            Console.WriteLine("All Colors");
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var colors in result.Data)
                {
                    Console.WriteLine(colors.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            Brand brand = new Brand();
            brand.Id = 3;
            brand.BrandName = "Ford";

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(brand);

            Console.WriteLine("All Brands");
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brands in result.Data)
                {
                    Console.WriteLine(brands.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

    }
}
