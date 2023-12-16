namespace System
{
    /// <summary>
    /// Extensions for the Exception base type.
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Gets the most inner exception.
        /// </summary>
        /// <param name="exception">The catched exception.</param>
        /// <returns>The deepest inner exception.</returns>
        public static Exception GetDeepestInnerException(this Exception exception) 
        {
            if (exception == null)
            {
                return null;
            }
            
            if (exception.InnerException == null)
            {
                return exception;
            }
            else
            {
                return exception.InnerException.GetDeepestInnerException();
            }
        }
    }
}
