using EasyBus.Shared.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

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
        public static string GetCurrentUser(this ControllerBase controller)
        {
            var mail = controller.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value;
           
            return mail;
        
        }
    }
}