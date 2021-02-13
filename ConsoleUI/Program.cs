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
            //ColorTest();
            //BrandTest();
            //RentalTest();
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

            //carManager.Add(car);
            //carManager.Add(car1);
            var result = carManager.GetCarDetails();

            Console.WriteLine("Details Of Cars");
            Console.WriteLine("Description\t" + "Brand\t" + "Color\t" + "Daily Price\t" + "Company Name\t" + "Rent Date\t\t" + "Return Date");

            foreach (var cars in result.Data)
            {
                Console.WriteLine(cars.Description + "\t\t" + cars.BrandName + "\t" + cars.ColorName + "\t" + cars.DailyPrice
                    + "\t\t" + cars.CompanyName + "\t" + cars.RentDate + "\t" + cars.ReturnDate);

            }

        }

        private static void ColorTest()
        {
            Color color = new Color();
            color.Id = 3;
            color.ColorName = "Blue";

            ColorManager colorManager = new ColorManager(new EfColorDal());

            //colorManager.Add(color);

            Console.WriteLine("\nAll Colors");
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

            //brandManager.Add(brand);

            Console.WriteLine("\nAll Brands");
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
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                Id=4,
                CarId = 3,
                CustomerId = 1,
                RentDate = new DateTime(2021, 2, 13),
                ReturnDate = new DateTime(2021, 3, 15)
            });
            Console.WriteLine(result.Message);
        }
    }
}
