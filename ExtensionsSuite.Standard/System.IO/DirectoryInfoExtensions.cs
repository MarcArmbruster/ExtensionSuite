namespace System.IO
{
   
    public static class DirectoryInfoExtensions
    {
        public static bool IsEncrypted(this DirectoryInfo directoryInfo)
        { 
            if (directoryInfo == null)
            {
                return false;
            }

            return directoryInfo.Attributes.HasFlag(FileAttributes.Encrypted);
        }

        public static bool IsCompressed(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                return false;
            }

            return directoryInfo.Attributes.HasFlag(FileAttributes.Compressed);
        }
    }
}
