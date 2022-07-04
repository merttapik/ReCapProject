﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
         IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
         IResult Add(Car car);
         IResult Delete(Car car);
         IResult Update(Car car);
        IDataResult<List<CarDetailDto>>  GetCarDetail();
        IDataResult<Car> GetById(int carId);

    }
}
