using System;

namespace ExtensionsSuite.Standard.Suite
{
    internal static class ValueChecker
    {
        internal static void ThrowIfNull(object target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(
                    nameof(target), 
                    "Target is not allowed to be null! Avoid calling extensions methods on null rerferences!");
            }
        }
    }
}
