namespace System
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ObjectExtensions
    {
        public static bool IsAttributedWith<T>(this T target, Type customAttributeType)
            where T : class
        {
            if (target == null)
            {
                return false;
            }

            return target.GetType().CustomAttributes.Any(ca => ca.AttributeType.Equals(customAttributeType));
        }

        /// <summary>
        /// Gets the values of the given property and attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static T GetAttributeValue<T>(
            this object obj, 
            string propertyName, 
            Type attributeType, 
            string attributeArgumentName) 
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
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
    }
}
