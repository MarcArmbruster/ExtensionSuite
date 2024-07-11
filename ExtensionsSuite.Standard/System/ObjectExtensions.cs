namespace System
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json;

    public static class ObjectExtensions
    {
        public static bool IsTypeAttributedWith<T>(this T target, Type customAttributeType)
            where T : class
        {
            if (target == null)
            {
                return false;
            }

            var attributes = target.GetType().CustomAttributes;
            return attributes.Any(ca => ca.AttributeType == customAttributeType);
        }

        public static IEnumerable<PropertyInfo> GetAttributedProperties<T>(this T target, Type customAttributeType)
            where T : class
        {
            if (target == null)
            {
                return Enumerable.Empty<PropertyInfo>();
            }

            var propInfos = target.GetType().GetProperties();
            var attributes = propInfos.Where(pi => pi.IsPropertyAttributedWith(customAttributeType));
            return attributes;
        }

        /// <summary>
        /// Gets the values of the given property and attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <returns>The value.</returns>
        public static T GetAttributeValue<T>(
            this object target, 
            string propertyName, 
            Type attributeType, 
            string attributeArgumentName) 
        {
            var propertyInfo = target.GetType().GetProperty(propertyName);
            if (propertyInfo != null )
            {
                var data = propertyInfo.GetCustomAttributesData().Where(x => x.AttributeType.Equals(attributeType)).Distinct();
                
                var infos = data
                        .SelectMany(d => d.NamedArguments
                                        .Where(x => x.MemberName == attributeArgumentName));

                return (T)infos.Max().TypedValue.Value;
            }

            return default;
        }

        /// <summary>
        /// Gets all names of public, setable properties.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <returns>List of all public, setable properties.</returns>
        public static IList<string> GetSetablePropertyNames(this object target)
        {
            return target.GetType()
                .GetProperties(Reflection.BindingFlags.Instance | Reflection.BindingFlags.Public)
                .Where(p => p != null && p.CanWrite == true)
                .Select(p => p.Name)
                .ToList();
        }

        /// <summary>
        /// Gets all names of public, getable properties.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <returns>List of all public, setable properties.</returns>
        public static IList<string> GetGetablePropertyNames(this object target)
        {
            return target.GetType()
                .GetProperties(Reflection.BindingFlags.Instance | Reflection.BindingFlags.Public)
                .Where(p => p != null && p.CanRead == true)
                .Select(p => p.Name)
                .ToList();
        }

        /// <summary>
        /// DeepClone method for any object.
        /// Clones all public properties.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="source">Source object</param>
        /// <remarks>Inspired by https://andreslugo.dev/how-to-deep-clone-objects-in-c</remarks>
        /// <returns>The new, cloned instance</returns>
        public static T DeepClone<T>(this object source) where T : class
        {
            if (object.ReferenceEquals(source, null))
            {
                return default;
            }

            var deserializeSettings = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNameCaseInsensitive = true
            };

            var serialized = JsonSerializer.Serialize(source);
            var clone = JsonSerializer.Deserialize<T>(serialized, deserializeSettings);
            return clone;
        }
    }
}
