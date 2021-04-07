using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.Constants;
using EasyBus.Shared.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        // GET api/<RoutesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OperationResult<RouteDTO> result = RouteBDC.Get(id);
            return this.GetResponse(result);
        }

        [HttpGet("GetAll")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.ADMIN)]
        public IActionResult GetAll()
        {
            OperationResult<IEnumerable<RouteDTO>> result = RouteBDC.GetAll();
            return this.GetResponse(result);
        }

        // POST api/<RoutesController>

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.ADMIN)]
        public IActionResult New([FromBody] NewRouteModel newRoute)
        {
            OperationResult result = RouteBDC.Add(newRoute);
            return this.GetResponse(result);
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
            return this.GetResponse(result);
        }

        // DELETE api/<RoutesController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.ADMIN)]
        public IActionResult Delete(int id)
        {
            return this.GetResponse(RouteBDC.Remove(id));
        }
    }
}