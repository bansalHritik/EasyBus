using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Business
{
    public class RouteBDC : BDC, IRouteBDC
    {
        public RouteBDC(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public OperationResult Add(NewRouteModel route)
        {
            OperationResult result = new();
            try
            {
                Stop sourceStop = UnitOfWork.Stops.Get(route.SourceId);
                Stop destStop = UnitOfWork.Stops.Get(route.DestinationId);
                Route newRoute = null;
                if (sourceStop != null && destStop != null)
                {
                    newRoute = new()
                    {
                        DestStop = destStop,
                        SourceStop = sourceStop,
                    };
                    UnitOfWork.Routes.Add(newRoute);
                    UnitOfWork.Complete();
                    result.SetSuccessResult();
                }
                else
                {
                    result.SetFailureResult("Invalid one or more stop ids.");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<RouteDTO> Get(int routeId)
        {
            OperationResult<RouteDTO> result = new OperationResult<RouteDTO>();
            try
            {
                Route routeInDB = UnitOfWork.Routes.Get(routeId);
                RouteDTO route = Mapper.Map<Route, RouteDTO>(routeInDB);
                result.SetSuccessResult(route);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<RouteDTO>> GetAll()
        {
            OperationResult<IEnumerable<RouteDTO>> result = new();
            try
            {
                var data = UnitOfWork.Routes.GetAll()
                                .Select(m => Mapper.Map<Route, RouteDTO>(m)).ToList() ;
                result.SetSuccessResult(data);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<RouteDTO>> GetAllFromDestination(int destinationId)
        {
            OperationResult<IEnumerable<RouteDTO>> result = new();
            try
            {
                var routes = UnitOfWork.Routes.Find(m => m.DestStop.Id == destinationId);

                //TODO
                result.SetSuccessResult();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<RouteDTO>> GetAllFromDestination(string destinationName)
        {
            OperationResult<IEnumerable<RouteDTO>> result = new();
            try
            {
                var routes = UnitOfWork.Routes.Find(m => m.DestStop.Name == destinationName);

                //TODO
                result.SetSuccessResult();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<RouteDTO>> GetAllFromSource(int sourceId)
        {
            OperationResult<IEnumerable<RouteDTO>> result = new();
            try
            {
                var routes = UnitOfWork.Routes.Find(m => m.SourceStop.Id == sourceId);

                //TODO
                result.SetSuccessResult();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<RouteDTO>> GetAllFromSource(string sourceName)
        {
            OperationResult<IEnumerable<RouteDTO>> result = new();
            try
            {
                var routes = UnitOfWork.Routes.Find(m => m.SourceStop.Name == sourceName);

                //TODO
                result.SetSuccessResult();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult Remove(int routeId)
        {
            OperationResult result = new OperationResult();
            try
            {
                Route routeInDB = UnitOfWork.Routes.Get(routeId);
                if (routeInDB != null)
                {
                    UnitOfWork.Routes.Remove(routeInDB);
                    UnitOfWork.Complete();
                    result.SetSuccessResult();
                }
                else
                {
                    //TODO:
                    result.SetFailureResult("No With this id.");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult Update(int routeId, RouteDTO routeDTO)
        {
            OperationResult<IEnumerable<RouteDTO>> result = new();
            try
            {
                Route routeInDb = UnitOfWork.Routes.Get(routeId);
                if (routeInDb != null)
                {
                    //TODO: Map
                    UnitOfWork.Complete();
                    result.SetSuccessResult();
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