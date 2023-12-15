namespace System.Threading.Tasks
{
    using ExtensionsSuite.Standard.Suite;

    /// <summary>
    /// Contains extension methods for the <see cref="Task"/> class.
    /// </summary>
    public static class TaskExtension
    {
        /// <summary>
        /// Checks whether a given task is "running", that is,
        /// it is already running or waiting to do so.
        /// </summary>
        /// <param name="source">The task to check.</param>
        /// <returns>True if the task is doing something, false otherwise.</returns>
        public static bool IsRunning(this Task source)
        {
            ValueChecker.ThrowIfNull(source);

            if (source == null)
            {
                return false;
            }

            return source.Status == TaskStatus.WaitingForActivation
                || source.Status == TaskStatus.WaitingToRun
                || source.Status == TaskStatus.Running;
        }
    }
}
