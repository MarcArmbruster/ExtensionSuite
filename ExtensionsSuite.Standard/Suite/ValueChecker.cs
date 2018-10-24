namespace ExtensionsSuite.Standard.Suite
{
    using System;

    internal static class ValueChecker
    {
        /// <summary>
        /// Checks the given target object for a null reference.
        /// If there is a null reference a ArgumentNullException will be thrown.
        /// </summary>
        /// <param name="target">The traget to be checked.</param>
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