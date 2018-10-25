namespace ExtensionsSuite.Standard.System
{
    public enum NumericConversionBehavior
    {
        /// <summary>
        /// The default behavior - exception on conversion failure.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Returns the default value of the type instead of an exception on conversion failure.
        /// </summary>
        ReturnDefaultValueInsteadOfException = 1
    }
}
