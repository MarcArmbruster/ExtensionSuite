namespace System.Security;

using System.Runtime.InteropServices;

public static class SecureStringExtensions
{
    /// <summary>
    /// Gets the raw string value out of a SecureString instance.
    /// </summary>
    /// <param name="value">The SecureString.</param>
    /// <returns>The raw string.</returns>
    public static string ToRawString(this SecureString value)
    {
        IntPtr pointer = IntPtr.Zero;
        try
        {
            pointer = Marshal.SecureStringToGlobalAllocUnicode(value);
            return Marshal.PtrToStringUni(pointer);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(pointer);
        }
    }
}