using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ReCapProject
{
    class Program
    {
        static void Main(string[] args)
        {
          //  carTest();



          ICarDal efCarDal = new EfCarDal();
          ICarService carService = new CarManager(efCarDal);

          Car car1 = new Car()
              {BrandId = 001, ColorId = 01, ModelYear = 2000, DailyPrice = 25000, Description = "Tofaş Şahin"};
          Car car2 = new Car()
              { BrandId = 002, ColorId = 02, ModelYear = 2001, DailyPrice = 35000, Description = "Volswagen Polo" };
          Car car3 = new Car()
              { BrandId = 003, ColorId = 03, ModelYear = 2002, DailyPrice = 55000, Description = "Renault Megane" };
          Car car4 = new Car()
              { BrandId = 004, ColorId = 04, ModelYear = 2004, DailyPrice = 75000, Description = "Mercedes AMG" };
          Car car5 = new Car()
              { BrandId = 005, ColorId = 05, ModelYear = 2005, DailyPrice = 10000, Description = "Fiat Linea" };


          Console.WriteLine("*******Tüm Kayıtları Okumaktadır.*************");
          foreach (var car in carService.GetAll())
          {
              Console.WriteLine(car.Description);
          }

          Console.WriteLine("*******Brand ID'ye Göre Filtreleme Yapılmaktadır.*************");
          foreach (var car in carService.GetCarsByBrandId(2))
          {
              Console.WriteLine(car.Description);
          }

          Console.WriteLine("*******Brand ID'ye Göre Filtreleme Yapılmaktadır.*************");
          foreach (var car in carService.GetCarsByBrandId(2))
          {
              Console.WriteLine(car.Description);
          }

          Console.WriteLine(@"----------------Yeni Giriş Denemesi (Hatalı\ DailyPrice > 0 Hatası)----------------------");

          carService.Add(new Car() { BrandId = 3, ColorId = 3, ModelYear = 2014, DailyPrice = 0, Description = "Renault Clio" });
          
          Console.WriteLine(@"----------------Yeni Giriş Denemesi (Hatalı\ Açıklama en az iki karakter olmalıdır. )----------------------");

          carService.Add(new Car() {  BrandId = 3, ColorId = 3, ModelYear = 2014, DailyPrice = 400, Description = "R" });

            DbInsert(carService, car1,car2,car3,car4,car5);


            Console.ReadLine();
        }

       
        private static void DbInsert(ICarService carService, Car car1, Car car2, Car car3, Car car4, Car car5)
        {
            Console.WriteLine("************ Araçlar veritabanına Kaydedilmektedir.************");

            List<Car> cars = new List<Car> {car1, car2, car3, car4, car5};

            int say = 1;

            foreach (var car in cars)
            {
                Console.WriteLine(say + "." + car.Description + " Aracı Kaydedilmiştir. " );
                say = say + 1;
            }

        }
        
        
        
        
        
        
        
        private static void carTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
