using EasyBus.Shared.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyBus.Controllers
{
    public static class ApiControllerExtension
    {
        public static IActionResult GetResponse<T>(this ControllerBase controller, OperationResult<T> operationResult)
        {
            IActionResult result = null;
            switch (operationResult.Status)
            {
                case OperationResultStatusType.Success:
                    result = controller.Ok(operationResult.Data);
                    break;

                case OperationResultStatusType.Failed:
                    result = controller.BadRequest(operationResult.ErrorMessage);
                    break;

                case OperationResultStatusType.Exception:
                    result = controller.StatusCode(StatusCodes.Status500InternalServerError);
                    break;
            }
            return result;
        }

        public static IActionResult GetResponse(this ControllerBase controller, OperationResult operationResult)
        {
            IActionResult result = null;
            switch (operationResult.Status)
            {
                case OperationResultStatusType.Success:
                    result = controller.Ok();
                    break;

                case OperationResultStatusType.Failed:
                    result = controller.BadRequest(operationResult.ErrorMessage);
                    break;

                case OperationResultStatusType.Exception:
                    result = controller.StatusCode(StatusCodes.Status500InternalServerError);
                    break;
            }
            return result;
        }
    }
}