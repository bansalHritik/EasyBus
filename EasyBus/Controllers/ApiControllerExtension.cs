using EasyBus.Shared.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Controllers
{
    public static class ApiControllerExtension
    {
        public static IActionResult GetResponse<T>(this RoutesController controller, OperationResult<T> operationResult)
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
    }
}
