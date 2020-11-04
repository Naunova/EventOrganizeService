using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventOrganizeDomainClasses;

namespace EventOrganizeDataModel.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile>
    {
        public UserProfileRepository(EventOrganizingEntities context) : base(context)
        {


        }

        public override UserProfile Add(UserProfile entity)
        {
            return base.Add(entity);
        }

        public override UserProfile GetById(int Id)
        {
            return base.GetById(Id);
        }

        public override IEnumerable<UserProfile> GetAll()
        {
            return base.GetAll();
        }

        public override void Update(UserProfile entity)
        {
            base.Update(entity);
        }

        public override void Delete(UserProfile entity)
        {
            base.Delete(entity);
        }

    }
}
