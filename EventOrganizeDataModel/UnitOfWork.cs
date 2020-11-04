using EventOrganizeDataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventOrganizeDomainClasses;

namespace EventOrganizeDataModel
{
    public interface IUnitOfWork
    {
        IRepository<Event> EventRepository { get; }
        IRepository<Attendant> AttendantRepository { get; }
        IRepository<UserProfile> UserProfileRepository { get; }
        IRepository<cls_Place> PlaceRepository { get; }
        IRepository<cls_Resources> ResourcesRepository { get; }
        IRepository<cls_Role> RoleRepository {get;}

        
    }
    public class UnitOfWork : IUnitOfWork
    {
        private EventOrganizingEntities context;
        public UnitOfWork(EventOrganizingEntities context)
        {
            this.context = context;
        }
        private IRepository<Event> eventRepository;
        public IRepository<Event> EventRepository
        {
            get
            {
                if (eventRepository == null)
                {
                    eventRepository = new EventRepository(context);
                }
                return eventRepository;
            }
        }
        private IRepository<Attendant> attendantRepository;
        public IRepository<Attendant> AttendantRepository
        {
            get
            {
                if (attendantRepository == null)
                {
                    attendantRepository = new AttendantRepository(context);
                }
                return attendantRepository;
            }



        }

        private IRepository<UserProfile> userProfileRepository;
        public IRepository<UserProfile> UserProfileRepository
        {
            get
            {
                if (userProfileRepository == null)
                {
                    userProfileRepository = new UserProfileRepository(context);
                }
                return userProfileRepository;
            }
        }


        public IRepository<cls_Place> placeRepository;
        public IRepository<cls_Place> PlaceRepository
        {
            get
            {
                if (placeRepository == null)
                {
                    placeRepository = new PlaceRepository(context);
                }
                return placeRepository;
            }
        }
        private IRepository<cls_Resources> resourcesRepository;
        public IRepository<cls_Resources> ResourcesRepository
        {
            get
            {
                if (resourcesRepository == null)
                {
                    resourcesRepository = new ResourcesRepository(context);
                }
                return resourcesRepository;
            }

        }
        private IRepository<cls_Role> roleRepository;
        public IRepository<cls_Role> RoleRepository
        {
            get
            {
                if (roleRepository == null)
                {
                    roleRepository = new RoleRepository(context);
                }
                return roleRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
