using EasyBus.Shared.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Controllers
{
    public class ResponseHandler
    {
        private readonly ControllerBase _controller;

        public ResponseHandler(ControllerBase controller)
        {
            _controller = controller;
        }
        #region Private Response handling methods.

        private IActionResult GetResponse<T>(OperationResult<T> operationResult)
        {
            IActionResult result = null;
            switch (operationResult.Status)
            {
                case OperationResultStatusType.Success:
                    result = _controller.Ok(operationResult.Data);
                    break;

                case OperationResultStatusType.Failed:
                    result = _controller.BadRequest(operationResult.ErrorMessage);
                    break;

                case OperationResultStatusType.Exception:
                    result = _controller.StatusCode(StatusCodes.Status500InternalServerError);
                    break;
            }
            return result;
        }

        private IActionResult GetResponse(OperationResult operationResult)
        {
            IActionResult result = null;
            switch (operationResult.Status)
            {
                case OperationResultStatusType.Success:
                    result = _controller.Ok();
                    break;

                case OperationResultStatusType.Failed:
                    result = _controller.BadRequest(operationResult.ErrorMessage);
                    break;

                case OperationResultStatusType.Exception:
                    result = _controller.StatusCode(StatusCodes.Status500InternalServerError);
                    break;
            }
            return result;
        }

        #endregion Private Response handling methods.
    }
}
