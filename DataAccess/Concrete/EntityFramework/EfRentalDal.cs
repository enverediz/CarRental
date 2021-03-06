using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails() 
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join u in context.Users
                             on r.UserId equals u.Id

                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             select new RentalDetailDto
                             {
                                 FirstName = u.FirstName, LastName = u.LastName, CompanyName= c.CompanyName, Email = u.Email,
                                 RentDate = r.RentDate, ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
