namespace EasyBus.Shared.Functional
{
    public interface IOperationResult<T>
    {
        T Data { get; }
        string ErrorMessage { get; set; }
        string StackTrace { get; }
        OperationResultStatusType Status { get; }

        bool HasErrorOccured();
        bool HasExceptionOccured();
        bool IsValid();
        void SetExceptionResult();
        void SetExceptionResult(string stackTrace);
        void SetFailureResult();
        void SetFailureResult(string errorMessage);
        void SetSuccessResult();
        void SetSuccessResult(T data);
    }
}