//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.Runtime.InteropServices;


namespace Generic
{

    public static class WinAPI
    {
        [DllImport("user32.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ReleaseCapture();

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern bool LogonUser(string user, string domain, string password, int typeLogon, int logonProvider, ref IntPtr token);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ptrExists, int SECURITY_IMPERSONATION_LEVEL, ref IntPtr ptrDuplicate);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("kernel32", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public extern static bool SetConsoleFont(IntPtr hOutput, uint index);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr GetStdHandle(int dwType);

        [DllImport("netapi32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern uint NetUserChangePassword(string domain, string user, string oldPassword, string newPassword);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr GetProcessWindowStation();

        [DllImport("user32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr GetThreadDesktop(int dwThreadId);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int GetCurrentThreadId();
    }
}

