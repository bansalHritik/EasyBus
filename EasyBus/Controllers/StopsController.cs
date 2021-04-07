using EasyBus.Business.Business_Data_Components.Interfaces.Business;
using EasyBus.Data.Contexts;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.Constants;
using EasyBus.Shared.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : ControllerBase
    {
        private readonly IStopBDC StopBDC;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserBDC userBDC;

        public StopsController(IStopBDC stopsBDC, UserManager<ApplicationUser> userManager, IUserBDC user)
        {
            StopBDC = stopsBDC;
            this.userManager = userManager;
            userBDC = user;
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
            var email = this.GetCurrentUser();
            var a = userBDC.GetUser(email);
            return GetResponse(StopBDC.Get(id));
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var email = this.GetCurrentUser();
            var a = userBDC.GetUser(email);
            return GetResponse(StopBDC.GetAll());
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.ADMIN)]

        public IActionResult Update(int id, NewStopModel newStop)
        {
            StopDTO stopDTO = new()
            {
                Name = newStop.Name,
            };
            return GetResponse(StopBDC.Update(id, stopDTO));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.ADMIN)]

        public IActionResult New(NewStopModel newStop)
        {
            StopDTO stopDTO = new()
            {
                Name = newStop.Name,
            };
            return GetResponse(StopBDC.Add(stopDTO));
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.ADMIN)]

        public IActionResult Delete(int stopId)
        {
            return GetResponse(StopBDC.Remove(stopId));
        }
    }
}