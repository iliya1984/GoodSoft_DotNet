using System;
using System.Collections.Generic;
using System.Linq;
using GS.Core.Entities.ErrorHandling.Exceptions;
using GS.Core.Entities.Interfaces;

namespace GS.Core.Entities.Entities
{
    public abstract class OperationResult : IOperationResult
    {
        public List<ExceptionWrapper> Exceptions { get; }   
    
        protected  OperationResult()
        {
            Exceptions = new List<ExceptionWrapper>();
        }

        protected OperationResult(Exception exception, bool isHandled = false)
        {
            if(isHandled)
            {
                AddHandledException(exception);
            }
            else
            {
                AddException(exception);
            }
        }

        protected OperationResult(IOperationResult result) : this()
        {
           initialize(result);
        }

        public void AddException(Exception ex)
        {
            Exceptions.Add(new ExceptionWrapper(ex));
        }

        public void AddHandledException(Exception ex)
        {
            Exceptions.Add(new ExceptionWrapper(ex, true));
        }

        public void AddExceptions(IEnumerable<Exception> exs)
        {
            var exceptionsToAdd = exs.Select(ex => new ExceptionWrapper(ex));
            Exceptions.AddRange(exceptionsToAdd);
        }

        public void AddHandledExceptions(IEnumerable<Exception> exs)
        {
            var exceptionsToAdd = exs.Select(ex => new ExceptionWrapper(ex, true));
            Exceptions.AddRange(exceptionsToAdd);
        }

        private void initialize(IOperationResult result)
        {
            if(result.Exceptions != null && result.Exceptions.Any())
            {
                Exceptions.AddRange(result.Exceptions);
            }
        }
    }
}