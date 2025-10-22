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
            this.btnMetaQuest3 = new System.Windows.Forms.Button();
            this.btnPico4 = new System.Windows.Forms.Button();
            this.btnPico4Eco = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSavedFOV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbNonStationaryScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSwingSens)).BeginInit();
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
            this.lblSaved.Location = new System.Drawing.Point(481, 496);
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
            this.tbNonStationaryScale.Location = new System.Drawing.Point(84, 403);
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
            this.btnSave.Location = new System.Drawing.Point(550, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(192, 72);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNonStationaryScale
            // 
            this.lblNonStationaryScale.AutoSize = true;
            this.lblNonStationaryScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonStationaryScale.Location = new System.Drawing.Point(193, 368);
            this.lblNonStationaryScale.Name = "lblNonStationaryScale";
            this.lblNonStationaryScale.Size = new System.Drawing.Size(17, 17);
            this.lblNonStationaryScale.TabIndex = 4;
            this.lblNonStationaryScale.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Non-Stationary Boundary:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motion Scale:";
            // 
            // chkNonStationaryBoundary
            // 
            this.chkNonStationaryBoundary.AutoSize = true;
            this.chkNonStationaryBoundary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNonStationaryBoundary.Location = new System.Drawing.Point(283, 333);
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
            this.label4.Location = new System.Drawing.Point(481, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Melee Swing Sensitivity:";
            // 
            // tbSwingSens
            // 
            this.tbSwingSens.Location = new System.Drawing.Point(484, 403);
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
            this.lblSwingSens.Location = new System.Drawing.Point(669, 368);
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
            this.chkDisableThumbTurn.Location = new System.Drawing.Point(283, 263);
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
            this.label7.Location = new System.Drawing.Point(62, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Disable Thumbstick Turning:";
            // 
            // chkDisableThumbMove
            // 
            this.chkDisableThumbMove.AutoSize = true;
            this.chkDisableThumbMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableThumbMove.Location = new System.Drawing.Point(283, 298);
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
            this.label8.Location = new System.Drawing.Point(45, 297);
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
            this.label9.Size = new System.Drawing.Size(134, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "FOV Presets:";
            // 
            // btnMetaQuest3
            // 
            this.btnMetaQuest3.Location = new System.Drawing.Point(65, 108);
            this.btnMetaQuest3.Name = "btnMetaQuest3";
            this.btnMetaQuest3.Size = new System.Drawing.Size(192, 72);
            this.btnMetaQuest3.TabIndex = 20;
            this.btnMetaQuest3.Text = "Meta Quest 3 / 3S";
            this.btnMetaQuest3.UseVisualStyleBackColor = true;
            this.btnMetaQuest3.Click += new System.EventHandler(this.btnMetaQuest3_Click);
            // 
            // btnPico4
            // 
            this.btnPico4.Location = new System.Drawing.Point(292, 108);
            this.btnPico4.Name = "btnPico4";
            this.btnPico4.Size = new System.Drawing.Size(192, 72);
            this.btnPico4.TabIndex = 21;
            this.btnPico4.Text = "Pico 4 Ultra";
            this.btnPico4.UseVisualStyleBackColor = true;
            this.btnPico4.Click += new System.EventHandler(this.btnPico4_Click);
            // 
            // btnPico4Eco
            // 
            this.btnPico4Eco.Location = new System.Drawing.Point(518, 108);
            this.btnPico4Eco.Name = "btnPico4Eco";
            this.btnPico4Eco.Size = new System.Drawing.Size(192, 72);
            this.btnPico4Eco.TabIndex = 22;
            this.btnPico4Eco.Text = "Pico 4 Ultra (Power Saving Mode)";
            this.btnPico4Eco.UseVisualStyleBackColor = true;
            this.btnPico4Eco.Click += new System.EventHandler(this.btnPico4Eco_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 24);
            this.label10.TabIndex = 23;
            this.label10.Text = "Conf Settings:";
            // 
            // lblSavedFOV
            // 
            this.lblSavedFOV.AutoSize = true;
            this.lblSavedFOV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavedFOV.Location = new System.Drawing.Point(653, 198);
            this.lblSavedFOV.Name = "lblSavedFOV";
            this.lblSavedFOV.Size = new System.Drawing.Size(57, 17);
            this.lblSavedFOV.TabIndex = 24;
            this.lblSavedFOV.Text = "Saved!";
            this.lblSavedFOV.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblSavedFOV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPico4Eco);
            this.Controls.Add(this.btnPico4);
            this.Controls.Add(this.btnMetaQuest3);
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
        private System.Windows.Forms.Button btnMetaQuest3;
        private System.Windows.Forms.Button btnPico4;
        private System.Windows.Forms.Button btnPico4Eco;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSavedFOV;
    }
}

