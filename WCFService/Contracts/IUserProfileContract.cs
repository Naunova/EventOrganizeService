﻿using System;
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
    interface IUserProfileContract
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