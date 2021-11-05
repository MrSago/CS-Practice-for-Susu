
using System;
using System.Runtime.InteropServices;

namespace lab5.Extensions
{
    public static class WinInetHelper
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InternetSetOption(int hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

        public static unsafe bool SupressCookiePersist()
        {
            int option = 3;
            int* optionPtr = &option;
            return InternetSetOption(0, 81, new IntPtr(optionPtr), sizeof(int));
        }
    }
}

