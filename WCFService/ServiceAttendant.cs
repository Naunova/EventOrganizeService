using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using WCFService.Services;
using EventOrganizeDomainClasses;
using EventOrganizeDataModel;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract (Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IAttendantContract
    {
        [OperationContract]
        Attendant GetAttendant(int Id);
        [OperationContract]
        Attendant[] GetAllAttendants();
        [OperationContract]
        Attendant UpdateAttendant(Attendant AttendantToUpdate);
        [OperationContract]
        void DeleteAttendant(int Id);
    }


    public class AttendantService : IAttendantContract
    {
        private IUnitOfWork _UnitOfWork;
        public AttendantService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;

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

    // Define a service contract.
   


    // Implement the ICalculator service contract in a service class.

    public class AttendantWindowsService : ServiceBase
    {


        public ServiceHost serviceHost = null;
        public AttendantWindowsService()
        {
            // Name the Windows Service
            ServiceName = "WCFWindowsServiceSample";
        }
        public static void Main()
        {
            ServiceBase.Run(new AttendantWindowsService());
        }



        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and
            // provide the base address.
            serviceHost = new ServiceHost(typeof(AttendantService));

            // Open the ServiceHostBase to create listeners and start
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

        // Provide the ProjectInstaller class which allows
    // the service to be installed by the Installutil.exe tool
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "WCFWindowsServiceSample";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
    }

    
}