using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Business
{
    public class StopBDC : BDC, IStopBDC
    {
        public StopBDC(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public OperationResult Add(StopDTO stopDTO)
        {
            OperationResult result = new();
            try
            {
                Stop stop = new() { Name = stopDTO.Name };
                UnitOfWork.Stops.Add(stop);
                UnitOfWork.Complete();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<StopDTO> Get(int stopId)
        {
            OperationResult<StopDTO> result = new();
            try
            {
                Stop stopInDb = UnitOfWork.Stops.Get(stopId);
                StopDTO stopDTO = null;
                if (stopInDb != null)
                {
                    stopDTO = Mapper.Map<Stop, StopDTO>(stopInDb);
                    result.SetSuccessResult(stopDTO);
                }
                else
                {
                    result.SetFailureResult("No Stop with this id.");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<StopDTO>> GetAll()
        {
            OperationResult<IEnumerable<StopDTO>> result = new();
            try
            {
                IEnumerable<StopDTO> stops = UnitOfWork.Stops.GetAll()
                                                            .Select(m => Mapper.Map<Stop, StopDTO>(m)).ToList();
                result.SetSuccessResult(stops);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult Remove(int stopId)
        {
            OperationResult result = new();
            try
            {
                UnitOfWork.Stops.Remove(stopId);
                UnitOfWork.Complete();
                result.SetSuccessResult();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult Update(int stopId, StopDTO stopDTO)
        {
            OperationResult result = new();
            try
            {
                Stop stopInDb = UnitOfWork.Stops.Get(stopId);
                if (stopInDb != null)
                {
                    Mapper.Map<StopDTO, Stop>(stopDTO, stopInDb);
                    UnitOfWork.Complete();
                    result.SetSuccessResult();
                }
                else
                {
                    result.SetFailureResult("No stop with this id");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }
    }
}