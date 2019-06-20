using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Baha_Plugin
{
	internal static class Natives
	{
		[DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
		private static extern int PostMessage(IntPtr handle, int msg, int param, int arg);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string className, string windowName);

		public static IntPtr Find(string name)
		{
			return FindWindow(null, "FINAL FANTASY XIV");
		}

		public static void SendKey(IntPtr handle, Keys key)
		{
			PostMessage(handle, 256, (int)key, 0);
			PostMessage(handle, 257, (int)key, 0);
			Thread.Sleep(100);
		}
	}
}
