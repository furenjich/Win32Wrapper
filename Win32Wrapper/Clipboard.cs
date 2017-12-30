using System;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Runtime.InteropServices;
using Yac.Win32Wrapper.Raw;


namespace Yac
{
    namespace Win32Wrapper
    {       
        /// <summary>
        /// System.Windows.Form.Clipboard.GetText()とContainText()の再実装
        /// 勘違いで車輪の再開発をしてしまった
        /// </summary>
        public sealed class ClipboardWrapper : IDisposable
        {
            private static ClipboardWrapper instance = new ClipboardWrapper();
            private static IntPtr clipboardHandle = IntPtr.Zero;

            //クリップボードのデータを、別のデータ形式に変換するデリゲート
            private delegate T clipboardDataProcessor<T>(IntPtr clipboardDataHandle);

            //データをバイト列に変換するデリゲート
            private delegate byte[] dataToByteConverter<T>(T rawData);

            public static ClipboardWrapper Instance
            {
                get
                {
                    if(instance == null)
                    {
                        ClipboardWrapper.instance = new ClipboardWrapper();
                    }
                    return instance;
                }
            }

            private ClipboardWrapper()
            {
                User32.OpenClipboard(IntPtr.Zero);
            }

            private bool ContainsClipboard(uint format)
            {
                try
                {
                    Kernel32.GlobalUnlock(clipboardHandle);
                    clipboardHandle = User32.GetClipboardData(format);
                }
                catch
                {
                    return false;
                }
                return clipboardHandle != IntPtr.Zero;
            }

            public bool ContainsClipboardText()
            {
                return ContainsClipboard(User32.ClipboardFormat.CF_TEXT);
            }

            private T GetClipboardData<T>(uint format, clipboardDataProcessor<T> processor)
            {
                if (ContainsClipboard(format))
                {
                    try
                    {
                        var data = Kernel32.GlobalLock(clipboardHandle);
                        return processor(data);
                    }
                    catch
                    {
                        return default(T);
                    } 
                    finally
                    {
                        Kernel32.GlobalUnlock(clipboardHandle);
                    }
                }
                else
                {
                    return default(T);
                }
            }

            public string GetClipboardText()
            {
                return GetClipboardData<string>(User32.ClipboardFormat.CF_TEXT, Marshal.PtrToStringAnsi);
            }

            private IntPtr SetClipboardData<T>(uint format, T data, dataToByteConverter<T> converter)
            {
                User32.EmptyClipboard();

                try
                {
                    var pbData = converter(data);
                    IntPtr mem = Marshal.AllocCoTaskMem(pbData.Length + 1);
                    Marshal.Copy(pbData, 0, mem, pbData.Length);
                    return User32.SetClipboardData(format, mem);
                }
                catch
                {
                    return IntPtr.Zero;
                }
            }

            public string SetClipboardString(string str)
            {
                IntPtr ret = SetClipboardData<string>(User32.ClipboardFormat.CF_TEXT, str, Encoding.ASCII.GetBytes);
                return ret != IntPtr.Zero ? str : null;
            }

            public void Dispose()
            {
                Kernel32.GlobalUnlock(clipboardHandle);
                User32.CloseClipboard();
                clipboardHandle = IntPtr.Zero;
                instance = null;
            }                                 
        }

        //http://anis774.net/codevault/clipboardwatcher.html
        public sealed class ClipboardWatcherForm : Form
        {
            private IntPtr nextHandle;
            private ThreadStart proc;

            public void StartWatch(ThreadStart proc)
            {
                this.proc = proc;
                nextHandle = User32.SetClipboardViewer(Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == User32.WindowMesssage.WM_DRAWCLIPBOARD)
                {
                    User32.SendMessage(nextHandle, m.Msg, m.WParam, m.LParam);
                    proc();
                }
                else if (m.Msg == User32.WindowMesssage.WM_CHANGECBCHAIN)
                {
                    if (m.WParam == nextHandle)
                    {
                        nextHandle = m.LParam;
                    }
                    else
                    {
                        User32.SendMessage(nextHandle, m.Msg, m.WParam, m.LParam);
                    }
                }
                base.WndProc(ref m);
            }

            protected override void Dispose(bool disposing)
            {
                User32.ChangeClipboardChain(Handle, nextHandle);
                base.Dispose(disposing);
            }
        }

    }
}
