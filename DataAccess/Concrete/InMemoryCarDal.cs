using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=500000,ModelYear="1999",Description="Bu araba eski bir arabadır"},
            new Car{CarId=2,BrandId=1,ColorId=1,DailyPrice=1000000,ModelYear="2000",Description="Bu araba yeni bir arabadır"},
            new Car{CarId=3,BrandId=1,ColorId=1,DailyPrice=5000000,ModelYear="1980",Description="Bu araba eski bir arabadır"},
            new Car{CarId=4,BrandId=2,ColorId=1,DailyPrice=8800000,ModelYear="2021",Description="Bu araba yeni bir arabadır"},
            new Car{CarId=5,BrandId=2,ColorId=1,DailyPrice=1100000,ModelYear="2017",Description="Bu araba eski bir arabadır"},
        };

        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
