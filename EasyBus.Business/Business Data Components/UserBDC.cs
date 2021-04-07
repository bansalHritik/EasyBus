using AutoMapper;
using EasyBus.Business.Business_Data_Components.Interfaces.Business;
using EasyBus.Data.Contexts;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBus.Business.Business_Data_Components
{
    public class UserBDC : BDC, IUserBDC
    {
        
        public UserBDC(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper){}

        public OperationResult<UserDTO> GetUser(string userId)
        {
            OperationResult<UserDTO> result = new OperationResult<UserDTO>();
            try
            {
                var a = UnitOfWork;
                ApplicationUser userInDB = UnitOfWork.Users
                        .Find(user => user.Email == userId)
                        .FirstOrDefault();

                if(userInDB != null)
                {
                    result.SetSuccessResult(Mapper.Map<ApplicationUser, UserDTO>(userInDB));
                }
                else
                {
                    result.SetExceptionResult("No user with this id");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }
    }
}
