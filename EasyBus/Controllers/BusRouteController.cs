﻿using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IBusRouteBDC BusRouteBDC;

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
            return this.GetResponse(BusRouteBDC.Get(id));
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAll()
        {
            return this.GetResponse(BusRouteBDC.GetAll());
        }
        [HttpPost("WIthOption")]
        public IActionResult GetAll([FromBody]BusSearchOption option)
        {
            return this.GetResponse(BusRouteBDC.GetAllBuses(option));
        }

        #endregion Get Methods

        #region Create Methods
        [HttpPost]
        public IActionResult Add([FromBody]NewBusRouteModel newBusRoute)
        {
            return this.GetResponse(BusRouteBDC.Add(newBusRoute));
        }
        #endregion

        [HttpPut]
        public IActionResult Update(int busRouteId,[FromBody] NewBusRouteModel newBusRoute)
        {
            return this.GetResponse(BusRouteBDC.Update(busRouteId, newBusRoute));
        }

        [HttpDelete]
        public IActionResult Delete(int busRouteId)
        {
            return this.GetResponse(BusRouteBDC.Remove(busRouteId));
        }

        #endregion Api Methods
    }
}