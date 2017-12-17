using System;
using Yac.Win32Wrapper;
using Yac.Win32Wrapper.Raw;

namespace Win32WrapperTest
{
    class Win32WrapperTest
    {
        private static void Kernel32Test()
        {
            Kernel32.OutputDebugString("Kernel32Test");
            DebugMessage.Info("Kernel32Test");
        }

        static void Main(string[] args)
        {
            Kernel32Test();
        }
    }
}
