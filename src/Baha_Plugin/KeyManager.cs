using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Baha_Plugin
{
	internal class KeyManager
	{
		private List<Keys> keyList = new List<Keys>();

		private int clearTime;

		private static Keys StrToKey(string str)
		{
			switch (str)
			{
			case "0":
                    //return Keys.D0;
                return Keys.D9;
			case "1":
				return Keys.F1;
			case "2":
				return Keys.F2;
			case "3":
				return Keys.F3;
			case "4":
				return Keys.F4;
			case "5":
				return Keys.F5;
			case "6":
				return Keys.F6;
			case "7":
				return Keys.F7;
			case "8":
				return Keys.F8;
			default:
				return Keys.F13;
			}
		}

		public KeyManager(List<string> keystrList, int clearTime)
		{
			this.clearTime = clearTime;
			foreach (string keystr in keystrList)
			{
				keyList.Add(StrToKey(keystr));
			}
		}

		public void start()
		{
			Thread thread = new Thread(Run);
			thread.IsBackground = true;
			thread.Start();
		}

		private void Run()
		{
			try
			{
				IntPtr intPtr = Natives.Find("FINAL FANTASY XIV");
				if (!(intPtr == IntPtr.Zero))
				{
					foreach (Keys key in keyList)
					{
						Natives.SendKey(intPtr, key);
					}
					if (clearTime > 0)
					{
						Thread.Sleep(clearTime);
                        //Natives.SendKey(intPtr, Keys.D0);
                        Natives.SendKey(intPtr, Keys.D9);
					}
				}
			}
			catch
			{
			}
		}
	}
}
