namespace System.Dynamic
{
    using System.Collections.Generic;
    
    public static class ExpandoObjectExtensions
    {
        /// <summary>
        /// Converts the instance to the dynamic type;
        /// </summary>
        /// <param name="target">The target instance.</param>
        /// <returns>The dynamic type representation of the instance.</returns>
        public static dynamic AsDynamic(this ExpandoObject target) => target as dynamic;

        /// <summary>
        /// Verifies whether the target instances contains a property with the given name.
        /// </summary>
        /// <param name="target">The target instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>True if property exists; false otherwise.</returns>
        public static bool ContainsProperty(this ExpandoObject target, string propertyName)
        {
            return ((IDictionary<string, object>)target).ContainsKey(propertyName);
        }

        /// <summary>
        /// Gets the property value. 
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="target">Target instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The property value. Default type value if not found.</returns>
        public static T GetPropertyValue<T>(this ExpandoObject target, string propertyName)
        {
            if (((IDictionary<string, object>)target).TryGetValue(propertyName, out var value))
            {
                return (T)value;
            }

            return default;
        }

        /// <summary>
        /// Tries t o get the value for the named property.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="target">Target instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">Out: The value.</param>
        /// <returns>True if a property is found</returns>
        public static bool TryGetPropertyValue<T>(this ExpandoObject target, string propertyName, out T value)
        {
            if (((IDictionary<string, object>)target).TryGetValue(propertyName, out var innerValue))
            {
                value = (T)innerValue;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Creates (or overrides) the dynamic property. 
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="target">Target instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        public static void CreateProperty<T>(this ExpandoObject target, string propertyName)
        {
            ((IDictionary<string, object>)target)[propertyName] = default(T);
        }

        /// <summary>
        /// Creates (or overrides) the dynamic properties. 
        /// </summary>
        /// <param name="target">Target instance.</param>
        /// <param name="properties">Types and names of the properties.</param>
        public static void CreateProperties(this ExpandoObject target, Dictionary<Type, string> properties)
        {
            foreach (var prop in properties)
            {
                if (prop.Key.IsValueType)
                {
                    ((IDictionary<string, object>)target)[prop.Value] = Activator.CreateInstance(prop.Key);
                }
                else
                {
                    ((IDictionary<string, object>)target)[prop.Value] = null;
                }
            }
        }

        /// <summary>
        /// Sets the value to the dynamic property. If the property does not exists, it will be created.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="target">Target instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value of the property</param>
        public static void SetPropertyValue<T>(this ExpandoObject target, string propertyName, T value)
        {
            ((IDictionary<string, object>)target)[propertyName] = value;
        }

        /// <summary>
        /// Checks whether the property value is null.
        /// </summary>
        /// <param name="target">Target instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>True if null, false otherwise.</returns>
        public static bool IsNull(this ExpandoObject target, string propertyName)
        {
            if (target.TryGetPropertyValue<object>(propertyName, out var value))
            {
                return value == null;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the property value is null or equals the default value for the given type.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="target">Target instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>True if null, false otherwise.</returns>

        public static bool IsNullOrDefault<T>(this ExpandoObject target, string propertyName)
        {
            if (target.TryGetPropertyValue<T>(propertyName, out T value))
            {
                return value == null || default(T).Equals(value);
            }

            return true;
        }
    }
}