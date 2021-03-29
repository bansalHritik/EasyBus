using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.DTOs;
using System.Collections.Generic;

namespace EasyBus.Shared.Infrastructure.Business
{
    public interface IBusBDC
    {
        OperationResult<BusDTO> Get(int busId);

        OperationResult Add(BusDTO busDTO);

        OperationResult<IEnumerable<BusDTO>> GetAll();

        OperationResult Update(int busId, BusDTO busDTO);

        OperationResult Remove(int busId);
    }
}