using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventOrganizeDataModel;
using System.Data.Entity.Core.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using EventOrganizeDomainClasses;

namespace EventOrganizeDataModel.Repositories
{
    public class EventRepository : GenericRepository<Event>
    {
        public EventRepository(EventOrganizingEntities context) : base(context)
        {

        }
        public override Event GetById(int Id)
        {
            return base.GetById(Id);
        }

        public override IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            return base.Find(predicate);
        }

        public override Event Add(Event entity)
        {
            var newevent = context.Events.Single(e=>e.Id==entity.Id);
            newevent.Name = entity.Name;
            newevent.PlaceId = entity.PlaceId;
            newevent.ResourceId = entity.ResourceId;
            newevent.Date = entity.Date;
            newevent.Time = entity.Time;
            newevent.CreatorId = entity.CreatorId;
            newevent.UserProfile = entity.UserProfile;
            return base.Add(newevent);
        }

        public override void Update(Event entity)
        {
            base.Update(entity);
        }

        public override void Delete(Event entity)
        {
            base.Delete(entity);
        }



    }
}
