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
   public interface IUserProfileContract
    {
        [OperationContract]
        UserProfile GetUserProfile(int Id);
        [OperationContract]
        UserProfile[] GetAllUserProfiles();
        [OperationContract]
        UserProfile UpdateUSerProfile(UserProfile UserToUpdate);
        [OperationContract]
        void DeleteUserProifile(int Id);
    }
}
