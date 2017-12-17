using System;
using System.IO;
using System.Runtime.InteropServices;
using Yac.Win32Wrapper.Raw;

namespace Yac
{
    namespace Win32Wrapper
    {
        public class DebugMessage
        {

            public DebugMessage()
            {
                str = "";
            }

            private const uint info = 0;
            private const uint err = 1;
            private const uint dbg = 2;
            private static string str;

            public static string Info(string s)
            {
                Kernel32.OutputDebugString(makeString(s, info));
                return str;
            }

            public static string Err(string s)
            {
                Kernel32.OutputDebugString(makeString(s, err));
                return str;
            }

            public static string ErrFunc(string func)
            {
                var lastError = Marshal.GetLastWin32Error();
                Kernel32.OutputDebugString(makeString(func + " failed(" + lastError.ToString() + ")", err));
                return str;
            }

            public static string Dbg(string s)
            {
                Kernel32.OutputDebugString(makeString(s, dbg));
                return str;
            }

            private static string makeString(string s, uint type)
            {
                str = "[" + Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]) + "]"; // current file name
                switch (type)
                {
                    case info:
                        str += "[INFO] ";
                        break;

                    case err:
                        str += "[ERR] ";
                        break;

                    case dbg:
                        str += "[DBG] ";
                        break;
                }

                str += s;
                return str;
            }

        }
    }
}