﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

      

        public void Add(Car car)
        {
            if ((car.Description.Length >= 2) && (car.DailyPrice > 0))
            {
                _carDal.Add(car);
                Console.WriteLine("New Car Added.");
            }
            else
            {
                Console.WriteLine("New failure.");
            }
            
        }

     

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //iş kodları
            //yetkisi var mı?
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice>=max);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=>c.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

      

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}