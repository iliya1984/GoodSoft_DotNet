using GS.Core.DAL.Entities.Enums;
using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Interfaces.Entities
{
    public interface IDataOperationResult : IOperationResult
    {
        DataOperationStatus Status { get; }
    }
}