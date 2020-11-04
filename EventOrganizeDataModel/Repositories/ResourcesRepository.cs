using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventOrganizeDomainClasses;

namespace EventOrganizeDataModel.Repositories
{
    public class ResourcesRepository:GenericRepository<cls_Resources>
    {
        public ResourcesRepository(EventOrganizingEntities context) : base(context)
        {
            
        }

        public override cls_Resources Add(cls_Resources entity)
        {
            return base.Add(entity);
        }

        public override IEnumerable<cls_Resources> Find(Expression<Func<cls_Resources, bool>> predicate)
        {
            return base.Find(predicate);
        }

        public override cls_Resources GetById(int Id)
        {
            return base.GetById(Id);
        }

        public override IEnumerable<cls_Resources> GetAll()
        {
            return base.GetAll();
        }

        public override void Update(cls_Resources entity)
        {
            base.Update(entity);
        }

        public override void Delete(cls_Resources entity)
        {
            base.Delete(entity);
        }

     
    }
}
