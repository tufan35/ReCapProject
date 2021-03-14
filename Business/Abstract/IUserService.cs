using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Abstract
{
    public interface IUserService /*: IServiceRepository<User>*/
    {
        IDataResult<List<User>> GetUsersById(int usersId);
       
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
