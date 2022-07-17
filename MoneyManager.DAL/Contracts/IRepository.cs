using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.DAL.Contracts
{
   public interface IRepository<T> where T :  class 
    {
         Task<T> Create(T _object);
         void Update(T _object);
         Task<List<T>> FindAll();
         List<T> Find(Expression<Func<T, bool>> predicate);
         T FindOne(Expression<Func<T, bool>> predicate);
         void Delete(T _object);

    }
}
