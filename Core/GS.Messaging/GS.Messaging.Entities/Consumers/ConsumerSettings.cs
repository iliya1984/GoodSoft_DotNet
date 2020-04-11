using System.Collections.Generic;
using GS.Messaging.Entities.Common;
using GS.Messaging.Entities.Environment;

namespace GS.Messaging.Entities.Consumers
{
    public class ConsumerSettings : MessagingSettings
    {
        public string Group { get; set;}
        public int? SessionTimeout { get; set; }
        public bool EnablePartition { get; set;}
    }
}