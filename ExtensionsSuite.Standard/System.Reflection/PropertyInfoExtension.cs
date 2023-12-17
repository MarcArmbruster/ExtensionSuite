namespace System.Reflection
{
    using System;
    using System.Linq;

    /// <summary>
    /// PropertyInfo extensions.
    /// </summary>
    public static class PropertyInfoExtension
    {
        /////// <summary>
        /////// Gets the attributed data
        /////// </summary>
        /////// <param name="propertyInfo">The property info.</param>
        /////// <param name="customAttributeType">The attribute</param>
        /////// <returns></returns>
        ////public static IList<CustomAttributeData> GetAttributesData(this PropertyInfo propertyInfo, Type customAttributeType)
        ////{
        ////    if (propertyInfo == null)
        ////    {
        ////        return new List<CustomAttributeData>();
        ////    }

        ////    return propertyInfo.CustomAttributes.Where(ca => ca.AttributeType.Equals(customAttributeType)).ToList();
        ////}

        public static bool IsAttributedWith(this PropertyInfo propertyInfo, Type customAttributeType)
        {
            if (propertyInfo == null)
            {
                return false;
            }

            return propertyInfo.CustomAttributes.Any(ca => ca.AttributeType.Equals(customAttributeType));
        }

        public static bool IsAttributedWith<T>(this PropertyInfo propertyInfo, Type customAttributeType)
        {
            if (propertyInfo == null)
            {
                return false;
            }

            return propertyInfo.CustomAttributes.Any(ca => ca.AttributeType.Equals(customAttributeType));
        }
    }
}