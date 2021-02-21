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
            // UserTest();
           RentalTest();


            ICarDal efCarDal = new EfCarDal();
            ICarService carService = new CarManager(efCarDal);
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());




            // AddTest(carManager, brandManager, colorManager);
            //UpdateTest(carManager, brandManager, colorManager);



            Console.ReadLine();
        }




        private static void CarTest() 
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetailDtos();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " markalı " + car.ColorName + " renkli aracın günlük fiyatı : " + car.DailyPrice);
                }
            }
        
        }

       private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User
            {
                FirstName = "TUFAN",
                LastName = "ÇEVİK",
                Email = "tufancevikk@gmail.com",
                Password = "123456789"
            };
            userManager.Add(user);

            var result = userManager.GetAll();
            if (result.Success ==true )
            {
                foreach (var users in result.Data)
                {
                    Console.WriteLine(users.FirstName + " " + users.LastName + "\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void RentalTest()
        {
            RentalManager rentalsManager = new RentalManager(new EfRentalDal());
            DateTime rentDate = new DateTime(2017, 10, 6);
            DateTime returnDate = new DateTime(2018, 10, 18);
            Rental rentals = new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = rentDate,
                ReturnDate = returnDate
                
            };
            var result = rentalsManager.Add(rentals);
            Console.WriteLine(result.Message);


        }

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());

        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine("Brand Id = " + brand.BrandId + "  |  " + "Brand Name = " + brand.BrandName);
        //    }
        //}


        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());

        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine("Brand Id = " + color.ColorId + "  |  " + "Brand Name = " + color.ColorName);
        //    }
        //}




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
            carManager.Update(new Car { CarId = 5, BrandId = 4, ColorId = 2, ModelYear = 2000, DailyPrice = 450, Description = "FİAT LİNEA" });

        }
    }
}

