using EventOrganizeDomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFService.Contracts
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
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
}
