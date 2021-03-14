using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
   public interface IBrandService /* : IServiceRepository<Brand>*/
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetBrandsByBrandName(string brandName);
        IDataResult<List<Brand>> GetBrandsByBrandId(int brandId);

        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);

    }
}
