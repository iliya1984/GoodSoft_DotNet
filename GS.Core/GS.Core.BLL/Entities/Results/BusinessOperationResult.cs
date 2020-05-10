using System.Collections.Generic;
using System.Linq;
using GS.Core.BLL.Entities.Enums;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Entities;
using GS.Core.Entities.Enums;
using GS.Core.Entities.ErrorHandling.BusinessErrors;

namespace GS.Core.BLL.Entities.Results
{
    public abstract class BusinessOperationResult : OperationResult
    {
        public BusinessOperationStatus Status
         { 
            get
            {
                if(Exceptions.Any() || BusinessErrors.Any())
                {
                    if(Exceptions.All(e => e.IsHandled))
                    {
                        return BusinessOperationStatus.PartialSuccess;
                    }
                    else
                    {
                        return BusinessOperationStatus.Failure;
                    }
                }
                
                return BusinessOperationStatus.Success;
            }
        }


        public List<BusinessError> BusinessErrors { get; private set; }

        protected BusinessOperationResult()
        {
            BusinessErrors = new List<BusinessError>();
        }

        protected BusinessOperationResult(DataOperationResult result) : base(result)
        {
             BusinessErrors = new List<BusinessError>();
        }
    }
}