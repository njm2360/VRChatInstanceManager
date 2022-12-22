namespace learn_csharp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.authToken = new System.Windows.Forms.TextBox();
            this.webSocketLog = new System.Windows.Forms.TextBox();
            this.wsConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.targetInstanceId = new System.Windows.Forms.TextBox();
            this.instanceManagerLog = new System.Windows.Forms.TextBox();
            this.staffOnlyMode = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.instaceFullWaitList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inWorldList = new System.Windows.Forms.ListBox();
            this.inviteWaitList = new System.Windows.Forms.ListBox();
            this.allowUserList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maxGuestUser = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maxGuestUser)).BeginInit();
            this.SuspendLayout();
            // 
            // authToken
            // 
            this.authToken.Location = new System.Drawing.Point(108, 13);
            this.authToken.Name = "authToken";
            this.authToken.Size = new System.Drawing.Size(171, 23);
            this.authToken.TabIndex = 2;
            // 
            // webSocketLog
            // 
            this.webSocketLog.Location = new System.Drawing.Point(379, 401);
            this.webSocketLog.Multiline = true;
            this.webSocketLog.Name = "webSocketLog";
            this.webSocketLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.webSocketLog.Size = new System.Drawing.Size(409, 152);
            this.webSocketLog.TabIndex = 3;
            // 
            // wsConnect
            // 
            this.wsConnect.Location = new System.Drawing.Point(285, 12);
            this.wsConnect.Name = "wsConnect";
            this.wsConnect.Size = new System.Drawing.Size(75, 23);
            this.wsConnect.TabIndex = 4;
            this.wsConnect.Text = "接続";
            this.wsConnect.UseVisualStyleBackColor = true;
            this.wsConnect.Click += new System.EventHandler(this.wsConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "AuthToken";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "TargetInsanceID";
            // 
            // targetInstanceId
            // 
            this.targetInstanceId.Location = new System.Drawing.Point(108, 39);
            this.targetInstanceId.Name = "targetInstanceId";
            this.targetInstanceId.Size = new System.Drawing.Size(252, 23);
            this.targetInstanceId.TabIndex = 7;
            // 
            // instanceManagerLog
            // 
            this.instanceManagerLog.Location = new System.Drawing.Point(379, 42);
            this.instanceManagerLog.Multiline = true;
            this.instanceManagerLog.Name = "instanceManagerLog";
            this.instanceManagerLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instanceManagerLog.Size = new System.Drawing.Size(409, 323);
            this.instanceManagerLog.TabIndex = 8;
            // 
            // staffOnlyMode
            // 
            this.staffOnlyMode.AutoSize = true;
            this.staffOnlyMode.Location = new System.Drawing.Point(12, 74);
            this.staffOnlyMode.Name = "staffOnlyMode";
            this.staffOnlyMode.Size = new System.Drawing.Size(78, 19);
            this.staffOnlyMode.TabIndex = 9;
            this.staffOnlyMode.Text = "Staff Only";
            this.staffOnlyMode.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "インスタンス空き待ちリスト";
            // 
            // instaceFullWaitList
            // 
            this.instaceFullWaitList.FormattingEnabled = true;
            this.instaceFullWaitList.ItemHeight = 15;
            this.instaceFullWaitList.Location = new System.Drawing.Point(12, 229);
            this.instaceFullWaitList.Name = "instaceFullWaitList";
            this.instaceFullWaitList.Size = new System.Drawing.Size(350, 94);
            this.instaceFullWaitList.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 441);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "ワールド内リスト";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "インバイト待ちリスト";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "スタッフリスト";
            // 
            // inWorldList
            // 
            this.inWorldList.FormattingEnabled = true;
            this.inWorldList.ItemHeight = 15;
            this.inWorldList.Location = new System.Drawing.Point(12, 459);
            this.inWorldList.Name = "inWorldList";
            this.inWorldList.Size = new System.Drawing.Size(350, 94);
            this.inWorldList.TabIndex = 18;
            // 
            // inviteWaitList
            // 
            this.inviteWaitList.FormattingEnabled = true;
            this.inviteWaitList.ItemHeight = 15;
            this.inviteWaitList.Location = new System.Drawing.Point(12, 344);
            this.inviteWaitList.Name = "inviteWaitList";
            this.inviteWaitList.Size = new System.Drawing.Size(350, 94);
            this.inviteWaitList.TabIndex = 17;
            // 
            // allowUserList
            // 
            this.allowUserList.FormattingEnabled = true;
            this.allowUserList.ItemHeight = 15;
            this.allowUserList.Location = new System.Drawing.Point(12, 114);
            this.allowUserList.Name = "allowUserList";
            this.allowUserList.Size = new System.Drawing.Size(350, 94);
            this.allowUserList.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "最大人数";
            // 
            // maxGuestUser
            // 
            this.maxGuestUser.Location = new System.Drawing.Point(278, 72);
            this.maxGuestUser.Name = "maxGuestUser";
            this.maxGuestUser.Size = new System.Drawing.Size(50, 23);
            this.maxGuestUser.TabIndex = 24;
            this.maxGuestUser.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "インスタンスログ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "WebSocket";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maxGuestUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.instaceFullWaitList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inWorldList);
            this.Controls.Add(this.inviteWaitList);
            this.Controls.Add(this.allowUserList);
            this.Controls.Add(this.staffOnlyMode);
            this.Controls.Add(this.instanceManagerLog);
            this.Controls.Add(this.targetInstanceId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wsConnect);
            this.Controls.Add(this.webSocketLog);
            this.Controls.Add(this.authToken);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxGuestUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox authToken;
        public TextBox webSocketLog;
        private Button wsConnect;
        private Label label1;
        private Label label2;
        private TextBox targetInstanceId;
        public TextBox instanceManagerLog;
        private CheckBox staffOnlyMode;
        private Label label6;
        private ListBox instaceFullWaitList;
        private Label label5;
        private Label label4;
        private Label label3;
        private ListBox inWorldList;
        private ListBox inviteWaitList;
        public ListBox allowUserList;
        private Label label7;
        private NumericUpDown maxGuestUser;
        private Label label8;
        private Label label9;
    }
}