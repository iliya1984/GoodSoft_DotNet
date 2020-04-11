using System.Collections.Generic;
using GS.Messaging.Entities.Common;

namespace GS.Messaging.Entities.Interfaces
{
    public interface IMessagingResult
    {
        EMessaging.Action Action { get; }
        EMessaging.ActionResult Result { get; }
        List<MessagingError> Errors { get; set; }
    }
}