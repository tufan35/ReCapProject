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
            ////***************VİEW*********
            //  CarTest();
            // BrandTest();
            //  ColorTest();




            ICarDal efCarDal = new EfCarDal();
            ICarService carService = new CarManager(efCarDal);
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());



            ///***************************************************////////////////////////
            //  Car car1 = new Car()
            //    {BrandId = 001, ColorId = 01, ModelYear = 2000, DailyPrice = 25000, Description = "Tofaş Şahin"};
            //Car car2 = new Car()
            //    { BrandId = 002, ColorId = 02, ModelYear = 2001, DailyPrice = 35000, Description = "Volswagen Polo" };
            //Car car3 = new Car()
            //    { BrandId = 003, ColorId = 03, ModelYear = 2002, DailyPrice = 55000, Description = "Renault Megane" };
            //Car car4 = new Car()
            //    { BrandId = 004, ColorId = 04, ModelYear = 2004, DailyPrice = 75000, Description = "Mercedes AMG" };
            //Car car5 = new Car()
            //    { BrandId = 005, ColorId = 05, ModelYear = 2005, DailyPrice = 10000, Description = "Fiat Linea" };



            //*************İNSERT***
            //  DbInsert(carService, car1,car2,car3,car4,car5);
            // AddTest(carManager, brandManager, colorManager);
            UpdateTest(carManager, brandManager, colorManager);



            Console.ReadLine();
        }


        private static void DbInsert(ICarService carService, Car car1, Car car2, Car car3, Car car4, Car car5)
        {
            Console.WriteLine("************ Araçlar veritabanına Kaydedilmektedir.************");

            List<Car> cars = new List<Car> { car1, car2, car3, car4, car5 };

            int say = 1;

            foreach (var car in cars)
            {
                Console.WriteLine(say + "." + car.Description + " Aracı Kaydedilmiştir. ");
                say = say + 1;
            }

        }


        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Brand Id = " + car.BrandId + "  |  "
                    + "Color Id = " + car.ColorId + "  |  "
                    + "Model Year = " + car.ModelYear + "  |  "
                    + "Description = " + car.Description + "  --->  "
                    + "Daily Price = " + car.DailyPrice + " TL");
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand Id = " + brand.BrandId + "  |  " + "Brand Name = " + brand.BrandName);
            }
        }


        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Brand Id = " + color.ColorId + "  |  " + "Brand Name = " + color.ColorName);
            }
        }




        private static void AddTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("-------------Veri tabanına Eklenme--------------");
            carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = 2015, DailyPrice = 500, Description = "Kartal" });
            brandManager.Add(new Brand { BrandName = "TOFAŞ" });
            colorManager.Add(new Color { ColorName = "GRİ" });
        }


        private static void UpdateTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("------------Veritabanı Güncelleme---------");
            carManager.Update(new Car { Id = 1007, BrandId = 2, ColorId = 1003, ModelYear = 2016, DailyPrice = 550, Description = "TOYOTA" });
            brandManager.Update(new Brand { BrandId = 1003, BrandName = "ISUZU" });
            colorManager.Update(new Color { ColorId = 1003, ColorName = "Mavi" });
        }
    }
}


///veri tabanı güncellemesi, kontrol edilecektri tabloları normalizasyon yapılmıştır. veriler güncellenecektir.