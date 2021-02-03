using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("Description:"+ cars.Description+"\t"+"ModelYear:"+ cars.ModelYear);
            }
            Console.ReadLine();
        }
    }
}
