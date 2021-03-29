using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IBusRouteBDC BusRouteBDC;

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

        #region Constructor

        public BusRouteController(IBusRouteBDC busRouteBDC)
        {
            BusRouteBDC = busRouteBDC;
        }

        #endregion Constructor

        #region Api Methods

        #region Read Methods

        [HttpGet]
        public IActionResult Get(int id)
        {
            return GetResponse(BusRouteBDC.Get(id));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return GetResponse(BusRouteBDC.GetAll());
        }
        [HttpGet("WIthOption")]
        public IActionResult GetAll([FromQuery]BusSearchOption option)
        {
            return GetResponse(BusRouteBDC.GetAllBuses(option));
        }

        #endregion Get Methods

        #region Create Methods
        [HttpPost]
        public IActionResult Add([FromBody]NewBusRouteModel newBusRoute)
        {
            return GetResponse(BusRouteBDC.Add(newBusRoute));
        }
        #endregion

        [HttpPut]
        public IActionResult Update(int busRouteId,[FromBody] NewBusRouteModel newBusRoute)
        {
            return GetResponse(BusRouteBDC.Update(busRouteId, newBusRoute));
        }

        [HttpDelete]
        public IActionResult Delete(int busRouteId)
        {
            return GetResponse(BusRouteBDC.Remove(busRouteId));
        }

        #endregion Api Methods
    }
}