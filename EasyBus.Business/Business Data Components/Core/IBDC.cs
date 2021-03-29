using AutoMapper;
using EasyBus.Shared.Repository.Core;

namespace EasyBus.Shared.Functional
{
    public interface IBDC
    {
        IUnitOfWork UnitOfWork { get; init; }
        IMapper Mapper { get; init; }

        OperationResult<T> SucessResult<T>(T data);

        OperationResult SucessResult();

        OperationResult FailureResult(string errorMessage);

        OperationResult ExceptionResult(string stackTrace);
    }
}