using System.Collections.Generic;
using GS.Messaging.Entities.Environment;

namespace GS.Messaging.Entities.Consumers
{
    public class ConsumerSettings
    {
        public List<BrokerServer> Servers { get; set;}
        public EMessaging.Technology Technology { get; set; }
        public string Group { get; set;}
        public int? SessionTimeout { get; set; }
        public bool EnablePartition { get; set;}

        public ConsumerSettings()
        {
            Servers = new List<BrokerServer>();
        }
    }
}