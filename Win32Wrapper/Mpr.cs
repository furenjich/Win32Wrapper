using System;
using System.Runtime.InteropServices;

namespace Yac.Win32Wrapper.Raw
{ 
    public class Mpr
    {
        public struct UNIVERSAL_NAME_INFO
        {
            public string lpUniversalName;
        }
        
        public struct REMOTE_NAME_INFO
        {
            public string lpUniversalName;
            public string lpConnectionName;
            public string lpRemainingPath;
        }

        public struct INFO_LEVEL
        {
            public const int UNIVERSAL_NAME_INFO_LEVEL = 0x00000001;
            public const int REMOTE_NAME_INFO_LEVEL = 0x00000002;
        }

        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        [return:MarshalAs(UnmanagedType.U4)]
        public static extern int WNetGetUniversalName(
        string lpLocalPath,
        [MarshalAs(UnmanagedType.U4)] int dwInfoLevel,
        IntPtr lpBuffer,
        [MarshalAs(UnmanagedType.U4)] ref int lpBufferSize);
    }
}
