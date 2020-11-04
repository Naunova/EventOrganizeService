using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventOrganizeDomainClasses;

namespace EventOrganizeDataModel.Repositories
{
   public class PlaceRepository:GenericRepository<cls_Place>
    {
        public PlaceRepository(EventOrganizingEntities context) : base(context)
        {
            
        }

        public override cls_Place Add(cls_Place entity)
        {
            return base.Add(entity);
        }

        public override cls_Place GetById(int Id)
        {
            return base.GetById(Id);
        }

        public override IEnumerable<cls_Place> GetAll()
        {
            return base.GetAll();
        }

        public override IEnumerable<cls_Place> Find(Expression<Func<cls_Place, bool>> predicate)
        {
            return base.Find(predicate);
        }

        public override void Update(cls_Place entity)
        {
            base.Update(entity);
        }

        public override void Delete(cls_Place entity)
        {
            base.Delete(entity);
        }

    }
}
