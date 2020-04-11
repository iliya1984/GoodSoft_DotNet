using System.Collections.Generic;
using GS.Messaging.Entities.Environment;

namespace GS.Messaging.Entities.Common
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