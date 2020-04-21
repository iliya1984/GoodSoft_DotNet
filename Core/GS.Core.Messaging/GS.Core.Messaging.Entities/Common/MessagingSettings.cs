using System.Collections.Generic;
using GS.Core.Messaging.Entities.Environment;

namespace GS.Core.Messaging.Entities.Common
{
    public class MessagingSettings
    {
        public EMessaging.Technology Technology { get; set; }
        public List<BrokerServer> Servers { get; set;}

        public MessagingSettings()
        {
            Servers = new List<BrokerServer>();
        }
    }
}