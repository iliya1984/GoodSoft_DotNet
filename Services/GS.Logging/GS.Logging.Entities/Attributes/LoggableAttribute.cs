using System;
using GS.Logging.Entities;
using GS.Logging.Entities.Modules;

namespace GS.Logging.Entities.Attributes
{
    public class LoggableAttribute : Attribute
    {
        public LoggingModule Module { get; private set; }

        public LoggableAttribute(LoggingModule module)
        {
            Module = module;
        }

        public LoggableAttribute(string module, ELogs.Layer layer)
        {
            Module = new LoggingModule
            {
                Name = module,
                Group = module,
                Layer = new LoggingLayer
                {
                    Name = layer.ToString(),
                    Group = layer
                }
            };
        }
    }
}