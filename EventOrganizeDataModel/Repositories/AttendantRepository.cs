using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventOrganizeDomainClasses;

namespace EventOrganizeDataModel.Repositories
{
    public class AttendantRepository: GenericRepository<Attendant>
    {
        public AttendantRepository(EventOrganizingEntities context) : base(context)
        {


        }
        public override IEnumerable<Attendant> Find(Expression<Func<Attendant, bool>> predicate)
        {
            
            return base.Find(predicate);
        }
        public override Attendant GetById(int Id)
        {
            return base.GetById(Id);
        }

        public override Attendant Add(Attendant entity)
        {
            return base.Add(entity);
        }

        public override void Delete(Attendant entity)
        {
            base.Delete(entity);
        }
        

        public override IEnumerable<Attendant> GetAll()
        {
            return base.GetAll();
        }

        public override void Update(Attendant entity)
        {
            base.Update(entity);
        }
         
        

    }
}
