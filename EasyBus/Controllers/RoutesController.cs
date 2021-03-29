using AutoMapper;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        #region Properties

        
        private readonly IRouteBDC RouteBDC;

        public RoutesController(IRouteBDC routeBDC)
        {
            RouteBDC = routeBDC;
        }


        #endregion Properties

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

        // GET api/<RoutesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OperationResult<RouteDTO> result = RouteBDC.Get(id);
            return GetResponse(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            OperationResult<IEnumerable<RouteDTO>> result = RouteBDC.GetAll();
            return GetResponse(result);
        }

        // POST api/<RoutesController>
        [HttpPost]
        public IActionResult Post([FromBody] NewRouteModel newRoute)
        {
            
            OperationResult result = RouteBDC.Add(newRoute);
            return GetResponse(result);
        }

        // PUT api/<RoutesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NewRouteModel newRoute)
        {
            RouteDTO routeDTO = new()
            {
                DestinationStop = new StopDTO { Id = newRoute.DestinationId },
                SourceStop = new StopDTO { Id = newRoute.SourceId },
            };
            OperationResult result = RouteBDC.Update(id, routeDTO);
            return GetResponse(result);
        }

        // DELETE api/<RoutesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return GetResponse(RouteBDC.Remove(id));
        }
    }
}