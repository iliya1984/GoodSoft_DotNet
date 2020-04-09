namespace GS.Logging.Entities.Modules
{
    public class LoggingModuleWrapper
    {
        private LoggingModule _module;

        public LoggingModuleWrapper(LoggingModule module)
        {
            _module = module;
        }

        public string Group
        { 
            get
            {  
                if(_module == null)
                {
                    return string.Empty;
                }

                return _module.Group;
            }
        }

        public ELogs.Layer LayerGroup 
        { 
            get
            {  
                if(_module == null || _module.Layer == null)
                {
                    return ELogs.Layer.None;
                }

                return _module.Layer.Group;
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

                if(false == string.IsNullOrEmpty(_module.Group) && _module.Layer != null)
                {
                    if(_module.Layer.Group != ELogs.Layer.None)
                    {
                        return $"{_module.Group}{_module.Layer.Group}";
                    }
                    if(false == string.IsNullOrEmpty(_module.Layer.Name))
                    {
                        return $"{_module.Group}{_module.Layer.Name}";
                    }
                }

                return string.Empty;
            }
        }
    }
}