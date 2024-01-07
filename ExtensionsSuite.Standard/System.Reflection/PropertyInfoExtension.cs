namespace System.Reflection
{
    using System;
    using System.Linq;

    /// <summary>
    /// PropertyInfo extensions.
    /// </summary>
    public static class PropertyInfoExtension
    {
        public static bool IsPropertyAttributedWith(this PropertyInfo propertyInfo, Type customAttributeType)
        {
            if (propertyInfo == null)
            {
                return false;
            }

            return propertyInfo.CustomAttributes.Any(ca => ca.AttributeType.Equals(customAttributeType));
        }
    }
}