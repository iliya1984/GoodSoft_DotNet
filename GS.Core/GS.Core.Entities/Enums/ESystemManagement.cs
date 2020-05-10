namespace GS.Core.Entities.Enums
{
    public class ESystemManagement
    {
         public enum EnvironmentType
        {
            None,
            Development,
            Test,
            Preproduction,
            Production
        }
        
        public enum ModuleGroup
        {
            None,
            GoodSoft,
            GoodTravel
        }

        public enum Layer
        {
            None,
            DAL,
            BLL,
            API,
            Client,
            Test
        }   
    }
}