using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        //aslında burada interface yapma sebebim kod
        //tekrarı yapmadan crud metolarını kullanmak
        //bu nedenle ICustomerDal interface yapıldı
    }
}
