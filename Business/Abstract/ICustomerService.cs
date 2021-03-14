using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 public  interface ICustomerService /*: IServiceRepository<Customer>*/
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCustomersById(int customerId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
