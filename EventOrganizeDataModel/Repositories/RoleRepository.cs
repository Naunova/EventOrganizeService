using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventOrganizeDomainClasses;

namespace EventOrganizeDataModel.Repositories
{
    public class RoleRepository:GenericRepository<cls_Role>
    {
        public RoleRepository(EventOrganizingEntities context) : base(context)
        {

        }

        public override cls_Role Add(cls_Role entity)
        {
            return base.Add(entity);
        }

        public override cls_Role GetById(int Id)
        {
            return base.GetById(Id);
        }

        public override IEnumerable<cls_Role> GetAll()
        {
            return base.GetAll();
        }

        public override void Update(cls_Role entity)
        {
            base.Update(entity);
        }

        public override void Delete(cls_Role entity)
        {
            base.Delete(entity);
        }
    }
}
