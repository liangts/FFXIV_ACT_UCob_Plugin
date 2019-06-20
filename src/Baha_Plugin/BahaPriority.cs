using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Baha_Plugin
{
	public class BahaPriority : UserControl, IActPluginV1
	{
		private IContainer components;

		private Label lblStatus;

		private string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\BahaLianji.config.xml");

		private RadioButton player5RadioButton;

		private RadioButton player4RadioButton;

		private RadioButton player6RadioButton;

		private RadioButton player2RadioButton;

		private RadioButton player7RadioButton;

		private RadioButton player3RadioButton;

		private RadioButton player8RadioButton;

		private RadioButton player1RadioButton;

		private Panel panel1;

		private TextBox player8TextBox;

		private TextBox player7TextBox;

		private TextBox player6TextBox;

		private TextBox player5TextBox;

		private TextBox player4TextBox;

		private TextBox player3TextBox;

		private TextBox player2TextBox;

		private TextBox player1TextBox;

		private Label instructionLabel;

		private Label label2;

		private Panel panel2;

		private Label label5;

		private Label label4;

		private Label label3;

		private TextBox tts3TextBox;

		private TextBox tts2TextBox;

		private TextBox tts1TextBox;

		private BackgroundWorker backgroundWorker1;

		private TextBox logsTextBox;

		private Label infoLabel;

		private Panel panel3;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private Label label1;

		private Label label6;

		private Label label7;

		private TextBox textBox4;

		private Label label11;

		private Panel panel4;

		private TextBox textBox5;

		private TextBox textBox6;

		private TextBox textBox7;

		private Label label8;

		private Label label9;

		private Label label10;

		private PictureBox pictureBox1;

		private Panel panel5;

		private TextBox textBox8;

		private TextBox textBox9;

		private TextBox textBox15;

		private TextBox textBox14;

		private TextBox textBox10;

		private TextBox textBox13;

		private TextBox textBox12;

		private TextBox textBox11;

		private Label label12;

		private Label label13;

		private Label label14;

		private Panel panel6;

		private CheckBox checkBox5;

		private CheckBox checkBox4;

		private CheckBox checkBox3;

		private CheckBox checkBox2;

		private CheckBox checkBox1;

		private TextBox textBox16;

		private Button button1;

		private Button button2;

		private CheckBox checkBox7;

		private CheckBox checkBox6;

		private Button button3;

		private CheckBox checkBox8;

		private TextBox textBox17;

		private Label label15;

		private CheckBox checkBox9;

		private CheckBox checkBox10;

		private CheckBox checkBox11;

		private Label label16;

		private Panel panel7;

		private TextBox textBox18;

		private TextBox textBox19;

		private TextBox textBox20;

		private TextBox textBox21;

		private TextBox textBox22;

		private TextBox textBox23;

		private TextBox textBox24;

		private TextBox textBox25;

		private Label label17;

		private SettingsSerializer xmlSettings;

		private List<string> selectedPlayers_ball = new List<string>();

		private List<string> selectedPlayers_shake = new List<string>();

		private List<string> selectedPlayers_dive = new List<string>();

        private List<string> selectedPlayers_Megaflare_share = new List<string>();

        private List<string> playerJob_ball1 = new List<string>();
        private bool isBlackBallFirstRun = true;

        private List<string> tts_ball1 = new List<string>();
        
		private List<string> tts_ball2 = new List<string>();

		private List<string> tts_shake = new List<string>();

		private List<string> players = new List<string>();

		private List<string> playerkeys = new List<string>();

		private List<string> nicknames = new List<string>();

		private bool enabled_tts_ball1;

		private bool enabled_tts_ball2;

		private bool enabled_tts_shake;

		private bool enabled_key_ball2;

		private bool enabled_key_shake;

		private bool enabled_key_shuangta;

		private bool enabled_tts_shuangta;

		private bool enabled_key_shake2;

		private bool enabled_tts_exaflare;

		private bool mode_shuangta;

		private bool mode_exaflare;

		private int clearTime = 3500;

		private string regex_ball = "1B:.+:.+:0000:.+:0076:0000:0000:0000:";

		private string regex_shake = "1B:.+:.+:0000:.+:0028:0000:0000:0000:";

		private string regex_dive_other = "1B:.+:.+:0000:.+:(0077|0029|0014):0000:0000:0000:";

        private string regex_megaflare_share = "1B:.+:([^:]*):0000:0000:0027:0000:0000:0000:";

        private int yourIndex;

		private bool lianji;

		private bool qunlong;

		private int ballCount;

		private int shakeCount;

        private int shareCount;

		private int ballChance = 1;

		private int shakeChance = 1;
        private CheckBox checkBox_Commander;
        private int diveChance = 1;
        private int shareChance = 0;
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.player1RadioButton = new System.Windows.Forms.RadioButton();
            this.player2RadioButton = new System.Windows.Forms.RadioButton();
            this.player3RadioButton = new System.Windows.Forms.RadioButton();
            this.player4RadioButton = new System.Windows.Forms.RadioButton();
            this.player5RadioButton = new System.Windows.Forms.RadioButton();
            this.player6RadioButton = new System.Windows.Forms.RadioButton();
            this.player7RadioButton = new System.Windows.Forms.RadioButton();
            this.player8RadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.player1TextBox = new System.Windows.Forms.TextBox();
            this.player2TextBox = new System.Windows.Forms.TextBox();
            this.player3TextBox = new System.Windows.Forms.TextBox();
            this.player4TextBox = new System.Windows.Forms.TextBox();
            this.player5TextBox = new System.Windows.Forms.TextBox();
            this.player6TextBox = new System.Windows.Forms.TextBox();
            this.player7TextBox = new System.Windows.Forms.TextBox();
            this.player8TextBox = new System.Windows.Forms.TextBox();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tts1TextBox = new System.Windows.Forms.TextBox();
            this.tts2TextBox = new System.Windows.Forms.TextBox();
            this.tts3TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.logsTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkBox_Commander = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // player1RadioButton
            // 
            this.player1RadioButton.AutoSize = true;
            this.player1RadioButton.Checked = true;
            this.player1RadioButton.Location = new System.Drawing.Point(3, 13);
            this.player1RadioButton.Name = "player1RadioButton";
            this.player1RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player1RadioButton.TabIndex = 0;
            this.player1RadioButton.TabStop = true;
            this.player1RadioButton.UseVisualStyleBackColor = true;
            this.player1RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // player2RadioButton
            // 
            this.player2RadioButton.AutoSize = true;
            this.player2RadioButton.Location = new System.Drawing.Point(3, 34);
            this.player2RadioButton.Name = "player2RadioButton";
            this.player2RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player2RadioButton.TabIndex = 1;
            this.player2RadioButton.TabStop = true;
            this.player2RadioButton.UseVisualStyleBackColor = true;
            this.player2RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // player3RadioButton
            // 
            this.player3RadioButton.AutoSize = true;
            this.player3RadioButton.Location = new System.Drawing.Point(3, 55);
            this.player3RadioButton.Name = "player3RadioButton";
            this.player3RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player3RadioButton.TabIndex = 2;
            this.player3RadioButton.TabStop = true;
            this.player3RadioButton.UseVisualStyleBackColor = true;
            this.player3RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // player4RadioButton
            // 
            this.player4RadioButton.AutoSize = true;
            this.player4RadioButton.Location = new System.Drawing.Point(3, 77);
            this.player4RadioButton.Name = "player4RadioButton";
            this.player4RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player4RadioButton.TabIndex = 3;
            this.player4RadioButton.TabStop = true;
            this.player4RadioButton.UseVisualStyleBackColor = true;
            this.player4RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // player5RadioButton
            // 
            this.player5RadioButton.AutoSize = true;
            this.player5RadioButton.Location = new System.Drawing.Point(3, 98);
            this.player5RadioButton.Name = "player5RadioButton";
            this.player5RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player5RadioButton.TabIndex = 4;
            this.player5RadioButton.TabStop = true;
            this.player5RadioButton.UseVisualStyleBackColor = true;
            this.player5RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // player6RadioButton
            // 
            this.player6RadioButton.AutoSize = true;
            this.player6RadioButton.Location = new System.Drawing.Point(3, 119);
            this.player6RadioButton.Name = "player6RadioButton";
            this.player6RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player6RadioButton.TabIndex = 5;
            this.player6RadioButton.TabStop = true;
            this.player6RadioButton.UseVisualStyleBackColor = true;
            this.player6RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // player7RadioButton
            // 
            this.player7RadioButton.AutoSize = true;
            this.player7RadioButton.Location = new System.Drawing.Point(3, 140);
            this.player7RadioButton.Name = "player7RadioButton";
            this.player7RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player7RadioButton.TabIndex = 6;
            this.player7RadioButton.TabStop = true;
            this.player7RadioButton.UseVisualStyleBackColor = true;
            this.player7RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // player8RadioButton
            // 
            this.player8RadioButton.AutoSize = true;
            this.player8RadioButton.Location = new System.Drawing.Point(3, 162);
            this.player8RadioButton.Name = "player8RadioButton";
            this.player8RadioButton.Size = new System.Drawing.Size(14, 13);
            this.player8RadioButton.TabIndex = 7;
            this.player8RadioButton.TabStop = true;
            this.player8RadioButton.UseVisualStyleBackColor = true;
            this.player8RadioButton.CheckedChanged += new System.EventHandler(this.updatePlayerIndex);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.player1TextBox);
            this.panel1.Controls.Add(this.player2TextBox);
            this.panel1.Controls.Add(this.player3TextBox);
            this.panel1.Controls.Add(this.player4TextBox);
            this.panel1.Controls.Add(this.player5TextBox);
            this.panel1.Controls.Add(this.player6TextBox);
            this.panel1.Controls.Add(this.player7TextBox);
            this.panel1.Controls.Add(this.player8TextBox);
            this.panel1.Controls.Add(this.player1RadioButton);
            this.panel1.Controls.Add(this.player2RadioButton);
            this.panel1.Controls.Add(this.player3RadioButton);
            this.panel1.Controls.Add(this.player4RadioButton);
            this.panel1.Controls.Add(this.player5RadioButton);
            this.panel1.Controls.Add(this.player6RadioButton);
            this.panel1.Controls.Add(this.player7RadioButton);
            this.panel1.Controls.Add(this.player8RadioButton);
            this.panel1.Location = new System.Drawing.Point(3, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 187);
            this.panel1.TabIndex = 8;
            // 
            // player1TextBox
            // 
            this.player1TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player1TextBox.Location = new System.Drawing.Point(23, 10);
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(124, 23);
            this.player1TextBox.TabIndex = 8;
            this.player1TextBox.Text = "骑士";
            this.player1TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player2TextBox
            // 
            this.player2TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player2TextBox.Location = new System.Drawing.Point(23, 31);
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(124, 23);
            this.player2TextBox.TabIndex = 9;
            this.player2TextBox.Text = "战士";
            this.player2TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player3TextBox
            // 
            this.player3TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player3TextBox.Location = new System.Drawing.Point(23, 53);
            this.player3TextBox.Name = "player3TextBox";
            this.player3TextBox.Size = new System.Drawing.Size(124, 23);
            this.player3TextBox.TabIndex = 10;
            this.player3TextBox.Text = "忍者";
            this.player3TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player4TextBox
            // 
            this.player4TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player4TextBox.Location = new System.Drawing.Point(23, 74);
            this.player4TextBox.Name = "player4TextBox";
            this.player4TextBox.Size = new System.Drawing.Size(124, 23);
            this.player4TextBox.TabIndex = 11;
            this.player4TextBox.Text = "龙骑";
            this.player4TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player5TextBox
            // 
            this.player5TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player5TextBox.Location = new System.Drawing.Point(23, 95);
            this.player5TextBox.Name = "player5TextBox";
            this.player5TextBox.Size = new System.Drawing.Size(124, 23);
            this.player5TextBox.TabIndex = 12;
            this.player5TextBox.Text = "诗人";
            this.player5TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player6TextBox
            // 
            this.player6TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player6TextBox.Location = new System.Drawing.Point(23, 116);
            this.player6TextBox.Name = "player6TextBox";
            this.player6TextBox.Size = new System.Drawing.Size(124, 23);
            this.player6TextBox.TabIndex = 13;
            this.player6TextBox.Text = "召唤";
            this.player6TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player7TextBox
            // 
            this.player7TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player7TextBox.Location = new System.Drawing.Point(23, 137);
            this.player7TextBox.Name = "player7TextBox";
            this.player7TextBox.Size = new System.Drawing.Size(124, 23);
            this.player7TextBox.TabIndex = 14;
            this.player7TextBox.Text = "学者";
            this.player7TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // player8TextBox
            // 
            this.player8TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.player8TextBox.Location = new System.Drawing.Point(23, 158);
            this.player8TextBox.Name = "player8TextBox";
            this.player8TextBox.Size = new System.Drawing.Size(124, 23);
            this.player8TextBox.TabIndex = 15;
            this.player8TextBox.Text = "白魔";
            this.player8TextBox.TextChanged += new System.EventHandler(this.updatePlayers);
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.Location = new System.Drawing.Point(804, 10);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(261, 114);
            this.instructionLabel.TabIndex = 11;
            this.instructionLabel.Text = "【国际服连击群龙地火专用轮椅(ver1.2.0)】\r\n请自行生成8个宏(同神兵科技)\r\n第n宏如下/mk attack <n>  (记得替换n)\r\n然后对应键位f" +
    "1-f8\r\n然后在数字9上(不是小键盘)放清除宏\r\n队伍中只能有一个人开启指挥模式";
            this.instructionLabel.Click += new System.EventHandler(this.InstructionLabel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tts1TextBox);
            this.panel2.Controls.Add(this.tts2TextBox);
            this.panel2.Controls.Add(this.tts3TextBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(289, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 79);
            this.panel2.TabIndex = 13;
            // 
            // tts1TextBox
            // 
            this.tts1TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tts1TextBox.Location = new System.Drawing.Point(54, 7);
            this.tts1TextBox.Name = "tts1TextBox";
            this.tts1TextBox.Size = new System.Drawing.Size(176, 23);
            this.tts1TextBox.TabIndex = 3;
            this.tts1TextBox.Text = "黑球BBB";
            this.tts1TextBox.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // tts2TextBox
            // 
            this.tts2TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tts2TextBox.Location = new System.Drawing.Point(54, 31);
            this.tts2TextBox.Name = "tts2TextBox";
            this.tts2TextBox.Size = new System.Drawing.Size(176, 23);
            this.tts2TextBox.TabIndex = 4;
            this.tts2TextBox.Text = "黑球CCC";
            this.tts2TextBox.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // tts3TextBox
            // 
            this.tts3TextBox.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tts3TextBox.Location = new System.Drawing.Point(54, 55);
            this.tts3TextBox.Name = "tts3TextBox";
            this.tts3TextBox.Size = new System.Drawing.Size(176, 23);
            this.tts3TextBox.TabIndex = 5;
            this.tts3TextBox.Text = "黑球DDD";
            this.tts3TextBox.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label5.Location = new System.Drawing.Point(3, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "3rd TTS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "2nd TTS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "1st TTS";
            // 
            // logsTextBox
            // 
            this.logsTextBox.Location = new System.Drawing.Point(7, 255);
            this.logsTextBox.MaxLength = 1000000;
            this.logsTextBox.Multiline = true;
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.ReadOnly = true;
            this.logsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logsTextBox.Size = new System.Drawing.Size(788, 137);
            this.logsTextBox.TabIndex = 14;
            this.logsTextBox.Text = "Started..";
            this.logsTextBox.WordWrap = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.infoLabel.Location = new System.Drawing.Point(871, 387);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(154, 34);
            this.infoLabel.TabIndex = 15;
            this.infoLabel.Text = "人间之表 logo@mad.moe\r\nCore Dumped@Ultros";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.textBox4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(289, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 110);
            this.panel3.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label11.Location = new System.Drawing.Point(3, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "4th TTS";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox1.Location = new System.Drawing.Point(54, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "右右右";
            this.textBox1.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox2.Location = new System.Drawing.Point(54, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 23);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "右下右下";
            this.textBox2.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox3.Location = new System.Drawing.Point(54, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(176, 23);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "左下左下";
            this.textBox3.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox4.Location = new System.Drawing.Point(54, 79);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(176, 23);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "左左左";
            this.textBox4.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "3rd TTS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label6.Location = new System.Drawing.Point(3, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "2nd TTS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "1st TTS";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.textBox6);
            this.panel4.Controls.Add(this.textBox7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(533, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 79);
            this.panel4.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox5.Location = new System.Drawing.Point(54, 7);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(194, 23);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "截球BBB";
            this.textBox5.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox6.Location = new System.Drawing.Point(54, 31);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(194, 23);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "截球CCC";
            this.textBox6.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox7.Location = new System.Drawing.Point(54, 55);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(194, 23);
            this.textBox7.TabIndex = 5;
            this.textBox7.Text = "截球DDD";
            this.textBox7.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label8.Location = new System.Drawing.Point(3, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "3rd TTS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label9.Location = new System.Drawing.Point(3, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "2nd TTS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label10.Location = new System.Drawing.Point(3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "1st TTS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.tenstrike_4;
            this.pictureBox1.Location = new System.Drawing.Point(821, 188);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox8);
            this.panel5.Controls.Add(this.textBox9);
            this.panel5.Controls.Add(this.textBox10);
            this.panel5.Controls.Add(this.textBox11);
            this.panel5.Controls.Add(this.textBox12);
            this.panel5.Controls.Add(this.textBox13);
            this.panel5.Controls.Add(this.textBox14);
            this.panel5.Controls.Add(this.textBox15);
            this.panel5.Location = new System.Drawing.Point(162, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(46, 187);
            this.panel5.TabIndex = 17;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox8.Location = new System.Drawing.Point(3, 10);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(34, 23);
            this.textBox8.TabIndex = 16;
            this.textBox8.Text = "1";
            this.textBox8.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox9.Location = new System.Drawing.Point(3, 31);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(34, 23);
            this.textBox9.TabIndex = 17;
            this.textBox9.Text = "2";
            this.textBox9.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox10.Location = new System.Drawing.Point(3, 53);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(34, 23);
            this.textBox10.TabIndex = 18;
            this.textBox10.Text = "3";
            this.textBox10.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox11.Location = new System.Drawing.Point(3, 74);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(34, 23);
            this.textBox11.TabIndex = 19;
            this.textBox11.Text = "4";
            this.textBox11.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox12.Location = new System.Drawing.Point(3, 95);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(34, 23);
            this.textBox12.TabIndex = 20;
            this.textBox12.Text = "5";
            this.textBox12.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox13.Location = new System.Drawing.Point(3, 116);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(34, 23);
            this.textBox13.TabIndex = 21;
            this.textBox13.Text = "6";
            this.textBox13.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox14.Location = new System.Drawing.Point(3, 137);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(34, 23);
            this.textBox14.TabIndex = 22;
            this.textBox14.Text = "7";
            this.textBox14.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox15.Location = new System.Drawing.Point(3, 158);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(34, 23);
            this.textBox15.TabIndex = 23;
            this.textBox15.Text = "8";
            this.textBox15.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "队员ID（根据职业）";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(155, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "队员标号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 20;
            this.label14.Text = "我";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.checkBox_Commander);
            this.panel6.Controls.Add(this.checkBox11);
            this.panel6.Controls.Add(this.checkBox9);
            this.panel6.Controls.Add(this.checkBox10);
            this.panel6.Controls.Add(this.textBox17);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.checkBox8);
            this.panel6.Controls.Add(this.checkBox7);
            this.panel6.Controls.Add(this.checkBox6);
            this.panel6.Controls.Add(this.checkBox5);
            this.panel6.Controls.Add(this.checkBox4);
            this.panel6.Controls.Add(this.checkBox3);
            this.panel6.Controls.Add(this.checkBox2);
            this.panel6.Controls.Add(this.checkBox1);
            this.panel6.Location = new System.Drawing.Point(533, 110);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(265, 139);
            this.panel6.TabIndex = 21;
            // 
            // checkBox_Commander
            // 
            this.checkBox_Commander.AutoSize = true;
            this.checkBox_Commander.Location = new System.Drawing.Point(122, 79);
            this.checkBox_Commander.Name = "checkBox_Commander";
            this.checkBox_Commander.Size = new System.Drawing.Size(96, 16);
            this.checkBox_Commander.TabIndex = 34;
            this.checkBox_Commander.Text = "打开指挥模式";
            this.checkBox_Commander.UseVisualStyleBackColor = true;
            this.checkBox_Commander.CheckedChanged += new System.EventHandler(this.CheckBox12_CheckedChanged);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(5, 98);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(108, 16);
            this.checkBox11.TabIndex = 33;
            this.checkBox11.Text = "根据镜头报地火";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(123, 98);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(108, 16);
            this.checkBox9.TabIndex = 32;
            this.checkBox9.Text = "使用别称报双塔";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(5, 80);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(114, 16);
            this.checkBox10.TabIndex = 31;
            this.checkBox10.Text = "打开地火报点TTS";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(176, 118);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(66, 21);
            this.textBox17.TabIndex = 30;
            this.textBox17.Text = "3500";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox17.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(167, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "清除标记时间（0表示不清除）";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(123, 44);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(132, 16);
            this.checkBox8.TabIndex = 28;
            this.checkBox8.Text = "第二次摇动自动标点";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(123, 62);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(120, 16);
            this.checkBox7.TabIndex = 26;
            this.checkBox7.Text = "打开双塔引导标点";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(5, 62);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(114, 16);
            this.checkBox6.TabIndex = 25;
            this.checkBox6.Text = "打开双塔引导TTS";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(123, 26);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(144, 16);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "打开大地摇动自动标点";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(123, 8);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(120, 16);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "打开截球自动标点";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(5, 44);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(114, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "打开大地摇动TTS";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(5, 26);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "打开截球TTS";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "打开黑球TTS";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.updateTSS);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(239, 24);
            this.label16.TabIndex = 34;
            this.label16.Text = "ID必须按照顺序（和站位图相关）：\n骑士 战士 忍者 龙骑 诗人 召唤 学者 白魔";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(454, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "双塔测试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "大地测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "黑球测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(820, 127);
            this.textBox16.Multiline = true;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(205, 55);
            this.textBox16.TabIndex = 22;
            this.textBox16.Text = "/mk attack1 <attack1>\r\n/mk attack2 <attack2>\r\n/mk attack3 <attack3>\r\n/mk attack4 " +
    "<attack4>";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.textBox18);
            this.panel7.Controls.Add(this.textBox19);
            this.panel7.Controls.Add(this.textBox20);
            this.panel7.Controls.Add(this.textBox21);
            this.panel7.Controls.Add(this.textBox22);
            this.panel7.Controls.Add(this.textBox23);
            this.panel7.Controls.Add(this.textBox24);
            this.panel7.Controls.Add(this.textBox25);
            this.panel7.Location = new System.Drawing.Point(214, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(69, 187);
            this.panel7.TabIndex = 24;
            // 
            // textBox18
            // 
            this.textBox18.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox18.Location = new System.Drawing.Point(3, 10);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(63, 23);
            this.textBox18.TabIndex = 16;
            this.textBox18.Text = "骑士";
            this.textBox18.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox19
            // 
            this.textBox19.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox19.Location = new System.Drawing.Point(3, 31);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(63, 23);
            this.textBox19.TabIndex = 17;
            this.textBox19.Text = "战士";
            this.textBox19.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox20
            // 
            this.textBox20.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox20.Location = new System.Drawing.Point(3, 53);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(63, 23);
            this.textBox20.TabIndex = 18;
            this.textBox20.Text = "忍者";
            this.textBox20.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox21
            // 
            this.textBox21.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox21.Location = new System.Drawing.Point(3, 74);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(63, 23);
            this.textBox21.TabIndex = 19;
            this.textBox21.Text = "龙骑";
            this.textBox21.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox22
            // 
            this.textBox22.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox22.Location = new System.Drawing.Point(3, 95);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(63, 23);
            this.textBox22.TabIndex = 20;
            this.textBox22.Text = "诗人";
            this.textBox22.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox23
            // 
            this.textBox23.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox23.Location = new System.Drawing.Point(3, 116);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(63, 23);
            this.textBox23.TabIndex = 21;
            this.textBox23.Text = "召唤";
            this.textBox23.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox24
            // 
            this.textBox24.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox24.Location = new System.Drawing.Point(3, 137);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(63, 23);
            this.textBox24.TabIndex = 22;
            this.textBox24.Text = "学者";
            this.textBox24.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // textBox25
            // 
            this.textBox25.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox25.Location = new System.Drawing.Point(3, 158);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(63, 23);
            this.textBox25.TabIndex = 23;
            this.textBox25.Text = "白魔";
            this.textBox25.TextChanged += new System.EventHandler(this.updateTSS);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(227, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 35;
            this.label17.Text = "别称";
            // 
            // BahaPriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.logsTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.panel1);
            this.Name = "BahaPriority";
            this.Size = new System.Drawing.Size(1082, 455);
            this.Load += new System.EventHandler(this.BahaPriority_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void updatePlayerIndex(object sender, EventArgs e)
		{
			RadioButton[] array = panel1.Controls.OfType<RadioButton>().ToArray();
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (array[num].Checked)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			yourIndex = num;
		}

		public BahaPriority()
		{
			InitializeComponent();
		}

		public unsafe void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			lblStatus = pluginStatusText;
			pluginScreenSpace.Controls.Add(this);
			Dock = DockStyle.Fill;
			xmlSettings = new SettingsSerializer((object)this);
			LoadSettings();
            //ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate((object)this, (IntPtr)(void*));
            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;
            lblStatus.Text = "Plugin Started";
		}

		private int gowhere(bool[] b, int idx)
		{
			int result = -1;
			if (b[idx])
			{
				switch (idx)
				{
				case 1:
					result = (b[7] ? ((b[2] || b[8] || b[3]) ? 1 : 2) : 0);
					break;
				case 2:
					result = ((!b[8]) ? 2 : ((b[1] || b[7] || b[4]) ? 1 : 0));
					break;
				case 3:
					result = ((!b[2] && !b[8]) ? 2 : ((!b[5] && !b[6]) ? 1 : 0));
					break;
				case 4:
					result = ((b[1] || b[7]) ? ((!b[5] && !b[6]) ? 1 : 2) : 0);
					break;
				case 5:
					result = ((!b[6]) ? 1 : ((!b[2] && !b[8] && !b[3]) ? 2 : 0));
					break;
				case 6:
					result = 1;
					break;
				case 7:
					result = 0;
					break;
				case 8:
					result = 2;
					break;
				}
			}
			else
			{
				switch (idx)
				{
				case 1:
					result = ((!b[7]) ? (-1) : 0);
					break;
				case 2:
					result = (b[8] ? 2 : (-1));
					break;
				case 3:
					result = ((b[5] && b[6]) ? 1 : ((b[2] && b[8]) ? 2 : (-1)));
					break;
				case 4:
					result = ((b[5] && b[6] && b[3]) ? 1 : ((!b[1] || !b[7]) ? (-1) : 0));
					break;
				case 5:
					result = ((!b[2] || !b[8] || !b[3]) ? 1 : 2);
					break;
				case 6:
					result = ((!b[1] || !b[7] || !b[4]) ? ((b[5] || (b[2] && b[8] && b[3])) ? 1 : (-1)) : 0);
					break;
				case 7:
					result = 0;
					break;
				case 8:
					result = 2;
					break;
				}
			}
			return result;
		}

		private void BahaPriorityRun(string logLine)
		{
			if (Regex.Match(logLine, "バハムート・プライムは「エクサフレア」の構え|Bahamut Prime starts using Exaflare", RegexOptions.IgnoreCase).Success)
			{
				TextBox textBox = logsTextBox;
				textBox.Text = textBox.Text + "\r\n" + logLine;
				if (enabled_tts_exaflare)
				{
					new Exaflare().StartExaflareWatcher(mode_exaflare);
				}
			}
			else
			{
				if (!enabled_tts_ball1 && !enabled_tts_ball2 && !enabled_tts_shake && !enabled_key_ball2 && !enabled_key_shake)
				{
					return;
				}
				if (Regex.Match(logLine, "戦闘開始！|Engage", RegexOptions.IgnoreCase).Success)
				{
					lianji = false;
					qunlong = false;
					TextBox textBox2 = logsTextBox;
					textBox2.Text = textBox2.Text + "\r\n" + logLine;
					return;
				}
				if (Regex.Match(logLine, "バハムート・プライムは「連撃の三重奏」の構え|Bahamut Prime starts using Tenstrike Trio", RegexOptions.IgnoreCase).Success)
				{
					lianji = true;
					ballCount = 0;
					shakeCount = 0;
					ballChance = 1;
					shakeChance = ((!enabled_key_shake2) ? 1 : 2);
                    playerJob_ball1.Clear();
                    isBlackBallFirstRun = true;
					selectedPlayers_ball.Clear();
					selectedPlayers_shake.Clear();
					TextBox textBox3 = logsTextBox;
					textBox3.Text = textBox3.Text + "\r\n" + logLine;
					return;
				}
				if (Regex.Match(logLine, "バハムート・プライムは「群竜の八重奏」の構え|Bahamut Prime starts using Grand Octet", RegexOptions.IgnoreCase).Success)
				{
					lianji = false;
					qunlong = true;
					diveChance = 1;
                    shareChance = 1;
                    shareCount = 0;
					selectedPlayers_dive.Clear();
                    selectedPlayers_Megaflare_share.Clear();
					TextBox textBox4 = logsTextBox;
					textBox4.Text = textBox4.Text + "\r\n" + logLine;
                    if (Convert.ToBoolean(checkBox_Commander.CheckState))
                        new GrandOctetNavigation().StartGrandOctetWatcher();
					return;
				}
				Match match = Regex.Match(logLine, regex_ball, RegexOptions.IgnoreCase);
				Match match2 = Regex.Match(logLine, regex_shake, RegexOptions.IgnoreCase);
				Match match3 = Regex.Match(logLine, regex_dive_other, RegexOptions.IgnoreCase);
                Match match_megaflare_share = Regex.Match(logLine, regex_megaflare_share, RegexOptions.IgnoreCase);
				if ((!lianji || (!match.Success && !match2.Success)) && (!qunlong || (!match3.Success) && !match_megaflare_share.Success))
				{
					return;
				}
				TextBox textBox5 = logsTextBox;
				textBox5.Text = textBox5.Text + "\r\n" + logLine;
				if (lianji && match.Success && ballChance > 0)
				{
					ballCount++;
					for (int i = 0; i < players.Count; i++)
					{
						if (logLine.Contains(players[i]))
						{
							selectedPlayers_ball.Add(players[i]);
						}
					}
				}
				if (lianji && match2.Success && shakeChance > 0)
				{
					shakeCount++;
					for (int j = 0; j < players.Count; j++)
					{
						if (logLine.Contains(players[j]))
						{
							selectedPlayers_shake.Add(players[j]);
						}
					}
				}
				if (qunlong && match3.Success && diveChance > 0)
				{
					for (int k = 0; k < players.Count; k++)
					{
						if (logLine.Contains(players[k]))
						{
							selectedPlayers_dive.Add(players[k]);
						}
					}
				}
                if (qunlong && match_megaflare_share.Success)
                {
                    shareCount++;
                    for (int ind = 0; ind < players.Count; ind++)
                    {
                        if (logLine.Contains(players[ind]))
                        {
                            selectedPlayers_Megaflare_share.Add(players[ind]);
                            logsTextBox.Text += "Add new Megaflare Share Damage Player";
                        }
                    }
                }
				List<string> list = new List<string>();
                List<string> listShare = new List<string>();
				if (lianji && ballCount == 3 && ballChance > 0)
				{
					ballChance--;
					if (ballCount != selectedPlayers_ball.Count)
					{
						logsTextBox.Text += "\r\n-[Incorrect name/s in priority list!]-";
						return;
					}
					bool[] array = new bool[10];
					for (int l = 0; l < players.Count; l++)
					{
						if (selectedPlayers_ball.Contains(players[l]))
						{
							array[l + 1] = true;
						}
					}
					int num = gowhere(array, yourIndex + 1);
                    // add tts for all 1st run blackball players
                    if (isBlackBallFirstRun && Convert.ToBoolean(checkBox_Commander.CheckState))
                    {
                        for (int index = 0; index < players.Count; index++)
                        {
                            if (array[index + 1] == true)
                                playerJob_ball1.Add(nicknames[index]+tts_ball1[gowhere(array, index+1)]);
                        }
                        if (playerJob_ball1.Count == selectedPlayers_ball.Count)
                        {
                            ActGlobals.oFormActMain.TTS(String.Join(", ", playerJob_ball1.ToArray()));
                            isBlackBallFirstRun = false;
                        }
                    }
                    //
					if (num != -1)
					{
						if (array[yourIndex + 1])
						{
							if (enabled_tts_ball1)
							{
								ActGlobals.oFormActMain.TTS(tts_ball1[num]);
							}
						}
						else if (enabled_tts_ball2)
						{
							ActGlobals.oFormActMain.TTS(tts_ball2[num]);
						}
					}
					if (enabled_key_ball2)
					{
						int[] array2 = new int[10];
						for (int m = 0; m < players.Count; m++)
						{
							if (!array[m + 1])
							{
								array2[m + 1] = gowhere(array, m + 1);
							}
							else
							{
								array2[m + 1] = -1;
							}
						}
						for (int n = 0; n < 3; n++)
						{
							for (int num2 = 0; num2 < players.Count; num2++)
							{
								if (array2[num2 + 1] == n)
								{
									list.Add(playerkeys[num2]);
									break;
								}
							}
						}
					}
				}
				if (lianji && shakeCount == 4 && shakeChance > 0)
				{
					shakeChance--;
					if (shakeCount != selectedPlayers_shake.Count)
					{
						logsTextBox.Text += "\r\n-[Incorrect name/s in priority list!]-";
						return;
					}
					int[] array3 = new int[8]
					{
						0,
						6,
						3,
						5,
						4,
						2,
						7,
						1
					};
					int num3 = 0;
					for (int num4 = 0; num4 < players.Count; num4++)
					{
						if (!selectedPlayers_shake.Contains(players[array3[num4]]))
						{
							continue;
						}
						if (players[array3[num4]] == players[yourIndex])
						{
							if (enabled_tts_shake)
							{
								ActGlobals.oFormActMain.TTS(tts_shake[num3]);
							}
							TextBox textBox6 = logsTextBox;
							textBox6.Text = textBox6.Text + "\r\n---[" + (array3[num4] + 1) + "]---[" + players[array3[num4]] + "]------>-----" + tts_shake[num3] + "---<--[YOU]";
						}
						else
						{
							TextBox textBox6 = logsTextBox;
							textBox6.Text = textBox6.Text + "\r\n---[" + (array3[num4] + 1) + "]---[" + players[array3[num4]] + "]------>-----" + tts_shake[num3] + "-------------";
						}
						if (enabled_key_shake)
						{
							list.Add(playerkeys[array3[num4]]);
						}
						num3++;
					}
					shakeCount = 0;
					selectedPlayers_shake.Clear();
				}
				if (qunlong && selectedPlayers_dive.Count == players.Count - 1 && diveChance > 0)
				{
					diveChance--;
					for (int num5 = 0; num5 < players.Count; num5++)
					{
						if (selectedPlayers_dive.Contains(players[num5]))
						{
							continue;
						}
						TextBox textBox7 = logsTextBox;
						textBox7.Text = textBox7.Text + "\r\n双塔俯冲：" + players[num5];
						if (enabled_key_shuangta)
						{
							list.Add(playerkeys[num5]);
						}
						if (enabled_tts_shuangta)
						{
							if (players[num5] == players[yourIndex])
							{
								ActGlobals.oFormActMain.TTS("双塔自己引导");
							}
							else if (mode_shuangta)
							{
								ActGlobals.oFormActMain.TTS("双塔" + nicknames[num5]);
							}
							else
							{
								ActGlobals.oFormActMain.TTS("双塔" + players[num5]);
							}
						}
					}
				}
                if (qunlong && selectedPlayers_Megaflare_share.Count == 4 && shareChance > 0)
                {
                    shareChance--;
                    for (int ind = 0; ind < players.Count; ind++)
                    {
                        if (selectedPlayers_Megaflare_share.Contains(players[ind]))
                        {
                            continue; //Skip current loop
                        }
                        if (Convert.ToBoolean(checkBox_Commander.CheckState))
                        {
                            listShare.Add(playerkeys[ind]);
                            logsTextBox.Text += "\r\n 不分伤:" + players[ind];
                        }
                    }

                }
				if (list.Count > 0)
				{
					new KeyManager(list, clearTime).start();
				}
                if (listShare.Count > 0){
                    new KeyManager(listShare, clearTime + 6000).start();
                }
			}
		}

		private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			BahaPriorityRun(logInfo.logLine);
		}

		public unsafe void DeInitPlugin()
		{
            //IL_000c: Unknown result type (might be due to invalid IL or missing references)
            //IL_0016: Expected O, but got Unknown
            //ActGlobals.oFormActMain.OnLogLineRead -= new LogLineEventDelegate((object)this, (IntPtr)(void*)/*OpCode not supported: LdFtn*/);
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            SaveSettings();
			lblStatus.Text = "Plugin Exited";
		}

		private void LoadSettings()
		{
			if (File.Exists(settingsFile))
			{
				XmlTextReader xmlTextReader = new XmlTextReader(new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
				TextBox[] array = panel1.Controls.OfType<TextBox>().ToArray();
				TextBox[] array2 = panel2.Controls.OfType<TextBox>().ToArray();
				TextBox[] array3 = panel4.Controls.OfType<TextBox>().ToArray();
				TextBox[] array4 = panel3.Controls.OfType<TextBox>().ToArray();
				TextBox[] array5 = panel5.Controls.OfType<TextBox>().ToArray();
				TextBox[] array6 = panel7.Controls.OfType<TextBox>().ToArray();
				try
				{
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					while (xmlTextReader.Read())
					{
						if (xmlTextReader.NodeType == XmlNodeType.Element)
						{
							if (xmlTextReader.LocalName == "You")
							{
								yourIndex = xmlTextReader.ReadElementContentAsInt();
								panel1.Controls.OfType<RadioButton>().ToArray()[yourIndex].Checked = true;
							}
							if (xmlTextReader.Name == "Player")
							{
								string text = xmlTextReader.ReadElementContentAsString();
								players.Add(text);
								array[num].Text = text;
								num++;
							}
							if (xmlTextReader.Name == "TTS_Ball1")
							{
								string text2 = xmlTextReader.ReadElementContentAsString();
								tts_ball1.Add(text2);
								array2[num2].Text = text2;
								num2++;
							}
							if (xmlTextReader.Name == "TTS_Ball2")
							{
								string text3 = xmlTextReader.ReadElementContentAsString();
								tts_ball2.Add(text3);
								array3[num3].Text = text3;
								num3++;
							}
							if (xmlTextReader.Name == "TTS_Shake")
							{
								string text4 = xmlTextReader.ReadElementContentAsString();
								tts_shake.Add(text4);
								array4[num4].Text = text4;
								num4++;
							}
							if (xmlTextReader.Name == "Player_Num")
							{
								string text5 = xmlTextReader.ReadElementContentAsString();
								playerkeys.Add(text5);
								array5[num5].Text = text5;
								num5++;
							}
							if (xmlTextReader.Name == "Nick_Name")
							{
								string text6 = xmlTextReader.ReadElementContentAsString();
								nicknames.Add(text6);
								array6[num6].Text = text6;
								num6++;
							}
							if (xmlTextReader.Name == "enabled_tts_ball1")
							{
								string value = xmlTextReader.ReadElementContentAsString();
								enabled_tts_ball1 = Convert.ToBoolean(value);
								checkBox1.Checked = enabled_tts_ball1;
							}
							if (xmlTextReader.Name == "enabled_tts_ball2")
							{
								string value2 = xmlTextReader.ReadElementContentAsString();
								enabled_tts_ball2 = Convert.ToBoolean(value2);
								checkBox2.Checked = enabled_tts_ball2;
							}
							if (xmlTextReader.Name == "enabled_tts_shake")
							{
								string value3 = xmlTextReader.ReadElementContentAsString();
								enabled_tts_shake = Convert.ToBoolean(value3);
								checkBox3.Checked = enabled_tts_shake;
							}
							if (xmlTextReader.Name == "enabled_key_ball2")
							{
								string value4 = xmlTextReader.ReadElementContentAsString();
								enabled_key_ball2 = Convert.ToBoolean(value4);
								checkBox4.Checked = enabled_key_ball2;
							}
							if (xmlTextReader.Name == "enabled_key_shake")
							{
								string value5 = xmlTextReader.ReadElementContentAsString();
								enabled_key_shake = Convert.ToBoolean(value5);
								checkBox5.Checked = enabled_key_shake;
							}
							if (xmlTextReader.Name == "enabled_tts_shuangta")
							{
								string value6 = xmlTextReader.ReadElementContentAsString();
								enabled_tts_shuangta = Convert.ToBoolean(value6);
								checkBox6.Checked = enabled_tts_shuangta;
							}
							if (xmlTextReader.Name == "enabled_key_shuangta")
							{
								string value7 = xmlTextReader.ReadElementContentAsString();
								enabled_key_shuangta = Convert.ToBoolean(value7);
								checkBox7.Checked = enabled_key_shuangta;
							}
							if (xmlTextReader.Name == "enabled_key_shake2")
							{
								string value8 = xmlTextReader.ReadElementContentAsString();
								enabled_key_shake2 = Convert.ToBoolean(value8);
								checkBox8.Checked = enabled_key_shake2;
							}
							if (xmlTextReader.Name == "enabled_tts_exaflare")
							{
								string value9 = xmlTextReader.ReadElementContentAsString();
								enabled_tts_exaflare = Convert.ToBoolean(value9);
								checkBox10.Checked = enabled_tts_exaflare;
							}
                            if (xmlTextReader.Name == "enabled_commander_mode")
                            {
                                checkBox_Commander.Checked = Convert.ToBoolean(xmlTextReader.ReadElementContentAsString());
                            }
							if (xmlTextReader.Name == "mode_shuangta")
							{
								string value10 = xmlTextReader.ReadElementContentAsString();
								mode_shuangta = Convert.ToBoolean(value10);
								checkBox9.Checked = mode_shuangta;
							}
							if (xmlTextReader.Name == "mode_exaflare")
							{
								string value11 = xmlTextReader.ReadElementContentAsString();
								mode_exaflare = Convert.ToBoolean(value11);
								checkBox11.Checked = mode_exaflare;
							}
							if (xmlTextReader.Name == "clearTime")
							{
								string text7 = xmlTextReader.ReadElementContentAsString();
								int.TryParse(text7, out clearTime);
								textBox17.Text = text7;
							}
						}
					}
				}
				catch (Exception ex)
				{
					lblStatus.Text = "Error loading settings: " + ex.Message;
				}
				xmlTextReader.Close();
			}
			else
			{
				updateTSS();
			}
		}

		private void SaveSettings()
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite), Encoding.UTF8);
			TextBox[] array = panel1.Controls.OfType<TextBox>().ToArray();
			TextBox[] array2 = panel2.Controls.OfType<TextBox>().ToArray();
			TextBox[] array3 = panel4.Controls.OfType<TextBox>().ToArray();
			TextBox[] array4 = panel3.Controls.OfType<TextBox>().ToArray();
			TextBox[] array5 = panel5.Controls.OfType<TextBox>().ToArray();
			TextBox[] array6 = panel7.Controls.OfType<TextBox>().ToArray();
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.Indentation = 1;
			xmlTextWriter.IndentChar = '\t';
			xmlTextWriter.WriteStartDocument(standalone: true);
			xmlTextWriter.WriteStartElement("Config");
			xmlTextWriter.WriteStartElement("You");
			xmlTextWriter.WriteValue(yourIndex);
			xmlTextWriter.WriteEndElement();
			for (int i = 0; i < array.Length; i++)
			{
				xmlTextWriter.WriteStartElement("Player");
				xmlTextWriter.WriteValue(array[i].Text);
				xmlTextWriter.WriteEndElement();
			}
			for (int j = 0; j < array2.Length; j++)
			{
				xmlTextWriter.WriteStartElement("TTS_Ball1");
				xmlTextWriter.WriteValue(array2[j].Text);
				xmlTextWriter.WriteEndElement();
			}
			for (int k = 0; k < array3.Length; k++)
			{
				xmlTextWriter.WriteStartElement("TTS_Ball2");
				xmlTextWriter.WriteValue(array3[k].Text);
				xmlTextWriter.WriteEndElement();
			}
			for (int l = 0; l < array4.Length; l++)
			{
				xmlTextWriter.WriteStartElement("TTS_Shake");
				xmlTextWriter.WriteValue(array4[l].Text);
				xmlTextWriter.WriteEndElement();
			}
			for (int m = 0; m < array5.Length; m++)
			{
				xmlTextWriter.WriteStartElement("Player_Num");
				xmlTextWriter.WriteValue(array5[m].Text);
				xmlTextWriter.WriteEndElement();
			}
			for (int n = 0; n < array6.Length; n++)
			{
				xmlTextWriter.WriteStartElement("Nick_Name");
				xmlTextWriter.WriteValue(array6[n].Text);
				xmlTextWriter.WriteEndElement();
			}
			xmlTextWriter.WriteStartElement("enabled_tts_ball1");
			xmlTextWriter.WriteValue(checkBox1.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_tts_ball2");
			xmlTextWriter.WriteValue(checkBox2.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_tts_shake");
			xmlTextWriter.WriteValue(checkBox3.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_key_ball2");
			xmlTextWriter.WriteValue(checkBox4.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_key_shake");
			xmlTextWriter.WriteValue(checkBox5.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_tts_shuangta");
			xmlTextWriter.WriteValue(checkBox6.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_key_shuangta");
			xmlTextWriter.WriteValue(checkBox7.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_key_shake2");
			xmlTextWriter.WriteValue(checkBox8.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("enabled_tts_exaflare");
			xmlTextWriter.WriteValue(checkBox10.Checked.ToString());
			xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteStartElement("enabled_commander_mode");
            xmlTextWriter.WriteValue(checkBox_Commander.Checked.ToString());
            xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("mode_exaflare");
			xmlTextWriter.WriteValue(checkBox11.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("mode_shuangta");
			xmlTextWriter.WriteValue(checkBox9.Checked.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("clearTime");
			xmlTextWriter.WriteValue(textBox17.Text);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
		}

		private void updatePlayers(object sender, EventArgs e)
		{
			players.Clear();
			TextBox[] array = panel1.Controls.OfType<TextBox>().ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				players.Add(array[i].Text);
			}
		}

		private void updateTSS(object sender, EventArgs e)
		{
			updateTSS();
		}

		private void updateTSS()
		{
			tts_ball1.Clear();
			TextBox[] array = panel2.Controls.OfType<TextBox>().ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				tts_ball1.Add(array[i].Text);
			}
			tts_ball2.Clear();
			TextBox[] array2 = panel4.Controls.OfType<TextBox>().ToArray();
			for (int j = 0; j < array2.Length; j++)
			{
				tts_ball2.Add(array2[j].Text);
			}
			tts_shake.Clear();
			TextBox[] array3 = panel3.Controls.OfType<TextBox>().ToArray();
			for (int k = 0; k < array3.Length; k++)
			{
				tts_shake.Add(array3[k].Text);
			}
			playerkeys.Clear();
			TextBox[] array4 = panel5.Controls.OfType<TextBox>().ToArray();
			for (int l = 0; l < players.Count; l++)
			{
				playerkeys.Add(array4[l].Text);
			}
			nicknames.Clear();
			TextBox[] array5 = panel7.Controls.OfType<TextBox>().ToArray();
			for (int m = 0; m < players.Count; m++)
			{
				nicknames.Add(array5[m].Text);
			}
			enabled_tts_ball1 = checkBox1.Checked;
			enabled_tts_ball2 = checkBox2.Checked;
			enabled_tts_shake = checkBox3.Checked;
			enabled_key_ball2 = checkBox4.Checked;
			enabled_key_shake = checkBox5.Checked;
			enabled_tts_shuangta = checkBox6.Checked;
			enabled_key_shuangta = checkBox7.Checked;
			enabled_key_shake2 = checkBox8.Checked;
			enabled_tts_exaflare = checkBox10.Checked;
			mode_exaflare = checkBox11.Checked;
			mode_shuangta = checkBox9.Checked;
			int.TryParse(textBox17.Text, out clearTime);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			List<int> source = new List<int>
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7
			};
			source = (from x in source
			orderby Guid.NewGuid()
			select x).ToList();
			BahaPriorityRun("戦闘開始！");
			BahaPriorityRun("バハムート・プライムは「連撃の三重奏」の構え");
			for (int i = 0; i < 3; i++)
			{
				BahaPriorityRun("1B:" + players[source[i]] + ":测试:0000:测试:0076:0000:0000:0000:");
			}
			BahaPriorityRun("バハムート・プライムは「群竜の八重奏」の構え");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			List<int> source = new List<int>
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7
			};
			source = (from x in source
			orderby Guid.NewGuid()
			select x).ToList();
			BahaPriorityRun("戦闘開始！");
			BahaPriorityRun("バハムート・プライムは「連撃の三重奏」の構え");
			for (int i = 0; i < 4; i++)
			{
				BahaPriorityRun("1B:" + players[source[i]] + ":测试:0000:0000:0028:0000:0000:0000:");
			}
			BahaPriorityRun("バハムート・プライムは「群竜の八重奏」の構え");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			List<int> source = new List<int>
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7
			};
			source = (from x in source
			orderby Guid.NewGuid()
			select x).ToList();
			BahaPriorityRun("戦闘開始！");
			BahaPriorityRun("バハムート・プライムは「連撃の三重奏」の構え");
			BahaPriorityRun("バハムート・プライムは「群竜の八重奏」の構え");
			for (int i = 0; i < 7; i++)
			{
				BahaPriorityRun("1B:测试:" + players[source[i]] + ":0000:测试:0014:0000:0000:0000:");
			}
		}

        private void BahaPriority_Load(object sender, EventArgs e)
        {

        }

        private void CheckBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InstructionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
