using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rn in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join cr in context.Cars on rn.CarId equals cr.Id
                             join cs in context.Costumers on rn.CustomerId equals cs.Id
                             join br in context.Brands on cr.BrandId equals br.Id
                             join u in context.Users on cs.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rn.Id,
                                 BrandName = br.Name,
                                 CarName = cr.Description,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CompanyName = cs.CompanyName,
                                 RentDate = rn.RentDate,
                                 ReturnDate = rn.ReturnDate,
                             };
                return result.ToList();
            }
        }
    }
}
