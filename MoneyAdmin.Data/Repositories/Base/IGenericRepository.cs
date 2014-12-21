using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyAdmin.Data.Repositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        T Find(int id);

        IQueryable<T> AsQueryable();

        IQueryable<T> FindBy(Expression<Func<T, bool>> conditions);

        IGenericRepository<T> Add(T entity);

        IGenericRepository<T> Update(T entity);

        IGenericRepository<T> Delete(T entity);

        void Save();
    }
}
