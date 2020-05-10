using GS.Core.Entities.Enums;

namespace GS.Core.Entities.Environments
{
    public class Environment
    {
        public string Name {get; set;}
        public ESystemManagement.EnvironmentType Type { get; set; }
    }
}