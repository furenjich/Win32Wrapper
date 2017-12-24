using System;
using Yac.Win32Wrapper;
using Yac.Win32Wrapper.Raw;
using System.Runtime.InteropServices;

namespace Win32WrapperTest
{
    class Win32WrapperTest
    {
        private static void Kernel32Test()
        {
            Kernel32.OutputDebugString("Kernel32Test");
            DebugMessage.Info("Kernel32Test");
        }

        private static void MarpTest()
        {
            string path = Environment.GetCommandLineArgs()[0];

            IntPtr lpBuffer = IntPtr.Zero;
            int size = 0;
            int errorCode = Mpr.WNetGetUniversalName(path, Mpr.INFO_LEVEL.UNIVERSAL_NAME_INFO_LEVEL, lpBuffer, ref size);
            if (errorCode != 0)
            {
                DebugMessage.Err("errorCode = " + errorCode);
                return;
            }
            Mpr.UNIVERSAL_NAME_INFO info = new Mpr.UNIVERSAL_NAME_INFO();
            Marshal.PtrToStructure(lpBuffer, info);
            DebugMessage.Info("unc path = " + info.lpUniversalName);
            
        }

        static void Main(string[] args)
        {
            Kernel32Test();
            MarpTest();
        }
    }
}
