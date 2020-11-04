using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace EventOrganizeDataModel.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected EventOrganizingEntities context;
        protected DbSet<TEntity> dbSet;
        public GenericRepository(EventOrganizingEntities context)
        {
            this.context = context;
           
        }
        public virtual TEntity Add(TEntity entity)
        { 
           return context.Set<TEntity>().Add(entity);
        }

        
        public virtual  IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().AsQueryable().Where(predicate).ToList();
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
           context.Entry(entity).State = EntityState.Modified;

        }

        public virtual void Delete (TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);

          
        }
        public virtual TEntity GetById(int Id)
        {
            return context.Set<TEntity>().Find(Id);
        }
        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

       
    }
}
