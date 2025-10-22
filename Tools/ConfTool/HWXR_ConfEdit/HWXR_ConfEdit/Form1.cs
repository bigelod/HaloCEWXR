using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HWXR_ConfEdit
{
    public partial class Form1 : Form
    {
        string fovFile = "fov.txt";
        string confFile = "config.txt";

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

        private void btnMetaQuest3_Click(object sender, EventArgs e)
        {
            WriteFOVValues("1.8", "0", "1.0", "0");
        }

        private void btnPico4_Click(object sender, EventArgs e)
        {
            WriteFOVValues("1.8", "0", "1.0", "0");
        }

        private void btnPico4Eco_Click(object sender, EventArgs e)
        {
            WriteFOVValues("1.2", "30", "0.8", "10");
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
    }
}
