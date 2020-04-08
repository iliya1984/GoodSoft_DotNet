using System;

namespace GS.Logging.Entities.Interfaces
{
    public interface IErrorRecord : ILogRecord
    {
        string StackTrace { get;set; }
    }
}