using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            BrandTest();
            ColorTest();
        }

        private static void BrandTest()
        {
            Console.WriteLine("*********Brand-Test***********");
            Console.WriteLine("--GetAll()--");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine("--GetById--");
            foreach (var brand in brandManager.GetByName("hello").Data)
            {
                Console.WriteLine(brand.Name);
            }
            //Brand brandManager1 = brandManager.GetById(2);
            //Console.WriteLine(brandManager1.Id+" "+brandManager1.Name);



        }
        private static void ColorTest()
        {
            Console.WriteLine("******Color-Test*******");
            Console.WriteLine("--GetAll--");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
          
            Console.WriteLine("--AddColor--");
            Color color1 = new Color
            {
                Id = 2,
                Name = "Red"
            };
           
        }

        private static void CarTest()
        {
            Console.WriteLine("******Car-Test*******");
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("********AddCars***********");

            Car car1 = new Car
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2020",
                DailyPrice = 0,
                Description = "BMW 320i First Edition"
            };

            carManager.Add(car1);

            

            Console.WriteLine("***GetById***");
            foreach (var car in carManager.GetCarsByBrandId(11).Data)
            {
                Console.WriteLine(car.CarId);
            }


            Console.WriteLine("*******Join-Test********");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName+" "+car.BrandName+" "+car.ColorName+" "+car.DailyPrice);
            }
            
            
        }
    }
}
