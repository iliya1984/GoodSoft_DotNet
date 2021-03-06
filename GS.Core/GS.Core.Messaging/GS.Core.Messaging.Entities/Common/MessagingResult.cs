using System.Collections.Generic;
using System.Linq;
using GS.Core.Messaging.Entities.Interfaces;

namespace GS.Core.Messaging.Entities.Common
{
    public class MessagingResult: IMessagingResult
    {
        public EMessaging.Action Action { get; private set;}
        public EMessaging.ActionResult Result 
        { 
            get 
            {
                return Errors != null && Errors.Any() ? EMessaging.ActionResult.Error : EMessaging.ActionResult.Ok;
            }
        }
        public List<MessagingError> Errors { get; set;}
        public Topic Topic { get; set; }

        public MessagingResult(EMessaging.Action action)
        {
            Action = action;
            Errors = new List<MessagingError>();
        }

    }
}