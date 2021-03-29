using AutoMapper;
using EasyBus.Shared.Repository.Core;

namespace EasyBus.Shared.Functional
{
    public class BDC : IBDC
    {
        #region Properties
        public IUnitOfWork UnitOfWork { get; init; }
        
        public IMapper Mapper { get; init; }

        #endregion

        #region Constructors
        public BDC(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public BDC(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        #endregion

        // TODO: Implement public methods as private
        #region Public methods
        public OperationResult<T> SucessResult<T>(T data)
        {
            OperationResult<T> result = new();
            result.SetSuccessResult(data);
            return result;
        }

        public OperationResult SucessResult()
        {
            OperationResult result = new();
            result.SetSuccessResult();
            return result;
        }

        public OperationResult FailureResult(string errorMessage)
        {
            OperationResult result = new();
            result.SetFailureResult(errorMessage);
            return result;
        }

        public OperationResult ExceptionResult(string stackTrace)
        {
            OperationResult result = new();
            result.SetExceptionResult(stackTrace);
            return result;
        }
        #endregion
    }
}