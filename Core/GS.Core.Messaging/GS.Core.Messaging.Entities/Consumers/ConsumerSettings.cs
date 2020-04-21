using System.Collections.Generic;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Environment;

namespace GS.Core.Messaging.Entities.Consumers
{
    public class ConsumerSettings : MessagingSettings
    {
        public string Group { get; set;}
        public int? SessionTimeout { get; set; }
        public bool EnablePartition { get; set;}
    }
}