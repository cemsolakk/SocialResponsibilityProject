using SCRP.Foundation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SCRP.Foundation.DataAccess
{
    public interface IEntityRepository<T>
        where T : IEntity
        //TEntity IEntity'i implement etmeli
    {
        int Add(T entity); //dönüş tipi int çünkü eğer dönen 0 olursa hiç birşey eklenmediği anlaşılacak
        int Delete(T entity);
        //int Update(T entity);
        T Get(Expression<Func<T, bool>> filter);
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
