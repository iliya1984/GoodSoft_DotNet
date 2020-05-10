using GS.Core.Entities.Enums;
using GS.Core.Entities.Environments;

namespace GS.Core.Entities.Entities.SystemManagement
{
    public class SystemInfo
    {
        public Environment Environment { get; set; }
        public Module Module { get; set; }
        public ESystemManagement.Layer Layer { get; set; }
        
    }
}