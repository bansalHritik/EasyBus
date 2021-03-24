using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Shared.Functional
{
    public class OperationResult<T> : IOperationResult<T>
    {
        public T Data { get; private set; }

        public OperationResultStatusType Status { get; private set; }

        public string StackTrace { get; private set; }

        public string ErrorMessage { get; set; }

        public bool IsValid()
        {
            bool result = true;
            if (HasErrorOccured() || HasExceptionOccured())
            {
                result = false;
            }
            return result;
        }

        public bool HasErrorOccured()
        {
            return Status == OperationResultStatusType.Failed || ErrorMessage != null;
        }

        public bool HasExceptionOccured()
        {
            return Status == OperationResultStatusType.Exception || StackTrace != null;
        }

        public void SetSuccessResult(T data)
        {
            Data = data;
            SetSuccessResult();
        }

        public void SetSuccessResult()
        {
            Status = OperationResultStatusType.Success;
        }

        public void SetFailureResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            SetFailureResult();
        }
        public void SetFailureResult()
        {
            Status = OperationResultStatusType.Failed;
        }

        public void SetExceptionResult(string stackTrace)
        {
            StackTrace = stackTrace;
            SetExceptionResult();
        }
        public void SetExceptionResult()
        {
            Status = OperationResultStatusType.Exception;
        }
    }
}
