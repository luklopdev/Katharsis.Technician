using System;

namespace Katharsis.Technician.Core
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependentViewAttribute : Attribute
    {
        public string Region { get; set; }
        public Type Type { get; set; }

        public DependentViewAttribute(string region, Type ribbonType)
        {
            if(region is null)
                throw new ArgumentNullException(nameof(region));

            if(ribbonType == null)
                throw new ArgumentException(nameof(ribbonType));

            Region = region;
            Type = ribbonType;
        }
    }
}
