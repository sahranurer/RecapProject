using Core.DataAccess.EntitiyFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors on cr.ColorId equals cl.Id
                             join br in context.Brands on cr.BrandId equals br.Id
                             select new CarDetailDto {  CarId=cr.CarId, CarName = cr.Description, BrandName = br.Name, 
                                 ColorName = cl.Name, DailyPrice = cr.DailyPrice };
                return result.ToList(); //
                           
            }
        }
    }
}
