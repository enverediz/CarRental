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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id

                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                                                          
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto 
                             {
                                 CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, DailyPrice = c.DailyPrice, ImagePath = ci.ImagePath 
                             };
                
                return result.ToList();
            }
        }

        public List<CarImageDetailDto> GetCarImageDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join ci in context.CarImages
                             on c.Id equals ci.CarId

                             select new CarImageDetailDto
                             {                                 
                                 CarName = c.CarName,
                                 ImagePath = ci.ImagePath                                 
                             };

                return result.ToList();
            }
        }

    }
}
