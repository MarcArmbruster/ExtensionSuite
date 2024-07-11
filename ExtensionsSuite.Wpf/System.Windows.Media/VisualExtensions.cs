namespace System.Windows.Media
{
    public static class VisualExtensions
    {
        /// <summary>
        /// Gets all Visual children of given parent Visual.
        /// </summary>
        /// <param name="parent">The parent visual.</param>
        /// <param name="recurse">False: search direct children, only. True search recursive through all sub hierarchy levels</param>
        /// <returns>Found children</returns>
        public static IEnumerable<Visual> GetChildren(this Visual parent, bool recurse = true)
        {
            if (parent != null)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    // Retrieve child visual at specified index value.
                    var child = VisualTreeHelper.GetChild(parent, i) as Visual;

                    if (child != null)
                    {
                        yield return child;

                        if (recurse)
                        {
                            foreach (var grandChild in child.GetChildren(true))
                            {
                                yield return grandChild;
                            }
                        }
                    }
                }
            }
        }
    }
}