using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService  /*:IServiceRepository<Car>*/
    {
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car); 
        IResult Update(Car car); 
        IResult Delete(Car car); 

    }
}
