﻿using Business.Abstract;
using Business.Constants;
using Business.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
 public   class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspects(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }


        public IDataResult<List<User>> GetUsersById(int usersId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserId == usersId));
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
