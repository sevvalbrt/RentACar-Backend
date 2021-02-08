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
            Car car = new Car();
            car.Id = 4;
            car.BrandId = 1;
            car.ColorId = 2;
            car.ModelYear = 1975;
            car.DailyPrice = 1500;
            car.Description = "Car 4";

            Car car1 = new Car();
            car1.Id = 5;
            car1.BrandId = 2;
            car1.ColorId = 1;
            car1.ModelYear = 1960;
            car1.DailyPrice = 900;
            car1.Description = "Car 5";

            Color color = new Color();
            color.Id = 3;
            color.ColorName = "Blue";

            Brand brand = new Brand();
            brand.Id = 3;
            brand.BrandName = "Ford";


            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(car);
            carManager.Add(car1);

            car.DailyPrice = 1200;
            carManager.Update(car);


            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(brand);
            

            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(color);

            Console.WriteLine("All Cars");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);

            }

            Console.WriteLine("\nCar By Id");
            foreach (var cars in carManager.GetById(1))
            {
                Console.WriteLine(cars.Description);
            }

            Console.WriteLine("\nDetails Of Cars");
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine(cars.Description + "/" + cars.BrandName + "/" + cars.ColorName + "/" + cars.DailyPrice);

            }

            brandManager.Delete(brand);

            Console.WriteLine("\nAll Brands");
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine(brands.BrandName);
            }

            Console.WriteLine("\nAll Colors");
            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine(colors.ColorName);

            }

            Console.ReadLine();
        }
    }
}
