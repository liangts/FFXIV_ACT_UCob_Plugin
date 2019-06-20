using Advanced_Combat_Tracker;
using FFXIV.Framework.FFXIVHelper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baha_Plugin
{
    class GrandOctetNavigation
    {
        private string[] dragons;
        public int clock_bahamut;

        public int clock_nael;

        public int clock_twin;

        public bool atPos(Combatant c, float x, float y)
        {
            float num = 0.3f;
            if (Math.Abs(c.PosX - x) < num && Math.Abs(c.PosY - y) < num)
            {
                return true;
            }
            return false;
        }

        public void initOctetSolver()
        {
            clock_bahamut = -16;
            clock_nael = -16;
            clock_twin = -16;
            dragons = new string[8];
            for (int i = 0; i < dragons.Length; i++)
            {
                dragons[i] = "";
            }
        }

        public void GrandOctetSolver()
        {
            try
            {
                initOctetSolver();
                Thread.Sleep(8300);
                FFXIVPlugin.Instance.GetCombatantList();
                IReadOnlyList<Combatant> list = FFXIVPlugin.Instance.GetCombatantList();

                float[] array = new float[8]
                {
                0f,
                16.7f,
                24f,
                16.7f,
                0f,
                -16.7f,
                -24f,
                -16.7f
                };
                float[] array2 = new float[8]
                {
                -24f,
                -16.7f,
                0f,
                16.7f,
                24f,
                16.7f,
                0f,
                -16.7f
                };
                string text = "";
                for (int i = 0; i <= 7; i++)
                {
                    if (!(dragons[i] != ""))
                    {
                        foreach (Combatant item in list)
                        {
                            if (atPos(item, array[i], array2[i]))
                            {
                                dragons[i] = item.Name;
                            }
                        }
                        if (dragons[i] == "Bahamut Prime" || dragons[i] == "バハムート・プライム" || dragons[i] == "至尊巴哈姆特")
                        {
                            clock_bahamut = i;
                        }
                        if (dragons[i] == "Twintania" || dragons[i] == "ツインタニア" || dragons[i] == "双塔尼亚")
                        {
                            clock_twin = i;
                        }
                        if (dragons[i] == "Nael deus Darnus" || dragons[i] == "ネール・デウス・ダーナス" || dragons[i] == "奈尔·神·达纳斯")
                        {
                            clock_nael = i;
                        }
                    }
                }
                if (clock_bahamut < -1)
                {
                    //return "Failed";
                    return;
                }
                int num = 0;
                int num2 = -1;
                if (clock_bahamut == 0 || clock_bahamut == 2 || clock_bahamut == 4 || clock_bahamut == 6)
                {
                    num = -1;
                }
                if (clock_bahamut == 1 || clock_bahamut == 3 || clock_bahamut == 5 || clock_bahamut == 7)
                {
                    num = 1;
                }
                switch (clock_bahamut)
                {
                    case 0:
                        text = "巴哈正北，";
                        break;
                    case 1:
                        text = "巴哈两点，";
                        break;
                    case 2:
                        text = "巴哈3点，";
                        break;
                    case 3:
                        text = "巴哈5点，";
                        break;
                    case 4:
                        text = "巴哈6点，";
                        break;
                    case 5:
                        text = "巴哈8点，";
                        break;
                    case 6:
                        text = "巴哈9点，";
                        break;
                    case 7:
                        text = "巴哈十点，";
                        break;
                    default:
                        text = "自己看，";
                        break;
                }
                //Check if Nael opposite side
                if (clock_nael == (clock_bahamut + 4) % 8)
                    text += "奈尔对面";
                bool flag = false;
                if (num != 0)
                {
                    num2 = (clock_bahamut + 5 * num + 8) % 8;
                    //Trace.WriteLine("巴哈 @ " + clock_bahamut.ToString() + " ,安全区:" + num2.ToString());
                    if (num2 == clock_nael || num2 == (clock_nael + 4) % 8)
                    {
                        //Trace.WriteLine("区域" + num2.ToString() + "被凶鸟覆盖!");
                        num2 = (num2 + num + 8) % 8;
                        int num3 = (clock_bahamut + num + 8) % 8;
                        int num4 = (num3 + num + 8) % 8;
                        if (num3 != clock_nael && num3 != clock_twin)
                        {
                            flag = true;
                            if (num4 != clock_nael)
                            {
                                int clock_twin2 = clock_twin;
                            }
                        }
                    }
                }
                /*
                switch ((num2 - clock_bahamut + 8) % 8)
                {
                    case 0:
                        text += "自己看，";
                        break;
                    case 1:
                        text += "右上右上，";
                        break;
                    case 2:
                        text += "右右右右，";
                        break;
                    case 3:
                        text += "右下右下，";
                        break;
                    case 4:
                        text += "下下下下，";
                        break;
                    case 5:
                        text += "左下左下，";
                        break;
                    case 6:
                        text += "左左左左，";
                        break;
                    case 7:
                        text += "左上左上，";
                        break;
                    default:
                        text += "自己看，";
                        break;
                }
                if ((num2 + num + 8) % 8 == clock_nael || (num2 + num + 8) % 8 == (clock_nael + 4) % 8)
                {
                    text += "凶鸟在前，";
                }
                if ((num2 - num + 8) % 8 == clock_nael || (num2 - num + 8) % 8 == (clock_nael + 4) % 8)
                {
                    text += "凶鸟在后，";
                }
                */
                if (num == 1)
                {
                    text += "，顺时针，顺时针";
                }
                if (num == -1)
                {
                    text += "，逆时针，逆时针";
                }
                /*
                if (flag)
                {
                    text += "前方有龙。";
                }
                */
                ActGlobals.oFormActMain.TTS(text);
                //return text;
            }
            catch
            {

            }
        }

        public void StartGrandOctetWatcher(){

            Thread thread = new Thread(GrandOctetSolver);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
