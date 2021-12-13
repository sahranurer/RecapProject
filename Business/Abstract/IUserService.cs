using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(Users user);
        IResult Update(Users user);
        IResult Delete(Users user);
        IDataResult<List<Users>> GetAll();
    }
}
