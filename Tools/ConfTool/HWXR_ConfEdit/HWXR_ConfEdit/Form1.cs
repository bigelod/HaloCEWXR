using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWXR_ConfEdit
{
    public partial class Form1 : Form
    {
        //Quick-And-Dirty HWXR Conf Tool with web loaded FOV preset values
        List<string> fovPresets = new List<string>();
        List<string> fovNames = new List<string>();
        List<string> fovVarAs = new List<string>();
        List<string> fovVarBs = new List<string>();
        List<string> fovVarCs = new List<string>();
        List<string> fovVarDs = new List<string>();

        string fovFile = "fov.txt";
        string confFile = "config.txt";

        string fovPresetURL = "https://raw.githubusercontent.com/bigelod/HaloCEWXR/refs/heads/master/Tools/ConfTool/HWXR_ConfEdit/fov_presets.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void timSaveTimer_Tick(object sender, EventArgs e)
        {
            lblSavedFOV.Visible = false;
            lblSaved.Visible = false;

            if (timSaveTimer.Enabled)
            {
                timSaveTimer.Stop();
                timSaveTimer.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool backupMethod = false;

            string rawText = "";

            try
            {
                using (var webClient = new WebClient())
                {
                    rawText = webClient.DownloadString(fovPresetURL).Replace("\n", System.Environment.NewLine);
                }
            }
            catch
            {
                backupMethod = true;
                fovPresets = new List<string>();
            }

            if (backupMethod)
            {
                if (Properties.Resources.fov_presets == null || Properties.Resources.fov_presets == "")
                {
                    //Hard code one in case of total failure
                    rawText = "";
                    fovPresets.Add("Generic,1.0,0,1.0,0");
                }
                else
                {
                    rawText = Properties.Resources.fov_presets;
                }
            }

            if (rawText != null && rawText != "")
            {
                foreach (string line in rawText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    if (line.Contains(","))
                    {
                        fovPresets.Add(line);
                    }
                }
            }

            foreach (string str in fovPresets)
            {
                string[] parts = str.Split(',');

                if (parts.Length >= 5)
                {
                    lstFOVPresets.Items.Add(parts[0]);
                    fovNames.Add(parts[0]);
                    fovVarAs.Add(parts[1]);
                    fovVarBs.Add(parts[2]);
                    fovVarCs.Add(parts[3]);
                    fovVarDs.Add(parts[4]);
                }
            }

            if (lstFOVPresets.Items.Count > 0) lstFOVPresets.SelectedIndex = 0;
        }

        private void EditConfFile(string findLineText, string newValue)
        {
            try
            {
                string confPath = Path.Combine(Application.StartupPath, confFile);
                if (File.Exists(confPath))
                {
                    string[] lines = File.ReadAllLines(confPath);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(findLineText))
                        {
                            lines[i] = findLineText + newValue;
                        }
                    }

                    if (File.Exists(confPath + ".bak"))
                    {
                        File.Delete(confPath + ".bak");
                    }

                    File.Move(confPath, confPath + ".bak");

                    File.WriteAllLines(confPath, lines);

                    lblSaved.Visible = true;
                    timSaveTimer.Enabled = true;
                    timSaveTimer.Start();
                }
            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
             * Maybe in future allow these to be edited?
             *     PlasmaPistolHapticStrength = 0.6
             *     SniperRifleHapticStrength = 1
             *     PistolHapticStrength = 0.85
             *     PlasmaRifleHapticStrength = 0.6
             *     ShotgunHapticStrength = 1
             *     AssaultRifleHapticStrength = 0.7
             *     RocketLauncherHapticStrength = 1
             *     FlamethrowerHapticStrength = 0.5
             *     PlasmaCannonHapticStrength = 1
             *     NeedlerHapticStrength = 0.7
             *     FuelRodHapticStrength = 1
             */

            EditConfFile("NonstationaryBoundary = ", chkNonStationaryBoundary.Checked.ToString().ToLower());
            EditConfFile("NonstationaryWalkScale = ", tbNonStationaryScale.Value.ToString());
            EditConfFile("EnableHaptics = ", chkEnableHaptics.Checked.ToString().ToLower());
            EditConfFile("EnableButtonMelee = ", chkBtnMelee.Checked.ToString().ToLower());
            EditConfFile("MeleeSwingVelocitySensitivity = ", tbSwingSens.Value.ToString());
            EditConfFile("DisableThumbstickMovement = ", chkDisableThumbMove.Checked.ToString().ToLower());
            EditConfFile("DisableThumbstickRotation = ", chkDisableThumbTurn.Checked.ToString().ToLower());

        }

        private void tbNonStationaryScale_Scroll(object sender, EventArgs e)
        {
            lblNonStationaryScale.Text = tbNonStationaryScale.Value.ToString();
        }

        private void chkNonStationaryBoundary_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNonStationaryBoundary.Checked)
            {
                chkNonStationaryBoundary.Text = "TRUE";
            }
            else
            {
                chkNonStationaryBoundary.Text = "FALSE";
                chkDisableThumbMove.Checked = false;
            }
        }

        private void tbSwingSens_Scroll(object sender, EventArgs e)
        {
            lblSwingSens.Text = tbSwingSens.Value.ToString();
        }

        private void chkBtnMelee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBtnMelee.Checked)
            {
                chkBtnMelee.Text = "TRUE";
            }
            else
            {
                chkBtnMelee.Text = "FALSE";
            }
        }

        private void chkEnableHaptics_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableHaptics.Checked)
            {
                chkEnableHaptics.Text = "TRUE";
            }
            else
            {
                chkEnableHaptics.Text = "FALSE";
            }
        }

        private void chkDisableThumbTurn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisableThumbTurn.Checked)
            {
                chkDisableThumbTurn.Text = "TRUE";
            }
            else
            {
                chkDisableThumbTurn.Text = "FALSE";
            }
        }

        private void chkDisableThumbMove_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisableThumbMove.Checked)
            {
                chkDisableThumbMove.Text = "TRUE";
                chkNonStationaryBoundary.Checked = true;
            }
            else
            {
                chkDisableThumbMove.Text = "FALSE";
            }
        }

        private void WriteFOVValues(string valA, string valB, string valC, string valD)
        {
            try
            {
                string fovPath = Path.Combine(Application.StartupPath, fovFile);
                if (File.Exists(fovPath + ".bak"))
                {
                    File.Delete(fovPath + ".bak");
                }

                if (File.Exists(fovPath))
                {
                    File.Move(fovPath, fovPath + ".bak");
                }

                string[] fovLines = new string[4];

                fovLines[0] = valA;
                fovLines[1] = valB;
                fovLines[2] = valC;
                fovLines[3] = valD;

                File.WriteAllLines(fovPath, fovLines);

                lblSavedFOV.Visible = true;
                timSaveTimer.Enabled = true;
                timSaveTimer.Start();
            }
            catch
            {

            }
        }

        private void lstFOVPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstFOVPresets.SelectedIndex;

            lblPresetName.Text = "";
            lblPresetValues.Text = "";

            if (index > -1)
            {
                if (fovPresets.Count > index)
                {
                    lblPresetName.Text = fovNames[index];
                    lblPresetValues.Text = "A: " + fovVarAs[index] + " B: " + fovVarBs[index] + " C: " + fovVarCs[index] + " D: " + fovVarDs[index];
                }
            }
        }

        private void btnApplyPreset_Click(object sender, EventArgs e)
        {
            int index = lstFOVPresets.SelectedIndex;

            if (index > -1)
            {
                if (fovPresets.Count > index)
                {
                    WriteFOVValues(fovVarAs[index], fovVarBs[index], fovVarCs[index], fovVarDs[index]);
                }
            }
        }

        private void btnSaveCustomFOV_Click(object sender, EventArgs e)
        {
            WriteFOVValues(varA.Value.ToString(), varB.Value.ToString(), varC.Value.ToString(), varD.Value.ToString());
        }

        private void varA_ValueChanged(object sender, EventArgs e)
        {

        }

        private void varC_ValueChanged(object sender, EventArgs e)
        {

        }

        private void varB_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void varD_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
