namespace System.IO
{
    public static class FileInfoExtensions
    {
        public static bool IsEncrypted(this FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                return false;
            }

            return fileInfo.Attributes.HasFlag(FileAttributes.Encrypted);
        }

        public static bool IsCompressed(this FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                return false;
            }

            return fileInfo.Attributes.HasFlag(FileAttributes.Compressed);
        }
    }
}