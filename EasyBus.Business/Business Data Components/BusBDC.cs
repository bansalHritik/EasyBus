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
    /// <summary>
    /// Defines the <see cref="BusBDC" />.
    /// </summary>
    public class BusBDC : BDC, IBusBDC
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusBDC"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/>.</param>
        public BusBDC(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusBDC"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        public BusBDC(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Will add new bus.
        /// </summary>
        /// <param name="busDTO">Bus detail as <see cref="BusDTO"/>.</param>
        /// <returns>Status as <see cref="OperationResult"/>.</returns>
        public OperationResult Add(BusDTO busDTO)
        {
            // TODO: Fluent Validations
            OperationResult result = new OperationResult();
            try
            {
                Bus bus = Mapper.Map<BusDTO, Bus>(busDTO);

                UnitOfWork.Buses.Add(bus);
                UnitOfWork.Complete();

                result.SetSuccessResult();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Will get bus with given id.
        /// </summary>
        /// <param name="busId">The busId<see cref="int"/>.</param>
        /// <returns>The <see cref="OperationResult{BusDTO}"/>.</returns>
        public OperationResult<BusDTO> Get(int busId)
        {
            OperationResult<BusDTO> result = new OperationResult<BusDTO>();

            try
            {
                Bus busInDB = UnitOfWork.Buses.Get(busId);

                BusDTO bus = Mapper.Map<Bus, BusDTO>(busInDB);

                result.SetSuccessResult(bus);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<BusDTO>> GetAll()
        {
            OperationResult<IEnumerable<BusDTO>> result = new();
            try
            {
                IEnumerable<BusDTO> buses = UnitOfWork.Buses.GetAll()
                                                    .Select(m => Mapper.Map<Bus, BusDTO>(m));

                result.SetSuccessResult(buses);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// The Remove.
        /// </summary>
        /// <param name="busId">The busId<see cref="int"/>.</param>
        /// <returns>The <see cref="OperationResult"/>.</returns>
        public OperationResult Remove(int busId)
        {
            OperationResult result = new OperationResult();
            try
            {
                UnitOfWork.Buses.Remove(busId);
                UnitOfWork.Complete();
                result.SetSuccessResult();
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="busId">The busId<see cref="int"/>.</param>
        /// <param name="busDTO">The busDTO<see cref="BusDTO"/>.</param>
        /// <returns>The <see cref="OperationResult"/>.</returns>
        public OperationResult Update(int busId, BusDTO busDTO)
        {
            OperationResult result = new OperationResult();
            try
            {
                Bus busInDB = UnitOfWork.Buses.Get(busId);
                if (busInDB != null)
                {
                    Mapper.Map<BusDTO, Bus>(busDTO, busInDB);

                    UnitOfWork.Complete();

                    result.SetSuccessResult();
                }
                else
                {
                    //TODO move to resource file.
                    result.SetFailureResult("No bus with this id");
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