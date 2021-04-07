using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.DTOs;

namespace EasyBus.Business.Business_Data_Components.Interfaces.Business
{
    public interface IUserBDC
    {
        public OperationResult<UserDTO> GetUser(string userId);
    }
}