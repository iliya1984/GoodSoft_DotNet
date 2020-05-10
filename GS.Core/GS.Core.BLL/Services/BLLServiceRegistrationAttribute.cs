using System;

namespace GS.Core.BLL.Services
{
    public class BLLServiceRegistrationAttribute: Attribute
    {
        public Type RegisterAsType { get; private set; }

        public BLLServiceRegistrationAttribute(Type registerAsType)
        {
            RegisterAsType = registerAsType;
        }
    }
}