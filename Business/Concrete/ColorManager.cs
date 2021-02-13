using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Entities.Concrete;

namespace Business.Concrete
{
  public  class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Entities.Concrete.Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Sisteme " + color.ColorId + " numaralı " + color.ColorName + " renk araç bilgisi eklendi.");
        }

        public void Delete(Entities.Concrete.Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Sistemden " + color.ColorId + " numaralı " + color.ColorName + " renk araç bilgisi silindi.");
        }

        public List<Entities.Concrete.Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Entities.Concrete.Color> GetCarsByColorId(int colorId)
        {
            return _colorDal.GetAll(c => c.ColorId == colorId); 
        }

        public void Update(Entities.Concrete.Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Sistemde yer alan " + color.ColorId + " numaralı " + color.ColorName + " renk araç bilgisi güncellendi.");
        }
    }
}
