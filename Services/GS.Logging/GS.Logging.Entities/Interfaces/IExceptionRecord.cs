using System;

namespace GS.Logging.Entities.Interfaces
{
    public interface IExceptionRecord : ILogRecord
    {
        Exception Exception { get; set;}
    } 
}