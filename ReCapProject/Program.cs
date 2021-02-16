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
  
            //BrandTest();
            //ColorTest();
            //CarTest();



            ICarDal efCarDal = new EfCarDal();
            ICarService carService = new CarManager(efCarDal);
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());




           // AddTest(carManager, brandManager, colorManager);
            UpdateTest(carManager, brandManager, colorManager);


        
            Console.ReadLine();
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
          
            brandManager.Add(new Brand { BrandName = "FİAT" });
            colorManager.Add(new Color { ColorName = "GRİ" });
            carManager.Add(new Car { BrandId = 4, ColorId = 4, ModelYear = 2015, DailyPrice = 500, Description = "FİAT DOBLO" });



        }


        private static void UpdateTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("------------Veritabanı Güncelleme---------");
            brandManager.Update(new Brand { BrandId = 4, BrandName = "LİNEA" });
            colorManager.Update(new Color { ColorId = 2, ColorName = "SİYAH" });
            carManager.Update(new Car { Id = 5, BrandId = 4, ColorId = 2, ModelYear = 2000, DailyPrice = 450, Description = "FİAT LİNEA" });

        }
    }
}

