using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using EasyBus.Shared.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Business
{
    public class BusRouteBDC : BDC, IBusRouteBDC
    {
        public BusRouteBDC(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public OperationResult<IEnumerable<BusDetailDTO>> GetAll()
        {
            OperationResult<IEnumerable<BusDetailDTO>> result = new();
            try
            {
                var data = UnitOfWork.BusRoutes
                                .GetAll()
                                .Select(Mapper.Map<BusRoute, BusDetailDTO>)
                                .ToList();
                ;

                result.SetSuccessResult(data);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        //Checked
        public OperationResult Add(NewBusRouteModel busRouteDTO)
        {
            OperationResult result = new();
            try
            {
                Route routeInDB = UnitOfWork.Routes.Get(busRouteDTO.RouteId);
                Bus busInDB = UnitOfWork.Buses.Get(busRouteDTO.BusId);
                if (busInDB != null && routeInDB != null)
                {
                    BusRoute newBusRoute = Mapper.Map<NewBusRouteModel, BusRoute>(busRouteDTO);
                    newBusRoute.Bus = busInDB;
                    newBusRoute.Route = routeInDB;
                    UnitOfWork.BusRoutes.Add(newBusRoute);
                    UnitOfWork.Complete();
                    result.SetSuccessResult();
                }
                else
                {
                    result.SetFailureResult("Bus id or route id is invalid.");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        //Checked
        public OperationResult<IEnumerable<BusDetailDTO>> GetAllBuses(BusSearchOption options)
        {
            DateTime? fromTime = options.FromTime, toTime = options.ToTime;
            int? destId = options.DestId, sourceId = options.SourceId;
            short? capacity = options.MinCapacity;

            
            OperationResult<IEnumerable<BusDetailDTO>> result = new();
            try
            {
                var detailDTOs = UnitOfWork.BusRoutes
                    .GetAll(options)
                    .Select(Mapper.Map<BusRoute, BusDetailDTO>)
                    .ToList();
                                                         
                result.SetSuccessResult(detailDTOs);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        //Checked
        public OperationResult<IEnumerable<BusDetailDTO>> GetBusesWithRoute(int routeId)
        {
            OperationResult<IEnumerable<BusDetailDTO>> result = new();

            try
            {
                Route route = UnitOfWork.Routes.Get(routeId);

                if (route != null)
                {
                    IEnumerable<BusDetailDTO> busesWithRoute = UnitOfWork.BusRoutes
                                                    .GetAllBusWithRoute(routeId)
                                                    .Select(Mapper.Map<BusRoute, BusDetailDTO>);

                    result.SetSuccessResult(busesWithRoute);
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        // Checked
        public OperationResult Remove(int busRouteId)
        {
            OperationResult result = new();
            try
            {
                BusRoute busRoute = UnitOfWork.BusRoutes.Get(busRouteId);
                if (busRoute != null)
                {
                    UnitOfWork.BusRoutes.Remove(busRoute);
                    UnitOfWork.Complete();
                }
                else
                {
                    result.SetFailureResult("No bus with this found");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        //checked
        public OperationResult Update(int busRouteId, NewBusRouteModel newBusRoute)
        {
            OperationResult result = new OperationResult();
            try
            {
                BusRoute busRouteInDB = UnitOfWork.BusRoutes.Get(busRouteId);
                if (busRouteInDB != null)
                {
                    Bus busInDb = UnitOfWork.Buses.Get(newBusRoute.BusId);
                    Route routeInDb = UnitOfWork.Routes.Get(newBusRoute.RouteId);

                    if (busInDb != null && routeInDb != null)
                    {
                        Mapper.Map<NewBusRouteModel, BusRoute>(newBusRoute);
                        busRouteInDB.Bus = busInDb;
                        busRouteInDB.Route = routeInDb;
                        UnitOfWork.Complete();
                    }
                    else
                    {
                        result.SetFailureResult("Invalid bus or route id");
                    }
                }
                else
                {
                    result.SetFailureResult("No Bus route with this id found.");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        //Checked
        public OperationResult<BusRouteDTO> Get(int id)
        {
            OperationResult<BusRouteDTO> result = new();
            try
            {
                BusRoute busRouteInDb = UnitOfWork.BusRoutes.Get(id);
                var bus = Mapper.Map<BusRoute, BusRouteDTO>(busRouteInDb);
                result.SetSuccessResult(bus);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public IEnumerable<BusDetailDTO> GetBusWithDestination(int destId)
        {
            IEnumerable<BusDetailDTO> data = UnitOfWork.BusRoutes
                .GetBusWithDestination(destId)
                .Select(Mapper.Map<BusDetailDTO>);
            return data;
        }

        public IEnumerable<BusDetailDTO> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime)
        {
            IEnumerable<BusDetailDTO> data = UnitOfWork.BusRoutes
                .GetBusWithDestination(destId, fromTime, toTime)
                .Select(Mapper.Map<BusDetailDTO>);
            return data;
        }

        public IEnumerable<BusDetailDTO> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime, short capacity)
        {
            IEnumerable<BusDetailDTO> data = UnitOfWork.BusRoutes
                .GetBusWithDestination(destId, fromTime, toTime, capacity)
                .Select(Mapper.Map<BusDetailDTO>);
            return data;
        }

        public IEnumerable<BusDetailDTO> GetBusWithSource(int sourceId)
        {
            IEnumerable<BusDetailDTO> data = UnitOfWork.BusRoutes
               .GetBusWithSource(sourceId)
               .Select(Mapper.Map<BusDetailDTO>);
            return data;
        }

        public IEnumerable<BusDetailDTO> GetBusWithSource(int sourceId, DateTime fromTime, DateTime toTime)
        {
            IEnumerable<BusDetailDTO> data = UnitOfWork.BusRoutes
               .GetBusWithSource(sourceId, fromTime, toTime)
               .Select(Mapper.Map<BusDetailDTO>);
            return data;
        }

        public IEnumerable<BusDetailDTO> GetBusWithSource(int sourceId, DateTime fromTime, DateTime toTime, short capacity)
        {
            IEnumerable<BusDetailDTO> data = UnitOfWork.BusRoutes
               .GetBusWithSource(sourceId, fromTime, toTime, capacity)
               .Select(Mapper.Map<BusDetailDTO>);
            return data;
        }
    }
}