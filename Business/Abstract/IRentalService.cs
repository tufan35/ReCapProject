using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IRentalService/* : IServiceRepository<Rental>*/
    {
        IDataResult<List<Rental>> GetRentalsById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId);
        IResult CheckReturnDate(int carId);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
