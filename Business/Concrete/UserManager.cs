﻿using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(Users user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(Users user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);

        }

        public IDataResult<List<Users>> GetAll()
        {
           
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IResult Update(Users user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
