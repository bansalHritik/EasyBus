namespace EasyBus.Shared.Functional
{
    public class BDC : IBDC
    {
        public OperationResult<object> Exception(string stackTrace)
        {
            OperationResult<object> result = new();
            result.SetExceptionResult(stackTrace);
            return result;
        }

        public OperationResult<object> Failed(string errorMessage)
        {
            OperationResult<object> result = new();
            result.SetFailureResult(errorMessage);
            return result;
        }

        public OperationResult<T> Success<T>(T data)
        {
            OperationResult<T> result = new();
            result.SetSuccessResult(data);
            return result;
        }

        public OperationResult<object> Success()
        {
            OperationResult<object> result = new();
            result.SetSuccessResult();
            return result;
        }
    }
}
