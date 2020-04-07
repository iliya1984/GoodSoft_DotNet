namespace GS.Logging.Entities.Modules
{
    public class LoggingModuleWrapper
    {
        private LoggingModule _module;

        public LoggingModuleWrapper(LoggingModule module)
        {
            _module = module;
        }

        public ELogs.Module Type 
        { 
            get
            {  
                if(_module == null)
                {
                    return ELogs.Module.None;
                }

                return _module.Type;
            }
        }

        public ELogs.Layer Layer 
        { 
            get
            {  
                if(_module == null)
                {
                    return ELogs.Layer.None;
                }

                return _module.Layer;
            }
        }

        public string Name
        {
            get
            {
                if(_module == null)
                {
                    return string.Empty;
                }

                if(false == string.IsNullOrEmpty(_module.Name))
                {
                    return _module.Name;
                }

                if(_module.Type != ELogs.Module.None && _module.Layer != ELogs.Layer.None)
                {
                    return $"{_module.Type}{_module.Layer}";
                }

                return string.Empty;
            }
        }
    }
}