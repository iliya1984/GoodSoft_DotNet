using GS.Logging.Entities.Modules.Settings;

namespace GS.Logging.Entities
{
    public static class LoggingExtensions
    {
        public static LoggingModuleWrapper GetModuleWrapper(this LoggingModule module)
        {
            if(module == null)
            {
                return null;
            }

            return new LoggingModuleWrapper(module);
        }
        
    }
}