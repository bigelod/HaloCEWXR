namespace XrAPITestUDP
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSendFrame = new Button();
            chkAutoSendUDP = new CheckBox();
            timSendInterval = new System.Windows.Forms.Timer(components);
            txtTargetIP = new TextBox();
            label1 = new Label();
            btnApplyIP = new Button();
            lblDataSending = new Label();
            txtSentData = new TextBox();
            chkAutoIncrementFrameId = new CheckBox();
            tbOXRFrameId = new TrackBar();
            lblOXRFrameId = new Label();
            btnCopyUDPData = new Button();
            timHideSendTxt = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            chkLGRIP = new CheckBox();
            label4 = new Label();
            chkLMENU = new CheckBox();
            chkLTRIGGER = new CheckBox();
            chkLTHUMBCLICK = new CheckBox();
            chkLTHUMBUP = new CheckBox();
            chkLTHUMBDOWN = new CheckBox();
            chkLTHUMBRIGHT = new CheckBox();
            chkLTHUMBLEFT = new CheckBox();
            chkLX = new CheckBox();
            chkLY = new CheckBox();
            chkRB = new CheckBox();
            chkRA = new CheckBox();
            chkRTHUMBRIGHT = new CheckBox();
            chkRTHUMBLEFT = new CheckBox();
            chkRTHUMBDOWN = new CheckBox();
            chkRTHUMBUP = new CheckBox();
            chkRTHUMBCLICK = new CheckBox();
            chkRTRIGGER = new CheckBox();
            chkRGRIP = new CheckBox();
            label6 = new Label();
            txtHMD = new TextBox();
            txtIPDFOV = new TextBox();
            label7 = new Label();
            tbRQX = new TrackBar();
            tbRQY = new TrackBar();
            tbRQZ = new TrackBar();
            tbRQW = new TrackBar();
            tbRTX = new TrackBar();
            tbRTY = new TrackBar();
            lblRTX = new Label();
            lblRTY = new Label();
            lblRQX = new Label();
            lblRQZ = new Label();
            lblRQY = new Label();
            lblRQW = new Label();
            lblLQW = new Label();
            lblLQY = new Label();
            lblLQZ = new Label();
            lblLQX = new Label();
            lblLTY = new Label();
            lblLTX = new Label();
            tbLTY = new TrackBar();
            tbLTX = new TrackBar();
            tbLQW = new TrackBar();
            tbLQZ = new TrackBar();
            tbLQY = new TrackBar();
            tbLQX = new TrackBar();
            txtLPos = new TextBox();
            label8 = new Label();
            label9 = new Label();
            txtRPos = new TextBox();
            label12 = new Label();
            txtHPos = new TextBox();
            lblHMDQW = new Label();
            lblHMDQY = new Label();
            lblHMDQZ = new Label();
            lblHMDQX = new Label();
            tbHQW = new TrackBar();
            tbHQZ = new TrackBar();
            tbHQY = new TrackBar();
            tbHQX = new TrackBar();
            chkZeroThumbs = new CheckBox();
            chkReleaseBtnOnMouseUp = new CheckBox();
            btnImportUDP = new Button();
            chkAlwaysOnTop = new CheckBox();
            chkReadKeys = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)tbOXRFrameId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbRQX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbRQY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbRQZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbRQW).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbRTX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbRTY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLTY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLTX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLQW).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLQZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLQY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLQX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbHQW).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbHQZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbHQY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbHQX).BeginInit();
            SuspendLayout();
            // 
            // btnSendFrame
            // 
            btnSendFrame.Location = new Point(572, 41);
            btnSendFrame.Name = "btnSendFrame";
            btnSendFrame.Size = new Size(191, 23);
            btnSendFrame.TabIndex = 0;
            btnSendFrame.Text = "Send Single UDP Frame";
            btnSendFrame.UseVisualStyleBackColor = true;
            btnSendFrame.Click += btnSendFrame_Click;
            // 
            // chkAutoSendUDP
            // 
            chkAutoSendUDP.AutoSize = true;
            chkAutoSendUDP.Location = new Point(1317, 172);
            chkAutoSendUDP.Name = "chkAutoSendUDP";
            chkAutoSendUDP.Size = new Size(179, 19);
            chkAutoSendUDP.TabIndex = 1;
            chkAutoSendUDP.Text = "Auto Send UDP Data (72 FPS)";
            chkAutoSendUDP.UseVisualStyleBackColor = true;
            chkAutoSendUDP.CheckedChanged += chkAutoSendUDP_CheckedChanged;
            // 
            // timSendInterval
            // 
            timSendInterval.Enabled = true;
            timSendInterval.Interval = 14;
            timSendInterval.Tick += timSendInterval_Tick;
            // 
            // txtTargetIP
            // 
            txtTargetIP.Location = new Point(73, 6);
            txtTargetIP.Name = "txtTargetIP";
            txtTargetIP.Size = new Size(100, 23);
            txtTargetIP.TabIndex = 2;
            txtTargetIP.Text = "localhost";
            txtTargetIP.TextChanged += txtTargetIP_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "Target IP:";
            // 
            // btnApplyIP
            // 
            btnApplyIP.Enabled = false;
            btnApplyIP.Location = new Point(179, 6);
            btnApplyIP.Name = "btnApplyIP";
            btnApplyIP.Size = new Size(56, 23);
            btnApplyIP.TabIndex = 4;
            btnApplyIP.Text = "Apply";
            btnApplyIP.UseVisualStyleBackColor = true;
            btnApplyIP.Click += btnApplyIP_Click;
            // 
            // lblDataSending
            // 
            lblDataSending.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblDataSending.Location = new Point(1193, 249);
            lblDataSending.Name = "lblDataSending";
            lblDataSending.RightToLeft = RightToLeft.Yes;
            lblDataSending.Size = new Size(303, 15);
            lblDataSending.TabIndex = 5;
            lblDataSending.Text = "SENDING DATA TO localhost";
            lblDataSending.Visible = false;
            // 
            // txtSentData
            // 
            txtSentData.Location = new Point(12, 245);
            txtSentData.Name = "txtSentData";
            txtSentData.ReadOnly = true;
            txtSentData.Size = new Size(1175, 23);
            txtSentData.TabIndex = 7;
            txtSentData.Text = resources.GetString("txtSentData.Text");
            // 
            // chkAutoIncrementFrameId
            // 
            chkAutoIncrementFrameId.AutoSize = true;
            chkAutoIncrementFrameId.Checked = true;
            chkAutoIncrementFrameId.CheckState = CheckState.Checked;
            chkAutoIncrementFrameId.Location = new Point(1166, 172);
            chkAutoIncrementFrameId.Name = "chkAutoIncrementFrameId";
            chkAutoIncrementFrameId.Size = new Size(145, 19);
            chkAutoIncrementFrameId.TabIndex = 8;
            chkAutoIncrementFrameId.Text = "Auto Increment Frame";
            chkAutoIncrementFrameId.UseVisualStyleBackColor = true;
            chkAutoIncrementFrameId.CheckedChanged += chkAutoIncrementFrameId_CheckedChanged;
            // 
            // tbOXRFrameId
            // 
            tbOXRFrameId.Location = new Point(872, 200);
            tbOXRFrameId.Maximum = 255;
            tbOXRFrameId.Name = "tbOXRFrameId";
            tbOXRFrameId.Size = new Size(624, 45);
            tbOXRFrameId.TabIndex = 9;
            tbOXRFrameId.Scroll += tbOXRFrameId_Scroll;
            // 
            // lblOXRFrameId
            // 
            lblOXRFrameId.AutoSize = true;
            lblOXRFrameId.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblOXRFrameId.Location = new Point(880, 173);
            lblOXRFrameId.Name = "lblOXRFrameId";
            lblOXRFrameId.Size = new Size(113, 15);
            lblOXRFrameId.TabIndex = 10;
            lblOXRFrameId.Text = "OpenXR Frame ID: 0";
            // 
            // btnCopyUDPData
            // 
            btnCopyUDPData.Location = new Point(769, 41);
            btnCopyUDPData.Name = "btnCopyUDPData";
            btnCopyUDPData.Size = new Size(84, 44);
            btnCopyUDPData.TabIndex = 11;
            btnCopyUDPData.Text = "Copy UDP Data";
            btnCopyUDPData.UseVisualStyleBackColor = true;
            btnCopyUDPData.Click += btnCopyUDPData_Click;
            // 
            // timHideSendTxt
            // 
            timHideSendTxt.Interval = 2000;
            timHideSendTxt.Tick += timHideSendTxt_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 10);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 12;
            label3.Text = "Target Port: 7872";
            // 
            // chkLGRIP
            // 
            chkLGRIP.AutoSize = true;
            chkLGRIP.Location = new Point(970, 91);
            chkLGRIP.Name = "chkLGRIP";
            chkLGRIP.Size = new Size(62, 19);
            chkLGRIP.TabIndex = 13;
            chkLGRIP.Text = "L_GRIP";
            chkLGRIP.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(902, 40);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 14;
            label4.Text = "Buttons:";
            // 
            // chkLMENU
            // 
            chkLMENU.AutoSize = true;
            chkLMENU.Location = new Point(970, 116);
            chkLMENU.Name = "chkLMENU";
            chkLMENU.Size = new Size(71, 19);
            chkLMENU.TabIndex = 16;
            chkLMENU.Text = "L_MENU";
            chkLMENU.UseVisualStyleBackColor = true;
            // 
            // chkLTRIGGER
            // 
            chkLTRIGGER.AutoSize = true;
            chkLTRIGGER.Location = new Point(970, 66);
            chkLTRIGGER.Name = "chkLTRIGGER";
            chkLTRIGGER.Size = new Size(82, 19);
            chkLTRIGGER.TabIndex = 17;
            chkLTRIGGER.Text = "L_TRIGGER";
            chkLTRIGGER.UseVisualStyleBackColor = true;
            // 
            // chkLTHUMBCLICK
            // 
            chkLTHUMBCLICK.AutoSize = true;
            chkLTHUMBCLICK.Location = new Point(970, 141);
            chkLTHUMBCLICK.Name = "chkLTHUMBCLICK";
            chkLTHUMBCLICK.Size = new Size(115, 19);
            chkLTHUMBCLICK.TabIndex = 18;
            chkLTHUMBCLICK.Text = "L_THUMB_CLICK";
            chkLTHUMBCLICK.UseVisualStyleBackColor = true;
            // 
            // chkLTHUMBUP
            // 
            chkLTHUMBUP.AutoSize = true;
            chkLTHUMBUP.Location = new Point(1102, 66);
            chkLTHUMBUP.Name = "chkLTHUMBUP";
            chkLTHUMBUP.Size = new Size(98, 19);
            chkLTHUMBUP.TabIndex = 19;
            chkLTHUMBUP.Text = "L_THUMB_UP";
            chkLTHUMBUP.UseVisualStyleBackColor = true;
            // 
            // chkLTHUMBDOWN
            // 
            chkLTHUMBDOWN.AutoSize = true;
            chkLTHUMBDOWN.Location = new Point(1102, 91);
            chkLTHUMBDOWN.Name = "chkLTHUMBDOWN";
            chkLTHUMBDOWN.Size = new Size(120, 19);
            chkLTHUMBDOWN.TabIndex = 20;
            chkLTHUMBDOWN.Text = "L_THUMB_DOWN";
            chkLTHUMBDOWN.UseVisualStyleBackColor = true;
            // 
            // chkLTHUMBRIGHT
            // 
            chkLTHUMBRIGHT.AutoSize = true;
            chkLTHUMBRIGHT.Location = new Point(1102, 141);
            chkLTHUMBRIGHT.Name = "chkLTHUMBRIGHT";
            chkLTHUMBRIGHT.Size = new Size(116, 19);
            chkLTHUMBRIGHT.TabIndex = 22;
            chkLTHUMBRIGHT.Text = "L_THUMB_RIGHT";
            chkLTHUMBRIGHT.UseVisualStyleBackColor = true;
            // 
            // chkLTHUMBLEFT
            // 
            chkLTHUMBLEFT.AutoSize = true;
            chkLTHUMBLEFT.Location = new Point(1102, 116);
            chkLTHUMBLEFT.Name = "chkLTHUMBLEFT";
            chkLTHUMBLEFT.Size = new Size(107, 19);
            chkLTHUMBLEFT.TabIndex = 21;
            chkLTHUMBLEFT.Text = "L_THUMB_LEFT";
            chkLTHUMBLEFT.UseVisualStyleBackColor = true;
            // 
            // chkLX
            // 
            chkLX.AutoSize = true;
            chkLX.Location = new Point(970, 41);
            chkLX.Name = "chkLX";
            chkLX.Size = new Size(44, 19);
            chkLX.TabIndex = 23;
            chkLX.Text = "L_X";
            chkLX.UseVisualStyleBackColor = true;
            // 
            // chkLY
            // 
            chkLY.AutoSize = true;
            chkLY.Location = new Point(1102, 41);
            chkLY.Name = "chkLY";
            chkLY.Size = new Size(44, 19);
            chkLY.TabIndex = 24;
            chkLY.Text = "L_Y";
            chkLY.UseVisualStyleBackColor = true;
            // 
            // chkRB
            // 
            chkRB.AutoSize = true;
            chkRB.Location = new Point(1367, 40);
            chkRB.Name = "chkRB";
            chkRB.Size = new Size(45, 19);
            chkRB.TabIndex = 34;
            chkRB.Text = "R_B";
            chkRB.UseVisualStyleBackColor = true;
            // 
            // chkRA
            // 
            chkRA.AutoSize = true;
            chkRA.Location = new Point(1238, 40);
            chkRA.Name = "chkRA";
            chkRA.Size = new Size(46, 19);
            chkRA.TabIndex = 33;
            chkRA.Text = "R_A";
            chkRA.UseVisualStyleBackColor = true;
            // 
            // chkRTHUMBRIGHT
            // 
            chkRTHUMBRIGHT.AutoSize = true;
            chkRTHUMBRIGHT.Location = new Point(1367, 140);
            chkRTHUMBRIGHT.Name = "chkRTHUMBRIGHT";
            chkRTHUMBRIGHT.Size = new Size(117, 19);
            chkRTHUMBRIGHT.TabIndex = 32;
            chkRTHUMBRIGHT.Text = "R_THUMB_RIGHT";
            chkRTHUMBRIGHT.UseVisualStyleBackColor = true;
            // 
            // chkRTHUMBLEFT
            // 
            chkRTHUMBLEFT.AutoSize = true;
            chkRTHUMBLEFT.Location = new Point(1367, 115);
            chkRTHUMBLEFT.Name = "chkRTHUMBLEFT";
            chkRTHUMBLEFT.Size = new Size(108, 19);
            chkRTHUMBLEFT.TabIndex = 31;
            chkRTHUMBLEFT.Text = "R_THUMB_LEFT";
            chkRTHUMBLEFT.UseVisualStyleBackColor = true;
            // 
            // chkRTHUMBDOWN
            // 
            chkRTHUMBDOWN.AutoSize = true;
            chkRTHUMBDOWN.Location = new Point(1367, 90);
            chkRTHUMBDOWN.Name = "chkRTHUMBDOWN";
            chkRTHUMBDOWN.Size = new Size(121, 19);
            chkRTHUMBDOWN.TabIndex = 30;
            chkRTHUMBDOWN.Text = "R_THUMB_DOWN";
            chkRTHUMBDOWN.UseVisualStyleBackColor = true;
            // 
            // chkRTHUMBUP
            // 
            chkRTHUMBUP.AutoSize = true;
            chkRTHUMBUP.Location = new Point(1367, 65);
            chkRTHUMBUP.Name = "chkRTHUMBUP";
            chkRTHUMBUP.Size = new Size(99, 19);
            chkRTHUMBUP.TabIndex = 29;
            chkRTHUMBUP.Text = "R_THUMB_UP";
            chkRTHUMBUP.UseVisualStyleBackColor = true;
            // 
            // chkRTHUMBCLICK
            // 
            chkRTHUMBCLICK.AutoSize = true;
            chkRTHUMBCLICK.Location = new Point(1238, 140);
            chkRTHUMBCLICK.Name = "chkRTHUMBCLICK";
            chkRTHUMBCLICK.Size = new Size(116, 19);
            chkRTHUMBCLICK.TabIndex = 28;
            chkRTHUMBCLICK.Text = "R_THUMB_CLICK";
            chkRTHUMBCLICK.UseVisualStyleBackColor = true;
            // 
            // chkRTRIGGER
            // 
            chkRTRIGGER.AutoSize = true;
            chkRTRIGGER.Location = new Point(1238, 65);
            chkRTRIGGER.Name = "chkRTRIGGER";
            chkRTRIGGER.Size = new Size(83, 19);
            chkRTRIGGER.TabIndex = 27;
            chkRTRIGGER.Text = "R_TRIGGER";
            chkRTRIGGER.UseVisualStyleBackColor = true;
            // 
            // chkRGRIP
            // 
            chkRGRIP.AutoSize = true;
            chkRGRIP.Location = new Point(1238, 90);
            chkRGRIP.Name = "chkRGRIP";
            chkRGRIP.Size = new Size(63, 19);
            chkRGRIP.TabIndex = 25;
            chkRGRIP.Text = "R_GRIP";
            chkRGRIP.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1036, 10);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 36;
            label6.Text = "HMD:";
            // 
            // txtHMD
            // 
            txtHMD.Location = new Point(1080, 7);
            txtHMD.Name = "txtHMD";
            txtHMD.Size = new Size(87, 23);
            txtHMD.TabIndex = 35;
            txtHMD.Text = "META";
            // 
            // txtIPDFOV
            // 
            txtIPDFOV.Location = new Point(1347, 7);
            txtIPDFOV.Name = "txtIPDFOV";
            txtIPDFOV.Size = new Size(150, 23);
            txtIPDFOV.TabIndex = 38;
            txtIPDFOV.Text = "0.0678 99.00 103.40";
            txtIPDFOV.TextChanged += txtIPDFOV_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1173, 10);
            label7.Name = "label7";
            label7.Size = new Size(168, 15);
            label7.TabIndex = 39;
            label7.Text = "IPD / FOV Horizontal / Vertical:";
            // 
            // tbRQX
            // 
            tbRQX.Location = new Point(304, 128);
            tbRQX.Maximum = 100;
            tbRQX.Minimum = -100;
            tbRQX.Name = "tbRQX";
            tbRQX.Size = new Size(125, 45);
            tbRQX.TabIndex = 40;
            // 
            // tbRQY
            // 
            tbRQY.Location = new Point(441, 128);
            tbRQY.Maximum = 100;
            tbRQY.Minimum = -100;
            tbRQY.Name = "tbRQY";
            tbRQY.Size = new Size(125, 45);
            tbRQY.TabIndex = 41;
            // 
            // tbRQZ
            // 
            tbRQZ.Location = new Point(302, 194);
            tbRQZ.Maximum = 100;
            tbRQZ.Minimum = -100;
            tbRQZ.Name = "tbRQZ";
            tbRQZ.Size = new Size(125, 45);
            tbRQZ.TabIndex = 42;
            // 
            // tbRQW
            // 
            tbRQW.Location = new Point(441, 194);
            tbRQW.Maximum = 100;
            tbRQW.Minimum = -100;
            tbRQW.Name = "tbRQW";
            tbRQW.Size = new Size(125, 45);
            tbRQW.TabIndex = 43;
            // 
            // tbRTX
            // 
            tbRTX.Location = new Point(304, 62);
            tbRTX.Maximum = 100;
            tbRTX.Minimum = -100;
            tbRTX.Name = "tbRTX";
            tbRTX.Size = new Size(125, 45);
            tbRTX.TabIndex = 44;
            // 
            // tbRTY
            // 
            tbRTY.Location = new Point(441, 62);
            tbRTY.Maximum = 100;
            tbRTY.Minimum = -100;
            tbRTY.Name = "tbRTY";
            tbRTY.Size = new Size(125, 45);
            tbRTY.TabIndex = 53;
            // 
            // lblRTX
            // 
            lblRTX.AutoSize = true;
            lblRTX.Location = new Point(304, 44);
            lblRTX.Name = "lblRTX";
            lblRTX.Size = new Size(92, 15);
            lblRTX.TabIndex = 56;
            lblRTX.Text = "R Thumbstick X:";
            // 
            // lblRTY
            // 
            lblRTY.AutoSize = true;
            lblRTY.Location = new Point(441, 44);
            lblRTY.Name = "lblRTY";
            lblRTY.Size = new Size(92, 15);
            lblRTY.TabIndex = 57;
            lblRTY.Text = "R Thumbstick Y:";
            // 
            // lblRQX
            // 
            lblRQX.AutoSize = true;
            lblRQX.Location = new Point(304, 110);
            lblRQX.Name = "lblRQX";
            lblRQX.Size = new Size(90, 15);
            lblRQX.TabIndex = 60;
            lblRQX.Text = "R Quaternion X:";
            // 
            // lblRQZ
            // 
            lblRQZ.AutoSize = true;
            lblRQZ.Location = new Point(304, 176);
            lblRQZ.Name = "lblRQZ";
            lblRQZ.Size = new Size(90, 15);
            lblRQZ.TabIndex = 61;
            lblRQZ.Text = "R Quaternion Z:";
            // 
            // lblRQY
            // 
            lblRQY.AutoSize = true;
            lblRQY.Location = new Point(441, 110);
            lblRQY.Name = "lblRQY";
            lblRQY.Size = new Size(90, 15);
            lblRQY.TabIndex = 62;
            lblRQY.Text = "R Quaternion Y:";
            // 
            // lblRQW
            // 
            lblRQW.AutoSize = true;
            lblRQW.Location = new Point(441, 176);
            lblRQW.Name = "lblRQW";
            lblRQW.Size = new Size(94, 15);
            lblRQW.TabIndex = 63;
            lblRQW.Text = "R Quaternion W:";
            // 
            // lblLQW
            // 
            lblLQW.AutoSize = true;
            lblLQW.Location = new Point(149, 176);
            lblLQW.Name = "lblLQW";
            lblLQW.Size = new Size(93, 15);
            lblLQW.TabIndex = 75;
            lblLQW.Text = "L Quaternion W:";
            // 
            // lblLQY
            // 
            lblLQY.AutoSize = true;
            lblLQY.Location = new Point(149, 110);
            lblLQY.Name = "lblLQY";
            lblLQY.Size = new Size(89, 15);
            lblLQY.TabIndex = 74;
            lblLQY.Text = "L Quaternion Y:";
            // 
            // lblLQZ
            // 
            lblLQZ.AutoSize = true;
            lblLQZ.Location = new Point(12, 176);
            lblLQZ.Name = "lblLQZ";
            lblLQZ.Size = new Size(89, 15);
            lblLQZ.TabIndex = 73;
            lblLQZ.Text = "L Quaternion Z:";
            // 
            // lblLQX
            // 
            lblLQX.AutoSize = true;
            lblLQX.Location = new Point(12, 110);
            lblLQX.Name = "lblLQX";
            lblLQX.Size = new Size(89, 15);
            lblLQX.TabIndex = 72;
            lblLQX.Text = "L Quaternion X:";
            // 
            // lblLTY
            // 
            lblLTY.AutoSize = true;
            lblLTY.Location = new Point(149, 44);
            lblLTY.Name = "lblLTY";
            lblLTY.Size = new Size(91, 15);
            lblLTY.TabIndex = 71;
            lblLTY.Text = "L Thumbstick Y:";
            // 
            // lblLTX
            // 
            lblLTX.AutoSize = true;
            lblLTX.Location = new Point(12, 44);
            lblLTX.Name = "lblLTX";
            lblLTX.Size = new Size(91, 15);
            lblLTX.TabIndex = 70;
            lblLTX.Text = "L Thumbstick X:";
            // 
            // tbLTY
            // 
            tbLTY.Location = new Point(149, 62);
            tbLTY.Maximum = 100;
            tbLTY.Minimum = -100;
            tbLTY.Name = "tbLTY";
            tbLTY.Size = new Size(125, 45);
            tbLTY.TabIndex = 69;
            // 
            // tbLTX
            // 
            tbLTX.Location = new Point(12, 62);
            tbLTX.Maximum = 100;
            tbLTX.Minimum = -100;
            tbLTX.Name = "tbLTX";
            tbLTX.Size = new Size(125, 45);
            tbLTX.TabIndex = 68;
            // 
            // tbLQW
            // 
            tbLQW.Location = new Point(149, 194);
            tbLQW.Maximum = 100;
            tbLQW.Minimum = -100;
            tbLQW.Name = "tbLQW";
            tbLQW.Size = new Size(125, 45);
            tbLQW.TabIndex = 67;
            // 
            // tbLQZ
            // 
            tbLQZ.Location = new Point(10, 194);
            tbLQZ.Maximum = 100;
            tbLQZ.Minimum = -100;
            tbLQZ.Name = "tbLQZ";
            tbLQZ.Size = new Size(125, 45);
            tbLQZ.TabIndex = 66;
            // 
            // tbLQY
            // 
            tbLQY.Location = new Point(149, 128);
            tbLQY.Maximum = 100;
            tbLQY.Minimum = -100;
            tbLQY.Name = "tbLQY";
            tbLQY.Size = new Size(125, 45);
            tbLQY.TabIndex = 65;
            // 
            // tbLQX
            // 
            tbLQX.Location = new Point(12, 128);
            tbLQX.Maximum = 100;
            tbLQX.Minimum = -100;
            tbLQX.Name = "tbLQX";
            tbLQX.Size = new Size(125, 45);
            tbLQX.TabIndex = 64;
            // 
            // txtLPos
            // 
            txtLPos.Location = new Point(409, 6);
            txtLPos.Name = "txtLPos";
            txtLPos.Size = new Size(150, 23);
            txtLPos.TabIndex = 76;
            txtLPos.Text = "-0.008 -0.229 -0.173";
            txtLPos.TextChanged += txtLPos_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(341, 10);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 77;
            label8.Text = "L Position:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(565, 10);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 79;
            label9.Text = "R Position:";
            // 
            // txtRPos
            // 
            txtRPos.Location = new Point(634, 7);
            txtRPos.Name = "txtRPos";
            txtRPos.Size = new Size(150, 23);
            txtRPos.TabIndex = 78;
            txtRPos.Text = "0.154 -0.240 -0.140";
            txtRPos.TextChanged += txtRPos_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(790, 10);
            label12.Name = "label12";
            label12.Size = new Size(84, 15);
            label12.TabIndex = 81;
            label12.Text = "HMD Position:";
            // 
            // txtHPos
            // 
            txtHPos.Location = new Point(880, 6);
            txtHPos.Name = "txtHPos";
            txtHPos.Size = new Size(150, 23);
            txtHPos.TabIndex = 80;
            txtHPos.Text = "0.037 0.006 -0.017";
            txtHPos.TextChanged += txtHPos_TextChanged;
            // 
            // lblHMDQW
            // 
            lblHMDQW.AutoSize = true;
            lblHMDQW.Location = new Point(735, 176);
            lblHMDQW.Name = "lblHMDQW";
            lblHMDQW.Size = new Size(115, 15);
            lblHMDQW.TabIndex = 89;
            lblHMDQW.Text = "HMD Quaternion W:";
            // 
            // lblHMDQY
            // 
            lblHMDQY.AutoSize = true;
            lblHMDQY.Location = new Point(735, 110);
            lblHMDQY.Name = "lblHMDQY";
            lblHMDQY.Size = new Size(111, 15);
            lblHMDQY.TabIndex = 88;
            lblHMDQY.Text = "HMD Quaternion Y:";
            // 
            // lblHMDQZ
            // 
            lblHMDQZ.AutoSize = true;
            lblHMDQZ.Location = new Point(598, 176);
            lblHMDQZ.Name = "lblHMDQZ";
            lblHMDQZ.Size = new Size(111, 15);
            lblHMDQZ.TabIndex = 87;
            lblHMDQZ.Text = "HMD Quaternion Z:";
            // 
            // lblHMDQX
            // 
            lblHMDQX.AutoSize = true;
            lblHMDQX.Location = new Point(598, 110);
            lblHMDQX.Name = "lblHMDQX";
            lblHMDQX.Size = new Size(111, 15);
            lblHMDQX.TabIndex = 86;
            lblHMDQX.Text = "HMD Quaternion X:";
            // 
            // tbHQW
            // 
            tbHQW.Location = new Point(735, 194);
            tbHQW.Maximum = 100;
            tbHQW.Minimum = -100;
            tbHQW.Name = "tbHQW";
            tbHQW.Size = new Size(125, 45);
            tbHQW.TabIndex = 85;
            // 
            // tbHQZ
            // 
            tbHQZ.Location = new Point(596, 194);
            tbHQZ.Maximum = 100;
            tbHQZ.Minimum = -100;
            tbHQZ.Name = "tbHQZ";
            tbHQZ.Size = new Size(125, 45);
            tbHQZ.TabIndex = 84;
            // 
            // tbHQY
            // 
            tbHQY.Location = new Point(735, 128);
            tbHQY.Maximum = 100;
            tbHQY.Minimum = -100;
            tbHQY.Name = "tbHQY";
            tbHQY.Size = new Size(125, 45);
            tbHQY.TabIndex = 83;
            // 
            // tbHQX
            // 
            tbHQX.Location = new Point(598, 128);
            tbHQX.Maximum = 100;
            tbHQX.Minimum = -100;
            tbHQX.Name = "tbHQX";
            tbHQX.Size = new Size(125, 45);
            tbHQX.TabIndex = 82;
            // 
            // chkZeroThumbs
            // 
            chkZeroThumbs.AutoSize = true;
            chkZeroThumbs.Checked = true;
            chkZeroThumbs.CheckState = CheckState.Checked;
            chkZeroThumbs.Location = new Point(572, 70);
            chkZeroThumbs.Name = "chkZeroThumbs";
            chkZeroThumbs.Size = new Size(184, 19);
            chkZeroThumbs.TabIndex = 90;
            chkZeroThumbs.Text = "Release Thumbs On MouseUp";
            chkZeroThumbs.UseVisualStyleBackColor = true;
            chkZeroThumbs.CheckedChanged += chkZeroThumbs_CheckedChanged;
            // 
            // chkReleaseBtnOnMouseUp
            // 
            chkReleaseBtnOnMouseUp.AutoSize = true;
            chkReleaseBtnOnMouseUp.Location = new Point(872, 58);
            chkReleaseBtnOnMouseUp.Name = "chkReleaseBtnOnMouseUp";
            chkReleaseBtnOnMouseUp.RightToLeft = RightToLeft.Yes;
            chkReleaseBtnOnMouseUp.Size = new Size(85, 34);
            chkReleaseBtnOnMouseUp.TabIndex = 91;
            chkReleaseBtnOnMouseUp.Text = "Release On\r\n:MouseOut";
            chkReleaseBtnOnMouseUp.UseVisualStyleBackColor = true;
            // 
            // btnImportUDP
            // 
            btnImportUDP.Location = new Point(872, 123);
            btnImportUDP.Name = "btnImportUDP";
            btnImportUDP.Size = new Size(84, 44);
            btnImportUDP.TabIndex = 92;
            btnImportUDP.Text = "Import UDP Data";
            btnImportUDP.UseVisualStyleBackColor = true;
            btnImportUDP.Click += btnImportUDP_Click;
            // 
            // chkAlwaysOnTop
            // 
            chkAlwaysOnTop.AutoSize = true;
            chkAlwaysOnTop.Location = new Point(1056, 172);
            chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            chkAlwaysOnTop.Size = new Size(104, 19);
            chkAlwaysOnTop.TabIndex = 93;
            chkAlwaysOnTop.Text = "Always On Top";
            chkAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // chkReadKeys
            // 
            chkReadKeys.AutoSize = true;
            chkReadKeys.Location = new Point(1393, 273);
            chkReadKeys.Name = "chkReadKeys";
            chkReadKeys.Size = new Size(105, 19);
            chkReadKeys.TabIndex = 94;
            chkReadKeys.Text = "Read Key Input";
            chkReadKeys.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1508, 234);
            Controls.Add(chkReadKeys);
            Controls.Add(chkAlwaysOnTop);
            Controls.Add(btnImportUDP);
            Controls.Add(chkReleaseBtnOnMouseUp);
            Controls.Add(chkZeroThumbs);
            Controls.Add(lblHMDQW);
            Controls.Add(lblHMDQY);
            Controls.Add(lblHMDQZ);
            Controls.Add(lblHMDQX);
            Controls.Add(tbHQW);
            Controls.Add(tbHQZ);
            Controls.Add(tbHQY);
            Controls.Add(tbHQX);
            Controls.Add(label12);
            Controls.Add(txtHPos);
            Controls.Add(label9);
            Controls.Add(txtRPos);
            Controls.Add(label8);
            Controls.Add(txtLPos);
            Controls.Add(lblLQW);
            Controls.Add(lblLQY);
            Controls.Add(lblLQZ);
            Controls.Add(lblLQX);
            Controls.Add(lblLTY);
            Controls.Add(lblLTX);
            Controls.Add(tbLTY);
            Controls.Add(tbLTX);
            Controls.Add(tbLQW);
            Controls.Add(tbLQZ);
            Controls.Add(tbLQY);
            Controls.Add(tbLQX);
            Controls.Add(lblRQW);
            Controls.Add(lblRQY);
            Controls.Add(lblRQZ);
            Controls.Add(lblRQX);
            Controls.Add(lblRTY);
            Controls.Add(lblRTX);
            Controls.Add(tbRTY);
            Controls.Add(tbRTX);
            Controls.Add(tbRQW);
            Controls.Add(tbRQZ);
            Controls.Add(tbRQY);
            Controls.Add(tbRQX);
            Controls.Add(label7);
            Controls.Add(txtIPDFOV);
            Controls.Add(label6);
            Controls.Add(txtHMD);
            Controls.Add(chkRB);
            Controls.Add(chkRA);
            Controls.Add(chkRTHUMBRIGHT);
            Controls.Add(chkRTHUMBLEFT);
            Controls.Add(chkRTHUMBDOWN);
            Controls.Add(chkRTHUMBUP);
            Controls.Add(chkRTHUMBCLICK);
            Controls.Add(chkRTRIGGER);
            Controls.Add(chkRGRIP);
            Controls.Add(chkLY);
            Controls.Add(chkLX);
            Controls.Add(chkLTHUMBRIGHT);
            Controls.Add(chkLTHUMBLEFT);
            Controls.Add(chkLTHUMBDOWN);
            Controls.Add(chkLTHUMBUP);
            Controls.Add(chkLTHUMBCLICK);
            Controls.Add(chkLTRIGGER);
            Controls.Add(chkLMENU);
            Controls.Add(label4);
            Controls.Add(chkLGRIP);
            Controls.Add(label3);
            Controls.Add(btnCopyUDPData);
            Controls.Add(lblOXRFrameId);
            Controls.Add(tbOXRFrameId);
            Controls.Add(chkAutoIncrementFrameId);
            Controls.Add(txtSentData);
            Controls.Add(lblDataSending);
            Controls.Add(btnApplyIP);
            Controls.Add(label1);
            Controls.Add(txtTargetIP);
            Controls.Add(chkAutoSendUDP);
            Controls.Add(btnSendFrame);
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            Text = "XrAPI - UDP Tester";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)tbOXRFrameId).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbRQX).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbRQY).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbRQZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbRQW).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbRTX).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbRTY).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLTY).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLTX).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLQW).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLQZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLQY).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLQX).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbHQW).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbHQZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbHQY).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbHQX).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSendFrame;
        private CheckBox chkAutoSendUDP;
        private System.Windows.Forms.Timer timSendInterval;
        private TextBox txtTargetIP;
        private Label label1;
        private Button btnApplyIP;
        private Label lblDataSending;
        private TextBox txtSentData;
        private CheckBox chkAutoIncrementFrameId;
        private TrackBar tbOXRFrameId;
        private Label lblOXRFrameId;
        private Button btnCopyUDPData;
        private System.Windows.Forms.Timer timHideSendTxt;
        private Label label3;
        private CheckBox chkLGRIP;
        private Label label4;
        private CheckBox chkLMENU;
        private CheckBox chkLTRIGGER;
        private CheckBox chkLTHUMBCLICK;
        private CheckBox chkLTHUMBUP;
        private CheckBox chkLTHUMBDOWN;
        private CheckBox chkLTHUMBRIGHT;
        private CheckBox chkLTHUMBLEFT;
        private CheckBox chkLX;
        private CheckBox chkLY;
        private CheckBox chkRB;
        private CheckBox chkRA;
        private CheckBox chkRTHUMBRIGHT;
        private CheckBox chkRTHUMBLEFT;
        private CheckBox chkRTHUMBDOWN;
        private CheckBox chkRTHUMBUP;
        private CheckBox chkRTHUMBCLICK;
        private CheckBox chkRTRIGGER;
        private CheckBox chkRGRIP;
        private Label label6;
        private TextBox txtHMD;
        private TextBox txtIPDFOV;
        private Label label7;
        private TrackBar tbRQX;
        private TrackBar tbRQY;
        private TrackBar tbRQZ;
        private TrackBar tbRQW;
        private TrackBar tbRTX;
        private TrackBar tbRTY;
        private Label lblRTX;
        private Label lblRTY;
        private Label lblRQX;
        private Label lblRQZ;
        private Label lblRQY;
        private Label lblRQW;
        private Label lblLQW;
        private Label lblLQY;
        private Label lblLQZ;
        private Label lblLQX;
        private Label lblLTY;
        private Label lblLTX;
        private TrackBar tbLTY;
        private TrackBar tbLTX;
        private TrackBar tbLQW;
        private TrackBar tbLQZ;
        private TrackBar tbLQY;
        private TrackBar tbLQX;
        private TextBox txtLPos;
        private Label label8;
        private Label label9;
        private TextBox txtRPos;
        private Label label12;
        private TextBox txtHPos;
        private Label lblHMDQW;
        private Label lblHMDQY;
        private Label lblHMDQZ;
        private Label lblHMDQX;
        private TrackBar tbHQW;
        private TrackBar tbHQZ;
        private TrackBar tbHQY;
        private TrackBar tbHQX;
        private CheckBox chkZeroThumbs;
        private CheckBox chkReleaseBtnOnMouseUp;
        private Button btnImportUDP;
        private CheckBox chkAlwaysOnTop;
        private CheckBox chkReadKeys;
    }
}
