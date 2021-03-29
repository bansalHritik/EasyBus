using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.DTOs;
using System.Collections.Generic;

namespace EasyBus.Shared.Infrastructure.Business
{
    public interface IStopBDC
    {
        OperationResult<StopDTO> Get(int stopId);

        OperationResult Add(StopDTO stopDTO);

        OperationResult<IEnumerable<StopDTO>> GetAll();

        OperationResult Update(int stopId, StopDTO stopDTO);

        OperationResult Remove(int stopId);
    }
}
