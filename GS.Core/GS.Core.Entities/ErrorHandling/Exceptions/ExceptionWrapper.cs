using System;

namespace GS.Core.Entities.ErrorHandling.Exceptions
{
    public class ExceptionWrapper
    {
        public Exception Exception { get; private set;}
        public bool IsHandled { get; private set;}

        public ExceptionWrapper(Exception exception, bool isHandled = false)
        {
            Exception = exception;
            IsHandled = isHandled;
        }
    }
}