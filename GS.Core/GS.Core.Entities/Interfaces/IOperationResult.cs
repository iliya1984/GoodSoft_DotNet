using System;
using System.Collections.Generic;
using GS.Core.Entities.ErrorHandling.Exceptions;

namespace GS.Core.Entities.Interfaces
{
    public interface IOperationResult
    {
        List<ExceptionWrapper> Exceptions { get; } 
        void AddException(Exception ex);
        void AddHandledException(Exception ex);
        void AddExceptions(IEnumerable<Exception> exs);
        void AddHandledExceptions(IEnumerable<Exception> exs);  
    }
}