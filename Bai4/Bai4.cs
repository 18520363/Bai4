using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
namespace Bai4
{
    public partial class Bai4 : ServiceBase
    {
        public Bai4()
        {
            InitializeComponent();
        }
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSSendMessage(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.I4)] int SessionId,
            String pTitle,
            [MarshalAs(UnmanagedType.U4)] int TitleLength,
            String pMessage,
            [MarshalAs(UnmanagedType.U4)] int MessageLength,
            [MarshalAs(UnmanagedType.U4)] int Style,
            [MarshalAs(UnmanagedType.U4)] int Timeout,
            [MarshalAs(UnmanagedType.U4)] out int pResponse,
            bool bWait);
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern int WTSGetActiveConsoleSessionID();
        public static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        public static int WTS_CURRENT_SESSION = 68;

        public static void Popup()
        {
            bool result = false;
            String title = "Popup";
            int tlen = title.Length;
            String msg = "18520363";
            int mlen = msg.Length;
            int resp = 0;
            result = WTSSendMessage(WTS_CURRENT_SERVER_HANDLE, WTS_CURRENT_SESSION, title, tlen, msg, mlen, 0, 0, out resp, false);
        }
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLock:
                    LogEntry(string.Format("Locked at {0}", DateTime.Now));
                    break;
                case SessionChangeReason.SessionLogoff:
                    LogEntry(string.Format("Logged Off at {0}", DateTime.Now));
                    break;
                case SessionChangeReason.SessionLogon:
                    LogEntry(string.Format("Logged On at {0}", DateTime.Now));
                    break;
                case SessionChangeReason.SessionUnlock:
                    {
                        LogEntry(string.Format("Unlocked at {0}", DateTime.Now));
                        Popup();
                        break;
                    }
                default:
                    break;

            }
        }

        protected override void OnStart(string[] args)
            {
                LogEntry(string.Format("Service Started at {0}", DateTime.Now));
                //Popup();
            }

            protected override void OnStop()
            {
                LogEntry(string.Format("Service Stopped at {0}", DateTime.Now));
            }

            void LogEntry(string message)
            {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory +
           "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') +
           ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
