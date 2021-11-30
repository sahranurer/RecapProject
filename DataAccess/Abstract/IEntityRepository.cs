using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        // GetById, GetAll, Add, Update, Delete 
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//bu yapı ile ayrı ayrı metotlar yazmaya gerek yok
        T Get(Expression<Func<T,bool>> filter);//tek data getirmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
