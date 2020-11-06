using EventOrganizeDataModel;
using EventOrganizeDomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceEventOrganize.Contracts;
using System.Runtime.Serialization;
using System.ComponentModel.Composition;

namespace WcfServiceEventOrganize.Services
{
   public class AttendantService:IAttendantContract
    {
        
        private IUnitOfWork _UnitOfWork;
        public AttendantService()
        {
            _UnitOfWork = new UnitOfWork(new EventOrganizingEntities());

        }
        


        public Attendant GetAttendant(int Id)
        {
            try
            {
                Attendant attendantEntity = _UnitOfWork.AttendantRepository.GetById(Id);
                if (attendantEntity == null)
                {
                    NotFoundExeption ex = new NotFoundExeption(string.Format("Attendant with Id of {0} is not in the Database", Id));
                    throw new FaultException<NotFoundExeption>(ex, ex.Message);
                }

                return attendantEntity;

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
        public Attendant[] GetAllAttendants()
        {
            IEnumerable<Attendant> attendants = _UnitOfWork.AttendantRepository.GetAll();
            return attendants.ToArray();
        }
        public Attendant UpdateAttendant(Attendant AttendantToUpdate)
        {
            if (AttendantToUpdate.Id == 0)
            {
                _UnitOfWork.AttendantRepository.Add(AttendantToUpdate);
            }
            else
                _UnitOfWork.AttendantRepository.Update(AttendantToUpdate);

            return AttendantToUpdate;
        }

        public void DeleteAttendant(int Id)
        {
            Attendant attendantToDelete = _UnitOfWork.AttendantRepository.GetById(Id);
            _UnitOfWork.AttendantRepository.Delete(attendantToDelete);
        }

    }
}
