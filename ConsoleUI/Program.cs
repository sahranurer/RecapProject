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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();
            RentalDeleteTest();
            //RentalUpdateTest();
            //RentalGetAll();
        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.CarId+"//"+rental.CustomerId+"//"+rental.RentDate.ToString());
            }
        }

        private static void RentalUpdateTest()
        {
            RentalManager rentalsManager = new RentalManager(new EfRentalDal());
            Rental updateRentals = new Rental { Id = 3, CarId = 2, CustomerId = 2, RentDate = DateTime.Now.Date, ReturnDate = DateTime.Now };
            var result = rentalsManager.Update(updateRentals);
            if (result.Success == false)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalTest()
        {
            Console.WriteLine("Rental-Test");
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CarId = 2, CustomerId = 2, RentDate = DateTime.Today, ReturnDate = DateTime.Now };
            var result = rentalManager.Add(rental);
            if (result.Success == false)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void RentalDeleteTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental {Id=3, CarId = 2, CustomerId = 2, RentDate = DateTime.Today };
            var resultdelete = rentalManager.Delete(rental);
            if (resultdelete.Success == false)
            {

                Console.WriteLine(resultdelete.Message);
            }
            else
            {
                Console.WriteLine(resultdelete.Message);
            }
        }
        private static void CustomerTest()
        {
            Console.WriteLine("Customer-Test");
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer { UserId = 1, CompanyName = "Toyoto" };
            var result = customerManager.Add(customer);
            Console.WriteLine(result.Success);

        }

        private static void UserTest()
        {
            Console.WriteLine("*****User-Test*****");

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
