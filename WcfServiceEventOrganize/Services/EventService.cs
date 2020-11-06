using EventOrganizeDataModel;
using EventOrganizeDomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceEventOrganize.Contracts;

namespace WcfServiceEventOrganize.Services
{
   public class EventService:IEventContract
    {
        IUnitOfWork _UnitOfWork;
        public EventService()
        {
            _UnitOfWork = new UnitOfWork(new EventOrganizingEntities());

        }

        

        public Event GetEvent(int Id)
        {
            Event eventEntity = null;
            try
            {
                eventEntity = _UnitOfWork.EventRepository.GetById(Id);
                if (eventEntity == null)
                {
                    NotFoundExeption ex = new NotFoundExeption(string.Format("Event with Id of {0} is not in the Database", Id));
                    throw new FaultException<NotFoundExeption>(ex, ex.Message);
                }

                

            }
            catch (FaultException ex)
            {
                throw ex;

            }
            catch (Exception ex)

            {

                throw new FaultException(ex.Message);
            }

            return eventEntity;
        }

        public Event[] GetAllEvents()
        {
            IEnumerable<Event> events = _UnitOfWork.EventRepository.GetAll();
            return events.ToArray();

        }



        public Event UpdateEvent(Event EventToUpdate)
        {

            if (EventToUpdate.Id == 0)
            {
                _UnitOfWork.EventRepository.Add(EventToUpdate);
            }
            else
                _UnitOfWork.EventRepository.Update(EventToUpdate);

            return EventToUpdate;
        }



        public void DeleteEvent(int Id)
        {
            Event eventToDelete = _UnitOfWork.EventRepository.GetById(Id);
            _UnitOfWork.EventRepository.Delete(eventToDelete);

        }
    }

}

