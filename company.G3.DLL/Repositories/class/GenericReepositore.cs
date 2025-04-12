using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Data.contexts;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Models.Shered;
using company.G3.DLL.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace company.G3.DLL.Repositories.@class
{
    public class GenericReepositore<TEntity>(CombanyDbContext _dbContext) : IGenericRepositore<TEntity> where TEntity : baseEntity
    {
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Set<TEntity>().Where(e=>e.IsDeleted!=true).ToList();

            }
            else
            {
                return _dbContext.Set<TEntity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();
            }
        }
      public  IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> Selector)
        {
            return _dbContext.Set<TEntity>().Where(e => e.IsDeleted != true).Select(Selector).ToList();
        }
        public TEntity? GetById(int id)
        {

            return _dbContext.Set<TEntity>().Find(id);
        }

        public void ubdate(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).Where(e => e.IsDeleted != true).ToList();
        }
    }
}
