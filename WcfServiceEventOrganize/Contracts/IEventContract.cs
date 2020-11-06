using EventOrganizeDataModel;
using EventOrganizeDomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceEventOrganize.Contracts
{
    [ServiceContract]
    public interface IEventContract
    { 
        [OperationContract]
        Event GetEvent(int Id);

        [OperationContract]        
        Event[] GetAllEvents();

        [OperationContract]
        Event UpdateEvent(Event EventToUpdate);

        [OperationContract]
        void DeleteEvent(int Id);


    }
}
