using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Models.Shered;


namespace company.G3.DLL.Repositories.interfaces
{
    public interface IGenericRepositore<TEntity> where TEntity : baseEntity
    {
        void add(TEntity Entity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> Selector);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        void remove(TEntity Entity);     
        void ubdate(TEntity Entity);
    }
}
