using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T FindById(int id);

        IQueryable<T> AsQueryable();

        IQueryable<T> FindBy(Expression<Func<T, bool>> conditions);

        IGenericRepository<T> Add(T entity);

        IGenericRepository<T> Update(T entity);

        IGenericRepository<T> Delete(T entity);

        void Save();
    }
}
