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
        public EventService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;

        }

        public EventService()
        {

        }

        public Event GetEvent(int Id)
        {
            try
            {
                Event eventEntity = _UnitOfWork.EventRepository.GetById(Id);
                if (eventEntity == null)
                {
                    NotFoundExeption ex = new NotFoundExeption(string.Format("Event with Id of {0} is not in the Database", Id));
                    throw new FaultException<NotFoundExeption>(ex, ex.Message);
                }

                return eventEntity;

            }
            catch (FaultException ex)
            {
                throw ex;

            }
            catch (Exception ex)

            {

                throw new FaultException(ex.Message);
            }


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

