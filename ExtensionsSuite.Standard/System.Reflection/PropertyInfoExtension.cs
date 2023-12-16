namespace System.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// PropertyInfo extensions.
    /// </summary>
    public static class PropertyInfoExtension
    {
        public static IList<CustomAttributeData> GetCustomAttributesData(this PropertyInfo propertyInfo, Type customAttributeType)
        {
            if (propertyInfo == null)
            {
                return new List<CustomAttributeData>();
            }

            return propertyInfo.CustomAttributes.Where(ca => ca.AttributeType.Equals(customAttributeType)).ToList();
        }
    }
}