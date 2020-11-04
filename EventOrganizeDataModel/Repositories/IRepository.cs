using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace EventOrganizeDataModel.Repositories
{
    public interface IRepository<TEntity>

    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable <TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        void SaveChanges();

    }
}
