using System.Collections.Generic;
using GS.Core.BLL.Entities.Enums;
using GS.Core.Entities.ErrorHandling.BusinessErrors;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Interfaces.Entities
{
    public interface IBusinessOperationResult : IOperationResult
    {
        BusinessOperationStatus Status { get; }
        List<BusinessError> BusinessErrors { get; }
    }
}