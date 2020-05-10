using System;
using System.Linq;
using GS.Core.DAL.Entities.Enums;
using GS.Core.DAL.Interfaces.Entities;
using GS.Core.Entities.Entities;

namespace GS.Core.DAL.Entities.Results
{
    public class DataOperationResult : OperationResult, IDataOperationResult
    {
        public DataOperationStatus Status 
        { 
            get
            {
                if(Exceptions.Any())
                {
                    if(Exceptions.All(e => e.IsHandled))
                    {
                        return DataOperationStatus.PartialSuccess;
                    }
                    else
                    {
                        return DataOperationStatus.Error;
                    }
                }
                else
                {
                    return DataOperationStatus.Success;
                }
            }
        }

        public DataOperationResult(){}
        public DataOperationResult(Exception extension, bool isHandled = false): base(extension, isHandled){}
    }
}