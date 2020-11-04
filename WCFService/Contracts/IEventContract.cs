using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EventOrganizeDomainClasses;
using System.ServiceModel.PeerResolvers;
using EventOrganizeDataModel;

namespace WCFService.Contracts
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IEventContract
    {
        //entry in the asemblyinfo file for the namespace 
        [OperationContract]
        Event GetEvent(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundExeption))]
        Event[] GetAllEvents();

        [OperationContract]
        Event UpdateEvent(Event EventToUpdate);

        [OperationContract]
        void DeleteEvent(int Id); 


    }
}
