using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : ControllerBase
    {

        private readonly IStopBDC StopBDC;

        public StopsController(IStopBDC stopsBDC)
        {
            StopBDC = stopsBDC;
        }
        #region Private Response handling methods.

        private IActionResult GetResponse<T>(OperationResult<T> operationResult)
        {
            IActionResult result = null;
            switch (operationResult.Status)
            {
                case OperationResultStatusType.Success:
                    result = Ok(operationResult.Data);
                    break;

                case OperationResultStatusType.Failed:
                    result = BadRequest(operationResult.ErrorMessage);
                    break;

                case OperationResultStatusType.Exception:
                    result = StatusCode(StatusCodes.Status500InternalServerError);
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
                    result = Ok();
                    break;

                case OperationResultStatusType.Failed:
                    result = BadRequest(operationResult.ErrorMessage);
                    break;

                case OperationResultStatusType.Exception:
                    result = StatusCode(StatusCodes.Status500InternalServerError);
                    break;
            }
            return result;
        }

        #endregion Private Response handling methods.
        
        [HttpGet]
        public IActionResult Get(int id)
        {
            return GetResponse(StopBDC.Get(id));
        }

        
        [HttpGet("GetAll")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAll()
       {
            
            return GetResponse(StopBDC.GetAll());
        }

        [HttpPut]
        public IActionResult Update(int id, NewStopModel newStop)
        {
            StopDTO stopDTO = new()
            {
                Name = newStop.Name,
            };
            return GetResponse(StopBDC.Update(id, stopDTO));
        }

        [HttpPost]
        public IActionResult New(NewStopModel newStop)
        {
            StopDTO stopDTO = new()
            {
                Name = newStop.Name,
            };
            return GetResponse(StopBDC.Add(stopDTO));
        }
        [HttpDelete]
        public IActionResult Delete(int stopId)
        {
            return GetResponse(StopBDC.Remove(stopId));
        }
    }
}
