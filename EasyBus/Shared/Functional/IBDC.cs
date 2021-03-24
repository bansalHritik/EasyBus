using EasyBus.Shared.Repository.Core;

namespace EasyBus.Shared.Functional
{
    public interface IBDC
    {
        OperationResult<T> Success<T>(T data);
        OperationResult<object> Success();
        OperationResult<object> Failed(string errorMessage);
        OperationResult<object> Exception(string stackTrace);

    }
}
