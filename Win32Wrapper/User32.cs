using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Yac
{
    namespace Win32Wrapper
    {
        namespace Raw
        {
            public class User32
            {
                public struct WindowMesssage
                {
                    //Window
                    public const uint WM_NULL = 0x0000;
                    public const uint WM_CREATE = 0x0001;
                    public const uint WM_DESTROY = 0x0002;
                    public const uint WM_MOVE = 0x0003;
                    public const uint WM_SIZE = 0x0005;
                    public const uint WM_ACTIVATE = 0x0006;
                    public const uint WM_SETFOCUS = 0x0007;
                    public const uint WM_KILLFOCUS = 0x0008;
                    public const uint WM_ENABLE = 0x000A;
                    public const uint WM_SETREDRAW = 0x000B;
                    public const uint WM_SETTEXT = 0x000C;
                    public const uint WM_GETTEXT = 0x000D;
                    public const uint WM_GETTEXTLENGTH = 0x000E;
                    public const uint WM_PAINT = 0x000F;
                    public const uint WM_CLOSE = 0x0010;
                    public const uint WM_QUIT = 0x0012;
                    public const uint WM_ERASEBKGND = 0x0014;
                    public const uint WM_SYSCOLORCHANGE = 0x0015;
                    public const uint WM_SHOWWINDOW = 0x0018;
                    public const uint WM_WININICHANGE = 0x001A;
                    public const uint WM_DEVMODECHANGE = 0x001B;
                    public const uint WM_ACTIVATEAPP = 0x001C;
                    public const uint WM_FONTCHANGE = 0x001D;
                    public const uint WM_TIMECHANGE = 0x001E;
                    public const uint WM_CANCELMODE = 0x001F;
                    public const uint WM_SETCURSOR = 0x0020;
                    public const uint WM_MOUSEACTIVATE = 0x0021;
                    public const uint WM_CHILDACTIVATE = 0x0022;
                    public const uint WM_QUEUESYNC = 0x0023;
                    public const uint WM_GETMINMAXINFO = 0x0024;
                    public const uint WM_PAINTICON = 0x0026;
                    public const uint WM_ICONERASEBKGND = 0x0027;
                    public const uint WM_NEXTDLGCTL = 0x0028;
                    public const uint WM_SPOOLERSTATUS = 0x002A;
                    public const uint WM_DRAWITEM = 0x002B;
                    public const uint WM_MEASUREITEM = 0x002C;
                    public const uint WM_DELETEITEM = 0x002D;
                    public const uint WM_VKEYTOITEM = 0x002E;
                    public const uint WM_CHARTOITEM = 0x002F;
                    public const uint WM_SETFONT = 0x0030;
                    public const uint WM_GETFONT = 0x0031;
                    public const uint WM_SETHOTKEY = 0x0032;
                    public const uint WM_GETHOTKEY = 0x0033;
                    public const uint WM_QUERYDRAGICON = 0x0037;
                    public const uint WM_COMPAREITEM = 0x0039;
                    public const uint WM_COMPACTING = 0x0041;
                    public const uint WM_COMMNOTIFY = 0x0044;
                    public const uint WM_WINDOWPOSCHANGING = 0x0046;
                    public const uint WM_WINDOWPOSCHANGED = 0x0047;
                    public const uint WM_POWER = 0x0048;

                    //Clipboard
                    public const uint WM_CUT = 0x0300;
                    public const uint WM_COPY = 0x0301;
                    public const uint WM_PASTE = 0x0302;
                    public const uint WM_CLEAR = 0x0303;
                    public const uint WM_UNDO = 0x0304;
                    public const uint WM_RENDERFORMAT = 0x0305;
                    public const uint WM_RENDERALLFORMATS = 0x0306;
                    public const uint WM_DESTROYCLIPBOARD = 0x0307;
                    public const uint WM_DRAWCLIPBOARD = 0x0308;
                    public const uint WM_PAINTCLIPBOARD = 0x0309;
                    public const uint WM_VSCROLLCLIPBOARD = 0x030A;
                    public const uint WM_SIZECLIPBOARD = 0x030B;
                    public const uint WM_ASKCBFORMATNAME = 0x030C;
                    public const uint WM_CHANGECBCHAIN = 0x030D;
                    public const uint WM_HSCROLLCLIPBOARD = 0x030E;
                    public const uint WM_QUERYNEWPALETTE = 0x030F;
                    public const uint WM_PALETTEISCHANGING = 0x0310;
                    public const uint WM_PALETTECHANGED = 0x0311;
                    public const uint WM_HOTKEY = 0x0312;
                }

                public struct CBTCode
                {
                    public const uint HCBT_MOVESIZE = 0;
                    public const uint HCBT_MINMAX = 1;
                    public const uint HCBT_QS = 2;
                    public const uint HCBT_CREATEWND = 3;
                    public const uint HCBT_DESTROYWND = 4;
                    public const uint HCBT_ACTIVATE = 5;
                    public const uint HCBT_CLICKSKIPPED = 6;
                    public const uint HCBT_KEYSKIPPED = 7;
                    public const uint HCBT_SYSCOMMAND = 8;
                    public const uint HCBT_SETFOCUS = 9;
                }

                public struct WindowShowStyle
                {
                    public const uint Hide = 0;
                    public const uint ShowNormal = 1;
                    public const uint ShowMinimized = 2;
                    public const uint ShowMaximized = 3;
                    public const uint Maximize = 3;
                    public const uint ShowNormalNoActivate = 4;
                    public const uint Show = 5;
                    public const uint Minimize = 6;
                    public const uint ShowMinNoActivate = 7;
                    public const uint ShowNoActivate = 8;
                    public const uint Restore = 9;
                    public const uint ShowDefault = 10;
                    public const uint ForceMinimized = 11;
                }

                public struct HookType
                {
                    public const uint WH_JOURNALRECORD = 0;
                    public const uint WH_JOURNALPLAYBACK = 1;
                    public const uint WH_KEYBOARD = 2;
                    public const uint WH_GETMESSAGE = 3;
                    public const uint WH_CALLWNDPROC = 4;
                    public const uint WH_CBT = 5;
                    public const uint WH_SYSMSGFILTER = 6;
                    public const uint WH_MOUSE = 7;
                    public const uint WH_HARDWARE = 8;
                    public const uint WH_DEBUG = 9;
                    public const uint WH_SHELL = 10;
                    public const uint WH_FOREGROUNDIDLE = 11;
                    public const uint WH_CALLWNDPROCRET = 12;
                    public const uint WH_KEYBOARD_LL = 13;
                    public const uint WH_MOUSE_LL = 14;
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct POINT
                {
                    public int X;
                    public int Y;

                    public POINT(int x, int y)
                    {
                        this.X = x;
                        this.Y = y;
                    }

                    public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }

                    public static implicit operator System.Drawing.Point(POINT p)
                    {
                        return new System.Drawing.Point(p.X, p.Y);
                    }

                    public static implicit operator POINT(System.Drawing.Point p)
                    {
                        return new POINT(p.X, p.Y);
                    }
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct MSG
                {
                    public IntPtr hwnd;
                    public UInt32 message;
                    public IntPtr wParam;
                    public IntPtr lParam;
                    public UInt32 time;
                    public POINT pt;
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct RECT
                {
                    public int left;
                    public int top;
                    public int right;
                    public int bottom;
                }

                public struct ClipboardFormat
                {
                    public const uint CF_TEXT = 1;
                    public const uint CF_BITMAP = 2;
                    public const uint CF_METAFILEPICT = 3;
                    public const uint CF_SYLK = 4;
                    public const uint CF_DIF = 5;
                    public const uint CF_TIFF = 6;
                    public const uint CF_OEMTEXT = 7;
                    public const uint CF_DIB = 8;
                    public const uint CF_PALETTE = 9;
                    public const uint CF_PENDATA = 10;
                    public const uint CF_RIFF = 11;
                    public const uint CF_WAVE = 12;
                    public const uint CF_UNICODETEXT = 13;
                    public const uint CF_ENHMETAFILE = 14;
                    public const uint CF_HDROP = 15;
                    public const uint CF_LOCALE = 16;
                    public const uint CF_DIBV5 = 17;
                    public const uint CF_MAX = 18;
                }

                public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern IntPtr SetClipboardViewer(IntPtr hwnd);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool ChangeClipboardChain(IntPtr hwnd, IntPtr hWndNext);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern IntPtr GetClipboardData(uint uFormat);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hwnd);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool OpenClipboard(IntPtr hWndNewOwner);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool CloseClipboard();

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool EmptyClipboard();

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool ShowWindows(IntPtr hwnd, WindowShowStyle nCmdShow);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool IsWindowVisible(IntPtr hwnd);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool IsWindowEnabled(IntPtr hwnd);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern IntPtr GetForegroundWindow();

                [DllImport("user32.dll", SetLastError = true)]
                public static extern IntPtr SetWindowsHookEx(int hooktype, HookProc lpfn, IntPtr hMod, uint dwThreadId);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern bool UnhookWindowsHookEx(IntPtr hHook);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern int GetMessage(out MSG lpMsg, IntPtr hwnd, uint wMsgFilterMin, uint wMsgFilterMax);

                [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

                [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                public static extern int GetWindowTextLength(IntPtr hWnd);

                [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
            }
        }
    }
}
