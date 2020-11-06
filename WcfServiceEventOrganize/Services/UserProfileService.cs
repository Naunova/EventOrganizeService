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
    public class UserProfileService:IUserProfileContract
    {
   
  
           IUnitOfWork _UnitOfWork;
            public UserProfileService()
            {
                _UnitOfWork = new UnitOfWork(new EventOrganizingEntities());
            }
       
            public UserProfile[] GetAllUserProfiles()
            {
                IEnumerable<UserProfile> users = _UnitOfWork.UserProfileRepository.GetAll();
                return users.ToArray();

            }
       

            public UserProfile GetUserProfile(int Id)
            {
                try
                {
                    UserProfile userEntity = _UnitOfWork.UserProfileRepository.GetById(Id);
                    if (userEntity == null)
                    {
                        NotFoundExeption ex = new NotFoundExeption(string.Format("UserProfile with Id of {0} is not in the Database", Id));
                        throw new FaultException<NotFoundExeption>(ex, ex.Message);
                    }

                    return userEntity;

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


            public UserProfile UpdateUSerProfile(UserProfile UserToUpdate)
            {

                if (UserToUpdate.Id == 0)
                {
                    _UnitOfWork.UserProfileRepository.Add(UserToUpdate);
                }
                else
                    _UnitOfWork.UserProfileRepository.Update(UserToUpdate);

                return UserToUpdate;
            }
            public void DeleteUserProifile(int Id)
            {
                UserProfile userToDelete = _UnitOfWork.UserProfileRepository.GetById(Id);
                _UnitOfWork.UserProfileRepository.Delete(userToDelete);
            }
        }
}
