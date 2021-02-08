﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;


        public InMemoryCarDal()
        {
            _cars = new List<Car>
             {
                 new Car
                 {
                     Id = 1, BrandId = 1, ColorId = 001, DailyPrice = 20000, ModelYear = 2015, Description = "Bugatti"
                 },
                 new Car
                 {
                     Id = 2, BrandId = 2, ColorId = 001, DailyPrice = 10000, ModelYear = 2015, Description = "Mercedes"
                 },
                 new Car
                 {
                     Id = 3, BrandId = 3, ColorId = 001, DailyPrice = 15000, ModelYear = 2015, Description = "Audi"
                 },

                 new Car
                 {
                     Id = 4, BrandId = 4, ColorId = 001, DailyPrice = 3000, ModelYear = 2015, Description = "McLaren"
                 },

             };
        }








        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(crs => crs.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;


        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(crs => crs.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAllById(int Id)
        {
            return _cars.Where(crs => crs.Id == Id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
