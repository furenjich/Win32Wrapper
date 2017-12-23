using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
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

            public static string Info(string s, [CallerFilePath]string filePath = null, [CallerLineNumber]int line = 0)
            {                
                Kernel32.OutputDebugString(makeString(s, info, filePath, line));
                return str;
            }

            public static string Err(string s, [CallerFilePath]string filePath = null, [CallerLineNumber]int line = 0)
            {
                Kernel32.OutputDebugString(makeString(s, err, filePath, line));
                return str;
            }

            public static string ErrFunc(string func, [CallerFilePath]string filePath = null, [CallerLineNumber]int line = 0)
            {
                var lastError = Marshal.GetLastWin32Error();
                Kernel32.OutputDebugString(makeString(func + " failed(" + lastError.ToString() + ")", err, filePath, line));
                return str;
            }

            public static string Dbg(string s, [CallerFilePath]string filePath = null, [CallerLineNumber]int line = 0)
            {
                Kernel32.OutputDebugString(makeString(s, dbg, filePath, line));
                return str;
            }

            private static string makeString(string s, uint type, string filePath, int line)
            {
                var applicationName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
                var sourceFileName = Path.GetFileNameWithoutExtension(filePath);
                str = "[" + applicationName + "][" + sourceFileName + ":" + line + "]";
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