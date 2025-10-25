namespace HWXR_ConfEdit
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSaved = new System.Windows.Forms.Label();
            this.timSaveTimer = new System.Windows.Forms.Timer(this.components);
            this.tbNonStationaryScale = new System.Windows.Forms.TrackBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNonStationaryScale = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkNonStationaryBoundary = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSwingSens = new System.Windows.Forms.TrackBar();
            this.lblSwingSens = new System.Windows.Forms.Label();
            this.chkBtnMelee = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnableHaptics = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDisableThumbTurn = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkDisableThumbMove = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSavedFOV = new System.Windows.Forms.Label();
            this.btnApplyPreset = new System.Windows.Forms.Button();
            this.lstFOVPresets = new System.Windows.Forms.ListBox();
            this.btnSaveCustomFOV = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPresetValues = new System.Windows.Forms.Label();
            this.lblPresetName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.varA = new System.Windows.Forms.NumericUpDown();
            this.varB = new System.Windows.Forms.NumericUpDown();
            this.varC = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.varD = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbNonStationaryScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSwingSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(530, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modify the default HWXR values for config.txt and fov.txt";
            // 
            // lblSaved
            // 
            this.lblSaved.AutoSize = true;
            this.lblSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaved.Location = new System.Drawing.Point(685, 533);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(57, 17);
            this.lblSaved.TabIndex = 1;
            this.lblSaved.Text = "Saved!";
            this.lblSaved.Visible = false;
            // 
            // timSaveTimer
            // 
            this.timSaveTimer.Interval = 3000;
            this.timSaveTimer.Tick += new System.EventHandler(this.timSaveTimer_Tick);
            // 
            // tbNonStationaryScale
            // 
            this.tbNonStationaryScale.Location = new System.Drawing.Point(88, 427);
            this.tbNonStationaryScale.Maximum = 6;
            this.tbNonStationaryScale.Minimum = 1;
            this.tbNonStationaryScale.Name = "tbNonStationaryScale";
            this.tbNonStationaryScale.Size = new System.Drawing.Size(258, 45);
            this.tbNonStationaryScale.TabIndex = 2;
            this.tbNonStationaryScale.Value = 3;
            this.tbNonStationaryScale.Scroll += new System.EventHandler(this.tbNonStationaryScale_Scroll);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(502, 464);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(240, 58);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNonStationaryScale
            // 
            this.lblNonStationaryScale.AutoSize = true;
            this.lblNonStationaryScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonStationaryScale.Location = new System.Drawing.Point(275, 397);
            this.lblNonStationaryScale.Name = "lblNonStationaryScale";
            this.lblNonStationaryScale.Size = new System.Drawing.Size(17, 17);
            this.lblNonStationaryScale.TabIndex = 4;
            this.lblNonStationaryScale.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enable Non-Stationary Boundary:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Non-Stationary Motion Scale:";
            // 
            // chkNonStationaryBoundary
            // 
            this.chkNonStationaryBoundary.AutoSize = true;
            this.chkNonStationaryBoundary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNonStationaryBoundary.Location = new System.Drawing.Point(306, 367);
            this.chkNonStationaryBoundary.Name = "chkNonStationaryBoundary";
            this.chkNonStationaryBoundary.Size = new System.Drawing.Size(64, 17);
            this.chkNonStationaryBoundary.TabIndex = 7;
            this.chkNonStationaryBoundary.Text = "FALSE";
            this.chkNonStationaryBoundary.UseVisualStyleBackColor = true;
            this.chkNonStationaryBoundary.CheckedChanged += new System.EventHandler(this.chkNonStationaryBoundary_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Melee Swing Sensitivity:";
            // 
            // tbSwingSens
            // 
            this.tbSwingSens.Location = new System.Drawing.Point(88, 505);
            this.tbSwingSens.Maximum = 6;
            this.tbSwingSens.Minimum = 1;
            this.tbSwingSens.Name = "tbSwingSens";
            this.tbSwingSens.Size = new System.Drawing.Size(258, 45);
            this.tbSwingSens.TabIndex = 9;
            this.tbSwingSens.Value = 3;
            this.tbSwingSens.Scroll += new System.EventHandler(this.tbSwingSens_Scroll);
            // 
            // lblSwingSens
            // 
            this.lblSwingSens.AutoSize = true;
            this.lblSwingSens.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwingSens.Location = new System.Drawing.Point(237, 475);
            this.lblSwingSens.Name = "lblSwingSens";
            this.lblSwingSens.Size = new System.Drawing.Size(17, 17);
            this.lblSwingSens.TabIndex = 10;
            this.lblSwingSens.Text = "3";
            // 
            // chkBtnMelee
            // 
            this.chkBtnMelee.AutoSize = true;
            this.chkBtnMelee.Checked = true;
            this.chkBtnMelee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBtnMelee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBtnMelee.Location = new System.Drawing.Point(650, 333);
            this.chkBtnMelee.Name = "chkBtnMelee";
            this.chkBtnMelee.Size = new System.Drawing.Size(60, 17);
            this.chkBtnMelee.TabIndex = 12;
            this.chkBtnMelee.Text = "TRUE";
            this.chkBtnMelee.UseVisualStyleBackColor = true;
            this.chkBtnMelee.CheckedChanged += new System.EventHandler(this.chkBtnMelee_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(481, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Enable Button Melee:";
            // 
            // chkEnableHaptics
            // 
            this.chkEnableHaptics.AutoSize = true;
            this.chkEnableHaptics.Checked = true;
            this.chkEnableHaptics.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableHaptics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableHaptics.Location = new System.Drawing.Point(650, 298);
            this.chkEnableHaptics.Name = "chkEnableHaptics";
            this.chkEnableHaptics.Size = new System.Drawing.Size(60, 17);
            this.chkEnableHaptics.TabIndex = 14;
            this.chkEnableHaptics.Text = "TRUE";
            this.chkEnableHaptics.UseVisualStyleBackColor = true;
            this.chkEnableHaptics.CheckedChanged += new System.EventHandler(this.chkEnableHaptics_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(522, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Enable Haptics:";
            // 
            // chkDisableThumbTurn
            // 
            this.chkDisableThumbTurn.AutoSize = true;
            this.chkDisableThumbTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableThumbTurn.Location = new System.Drawing.Point(270, 298);
            this.chkDisableThumbTurn.Name = "chkDisableThumbTurn";
            this.chkDisableThumbTurn.Size = new System.Drawing.Size(64, 17);
            this.chkDisableThumbTurn.TabIndex = 16;
            this.chkDisableThumbTurn.Text = "FALSE";
            this.chkDisableThumbTurn.UseVisualStyleBackColor = true;
            this.chkDisableThumbTurn.CheckedChanged += new System.EventHandler(this.chkDisableThumbTurn_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Disable Thumbstick Turning:";
            // 
            // chkDisableThumbMove
            // 
            this.chkDisableThumbMove.AutoSize = true;
            this.chkDisableThumbMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableThumbMove.Location = new System.Drawing.Point(287, 333);
            this.chkDisableThumbMove.Name = "chkDisableThumbMove";
            this.chkDisableThumbMove.Size = new System.Drawing.Size(64, 17);
            this.chkDisableThumbMove.TabIndex = 18;
            this.chkDisableThumbMove.Text = "FALSE";
            this.chkDisableThumbMove.UseVisualStyleBackColor = true;
            this.chkDisableThumbMove.CheckedChanged += new System.EventHandler(this.chkDisableThumbMove_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(49, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Disable Thumbstick Movement:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "FOV Settings:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 24);
            this.label10.TabIndex = 23;
            this.label10.Text = "Conf Settings:";
            // 
            // lblSavedFOV
            // 
            this.lblSavedFOV.AutoSize = true;
            this.lblSavedFOV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavedFOV.Location = new System.Drawing.Point(685, 268);
            this.lblSavedFOV.Name = "lblSavedFOV";
            this.lblSavedFOV.Size = new System.Drawing.Size(57, 17);
            this.lblSavedFOV.TabIndex = 24;
            this.lblSavedFOV.Text = "Saved!";
            this.lblSavedFOV.Visible = false;
            // 
            // btnApplyPreset
            // 
            this.btnApplyPreset.Location = new System.Drawing.Point(502, 130);
            this.btnApplyPreset.Name = "btnApplyPreset";
            this.btnApplyPreset.Size = new System.Drawing.Size(240, 58);
            this.btnApplyPreset.TabIndex = 25;
            this.btnApplyPreset.Text = "Apply Preset FOV";
            this.btnApplyPreset.UseVisualStyleBackColor = true;
            this.btnApplyPreset.Click += new System.EventHandler(this.btnApplyPreset_Click);
            // 
            // lstFOVPresets
            // 
            this.lstFOVPresets.FormattingEnabled = true;
            this.lstFOVPresets.Location = new System.Drawing.Point(166, 67);
            this.lstFOVPresets.Name = "lstFOVPresets";
            this.lstFOVPresets.ScrollAlwaysVisible = true;
            this.lstFOVPresets.Size = new System.Drawing.Size(311, 121);
            this.lstFOVPresets.TabIndex = 26;
            this.lstFOVPresets.SelectedIndexChanged += new System.EventHandler(this.lstFOVPresets_SelectedIndexChanged);
            // 
            // btnSaveCustomFOV
            // 
            this.btnSaveCustomFOV.Location = new System.Drawing.Point(502, 201);
            this.btnSaveCustomFOV.Name = "btnSaveCustomFOV";
            this.btnSaveCustomFOV.Size = new System.Drawing.Size(240, 58);
            this.btnSaveCustomFOV.TabIndex = 27;
            this.btnSaveCustomFOV.Text = "Apply Custom FOV";
            this.btnSaveCustomFOV.UseVisualStyleBackColor = true;
            this.btnSaveCustomFOV.Click += new System.EventHandler(this.btnSaveCustomFOV_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(163, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 39);
            this.label11.TabIndex = 28;
            this.label11.Text = "FOV_Width = A * FOVW + B\r\n\r\nFOV_Height = C * FOVH + D";
            // 
            // lblPresetValues
            // 
            this.lblPresetValues.AutoSize = true;
            this.lblPresetValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresetValues.Location = new System.Drawing.Point(499, 93);
            this.lblPresetValues.Name = "lblPresetValues";
            this.lblPresetValues.Size = new System.Drawing.Size(196, 17);
            this.lblPresetValues.TabIndex = 29;
            this.lblPresetValues.Text = "A: 1.0 B: 0.0 C: 1.0 D: 0.0";
            // 
            // lblPresetName
            // 
            this.lblPresetName.AutoSize = true;
            this.lblPresetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresetName.Location = new System.Drawing.Point(499, 67);
            this.lblPresetName.Name = "lblPresetName";
            this.lblPresetName.Size = new System.Drawing.Size(117, 17);
            this.lblPresetName.TabIndex = 30;
            this.lblPresetName.Text = "PRESET NAME";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(315, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "A:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(399, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "B:";
            // 
            // varA
            // 
            this.varA.DecimalPlaces = 2;
            this.varA.Location = new System.Drawing.Point(344, 208);
            this.varA.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.varA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.varA.Name = "varA";
            this.varA.Size = new System.Drawing.Size(49, 20);
            this.varA.TabIndex = 33;
            this.varA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.varA.ValueChanged += new System.EventHandler(this.varA_ValueChanged);
            // 
            // varB
            // 
            this.varB.Location = new System.Drawing.Point(428, 208);
            this.varB.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.varB.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            -2147483648});
            this.varB.Name = "varB";
            this.varB.Size = new System.Drawing.Size(49, 20);
            this.varB.TabIndex = 34;
            this.varB.ValueChanged += new System.EventHandler(this.varB_ValueChanged);
            // 
            // varC
            // 
            this.varC.DecimalPlaces = 2;
            this.varC.Location = new System.Drawing.Point(344, 234);
            this.varC.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.varC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.varC.Name = "varC";
            this.varC.Size = new System.Drawing.Size(49, 20);
            this.varC.TabIndex = 36;
            this.varC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.varC.ValueChanged += new System.EventHandler(this.varC_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(315, 234);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 17);
            this.label14.TabIndex = 35;
            this.label14.Text = "C:";
            // 
            // varD
            // 
            this.varD.Location = new System.Drawing.Point(428, 234);
            this.varD.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.varD.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            -2147483648});
            this.varD.Name = "varD";
            this.varD.Size = new System.Drawing.Size(49, 20);
            this.varD.TabIndex = 38;
            this.varD.ValueChanged += new System.EventHandler(this.varD_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(399, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 17);
            this.label15.TabIndex = 37;
            this.label15.Text = "D:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.varD);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.varC);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.varB);
            this.Controls.Add(this.varA);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblPresetName);
            this.Controls.Add(this.lblPresetValues);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSaveCustomFOV);
            this.Controls.Add(this.lstFOVPresets);
            this.Controls.Add(this.btnApplyPreset);
            this.Controls.Add(this.lblSavedFOV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkDisableThumbMove);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkDisableThumbTurn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkEnableHaptics);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkBtnMelee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSwingSens);
            this.Controls.Add(this.tbSwingSens);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkNonStationaryBoundary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNonStationaryScale);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbNonStationaryScale);
            this.Controls.Add(this.lblSaved);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "HWXR Conf Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbNonStationaryScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSwingSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSaved;
        private System.Windows.Forms.Timer timSaveTimer;
        private System.Windows.Forms.TrackBar tbNonStationaryScale;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNonStationaryScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNonStationaryBoundary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbSwingSens;
        private System.Windows.Forms.Label lblSwingSens;
        private System.Windows.Forms.CheckBox chkBtnMelee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnableHaptics;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDisableThumbTurn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkDisableThumbMove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSavedFOV;
        private System.Windows.Forms.Button btnApplyPreset;
        private System.Windows.Forms.ListBox lstFOVPresets;
        private System.Windows.Forms.Button btnSaveCustomFOV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPresetValues;
        private System.Windows.Forms.Label lblPresetName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown varA;
        private System.Windows.Forms.NumericUpDown varB;
        private System.Windows.Forms.NumericUpDown varC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown varD;
        private System.Windows.Forms.Label label15;
    }
}

