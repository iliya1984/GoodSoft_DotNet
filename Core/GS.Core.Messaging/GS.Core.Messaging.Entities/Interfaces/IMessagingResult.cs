using System.Collections.Generic;
using GS.Core.Messaging.Entities.Common;

namespace GS.Core.Messaging.Entities.Interfaces
{
    public interface IMessagingResult
    {
        EMessaging.Action Action { get; }
        EMessaging.ActionResult Result { get; }
        List<MessagingError> Errors { get; set; }
    }
}