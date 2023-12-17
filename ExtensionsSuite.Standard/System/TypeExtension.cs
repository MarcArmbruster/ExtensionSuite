namespace System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Extensions for the Type class.
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Gets all properties of the type marked with the given custom attribute.
        /// </summary>
        /// <param name="type">The type to inspect.</param>
        /// <param name="customAttributeType">The custom attribute.</param>
        /// <returns>All marked properties.</returns>
        public static IEnumerable<PropertyInfo> GetPropertiesWithCustomAttribute(this Type type, Type customAttributeType)
        {
            var allProperties = type.GetProperties();
            var properties = allProperties.Where(p => p.CustomAttributes.Any(ca => ca.AttributeType.Equals(customAttributeType)));
            return properties;
        }
    }
}