using Advanced_Combat_Tracker;
using FFXIV.Framework.FFXIVHelper;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Baha_Plugin
{
	public class Exaflare
	{
		private bool mode_tts;

		private float[] arrayX = new float[40]
		{
			-12f,
			-4f,
			4f,
			12f,
			22.63f,
			16.97f,
			11.31f,
			5.66f,
			20f,
			20f,
			20f,
			20f,
			22.63f,
			16.97f,
			11.31f,
			5.66f,
			-12f,
			-4f,
			4f,
			12f,
			-22.63f,
			-16.97f,
			-11.31f,
			-5.66f,
			-20f,
			-20f,
			-20f,
			-20f,
			-22.63f,
			-16.97f,
			-11.31f,
			-5.66f,
			-20f,
			-20f,
			20f,
			20f,
			-28.28f,
			28.28f,
			0f,
			0f
		};

		private float[] arrayY = new float[40]
		{
			-20f,
			-20f,
			-20f,
			-20f,
			-5.66f,
			-11.31f,
			-16.97f,
			-22.63f,
			-12f,
			-4f,
			4f,
			12f,
			5.66f,
			11.31f,
			16.97f,
			22.63f,
			20f,
			20f,
			20f,
			20f,
			5.66f,
			11.31f,
			16.97f,
			22.63f,
			-12f,
			-4f,
			4f,
			12f,
			-5.66f,
			-11.31f,
			-16.97f,
			-22.63f,
			-20f,
			20f,
			-20f,
			20f,
			0f,
			0f,
			-28.28f,
			28.28f
		};

		private bool AtPos(Combatant c, float x, float y)
		{
			float num = 0.3f;
			if (Math.Abs(c.PosX - x) < num)
			{
				return Math.Abs(c.PosY - y) < num;
			}
			return false;
		}

		private int FindExaflare()
		{
			FFXIVPlugin.Instance.RefreshCombatantList();
			IReadOnlyList<Combatant> combatantList = FFXIVPlugin.Instance.GetCombatantList();
			int i = -1;
			foreach (Combatant item in combatantList)
			{
				for (int j = 0; j < 32; j++)
				{
					if (AtPos(item, arrayX[j], arrayY[j]))
					{
						i = j / 4;
						if (mode_tts)
						{
							CameraInfo.Instance.Refresh();
							for (i += (int)((double)CameraInfo.Instance.Heading / (Math.PI / 4.0)); i < 0; i += 8)
							{
							}
							while (i >= 8)
							{
								i -= 8;
							}
						}
						break;
					}
				}
			}
			return i;
		}

		private void ExaflareWatcher()
		{
			Thread.Sleep(2000);
			string[] array = new string[8]
			{
				"A正点",
				"AB斜点",
				"B正点",
				"BC斜点",
				"C正点",
				"CD斜点",
				"D正点",
				"DA斜点"
			};
			string[] array2 = new string[8]
			{
				"前前前",
				"右前右前",
				"右右右",
				"右后右后",
				"后后后",
				"左后左后",
				"左左左",
				"左前左前"
			};
			int num = 10000;
			int num2;
			while (true)
			{
				if (num >= 0)
				{
					num2 = FindExaflare();
					if (num2 != -1)
					{
						break;
					}
					Thread.Sleep(100);
					num -= 100;
					continue;
				}
				return;
			}
			string text = "";
			if (num2 < 8)
			{
				text = ((!mode_tts) ? array[num2] : array2[num2]);
			}
			ActGlobals.oFormActMain.TTS(text);
		}

		public void StartExaflareWatcher(bool mode_exaflare)
		{
			mode_tts = mode_exaflare;
			Thread thread = new Thread(ExaflareWatcher);
			thread.IsBackground = true;
			thread.Start();
		}
	}
}
