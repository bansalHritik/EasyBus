﻿using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Models;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        #region Properties

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBusBDC BusBDC;

        #endregion Properties

        

        #region Constructors

        public BusController(IUnitOfWork unitOfWork, IMapper mapper, IBusBDC busBDC)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            BusBDC = busBDC;
        }

        #endregion Constructors

        #region Public API Methods

        [HttpPost]
        public IActionResult New(NewBusModel newBus)
        {
            BusDTO busDTO = new()
            {
                Capacity = newBus.Capacity,
                Description = newBus.Description,
                Operator = newBus.Operator,
                SeatsBooked = newBus.SeatsBooked,
                VehicleNumber = newBus.VechileNumber,
            };
            OperationResult result = BusBDC.Add(busDTO);
            IActionResult response = null;
            if (result.Status == OperationResultStatusType.Success)
            {
                response = CreatedAtAction(nameof(Get), busDTO);
            }
            return response;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            OperationResult<BusDTO> result = BusBDC.Get(id);
            IActionResult response = this.GetResponse(result);
            return response;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            OperationResult<IEnumerable<BusDTO>> result = BusBDC.GetAll();
            IActionResult response = this.GetResponse(result);
            return response;
        }

        // TODO: ONLY ADMIN
        [HttpPut]
        public IActionResult UpdateBus(int id, NewBusModel newBus)
        {
            BusDTO bus = new()
            {
                Capacity = newBus.Capacity,
                Description = newBus.Description,
                Operator = newBus.Operator,
                SeatsBooked = newBus.SeatsBooked,
                VehicleNumber = newBus.VechileNumber
            };
            OperationResult result = BusBDC.Update(id, bus);
            return this.GetResponse(result);
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            OperationResult result = BusBDC.Remove(id);
            return this.GetResponse(result);
        }

        #endregion Public API Methods
    }
}