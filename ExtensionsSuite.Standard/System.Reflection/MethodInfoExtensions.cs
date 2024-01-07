namespace System.Reflection
{
    using System;
    using System.Linq;

    /// <summary>
    /// PropertyInfo extensions.
    /// </summary>
    public static class MethodInfoExtension
    {
        public static bool IsMethodAttributedWith(this MethodInfo methodInfo, Type customAttributeType)
        {
            if (methodInfo == null)
            {
                return false;
            }

            return methodInfo.CustomAttributes.Any(ca => ca.AttributeType.Equals(customAttributeType));
        }
    }
}