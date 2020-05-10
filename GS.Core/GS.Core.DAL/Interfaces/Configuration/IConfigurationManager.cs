using GS.Core.DAL.Interfaces.Entities;

namespace GS.Core.DAL.Interfaces.Configuration
{
    public interface IConfigurationManager
    {
         IDbSettings GetSettings();
    }
}