using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Car : IEntity

    //(Veritabanı)
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}