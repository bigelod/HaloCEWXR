using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XrAPITestUDP
{
    public partial class Form1 : Form
    {
        string IPTarget = "127.0.0.1";
        int TransmitPort = 7872;

        private string inUDP;

        UdpClient _TransmitClient;

        bool keyWDown = false;
        bool keyADown = false;
        bool keySDown = false;
        bool keyDDown = false;
        bool keyIDown = false;
        bool keyJDown = false;
        bool keyKDown = false;
        bool keyLDown = false;
        bool key1Down = false;
        bool key2Down = false;
        bool key3Down = false;
        bool key4Down = false;
        bool key5Down = false;
        bool key6Down = false;
        bool key7Down = false;
        bool key8Down = false;
        bool key9Down = false;
        bool key0Down = false;
        bool keyYDown = false;
        bool keyNum8Down = false;
        bool keyNum4Down = false;
        bool keyNum5Down = false;
        bool keyNum6Down = false;
        bool keyNum7Down = false;
        bool keyNum9Down = false;
        bool keyQDown = false;
        bool keyEDown = false;
        bool keyZDown = false;
        bool keyXDown = false;
        bool keyCDown = false;
        bool readKeysWasChecked = false;

        private float moveSpd = 1.0f / 72.0f;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            tbOXRFrameId.ValueChanged += tbOXRFrameId_ValueChanged;

            chkLGRIP.MouseLeave += chkLGRIP_MouseLeave;
            chkLMENU.MouseLeave += chkLMENU_MouseLeave;
            chkLTHUMBCLICK.MouseLeave += chkLTHUMBCLICK_MouseLeave;
            chkLTHUMBLEFT.MouseLeave += chkLTHUMBLEFT_MouseLeave;
            chkLTHUMBRIGHT.MouseLeave += chkLTHUMBRIGHT_MouseLeave;
            chkLTHUMBUP.MouseLeave += chkLTHUMBUP_MouseLeave;
            chkLTHUMBDOWN.MouseLeave += chkLTHUMBDOWN_MouseLeave;
            chkLTRIGGER.MouseLeave += chkLTRIGGER_MouseLeave;
            chkLX.MouseLeave += chkLX_MouseLeave;
            chkLY.MouseLeave += chkLY_MouseLeave;
            chkRA.MouseLeave += chkRA_MouseLeave;
            chkRB.MouseLeave += chkRB_MouseLeave;
            chkRGRIP.MouseLeave += chkRGRIP_MouseLeave;
            chkRTHUMBCLICK.MouseLeave += chkRTHUMBCLICK_MouseLeave;
            chkRTHUMBLEFT.MouseLeave += chkRTHUMBLEFT_MouseLeave;
            chkRTHUMBRIGHT.MouseLeave += chkRTHUMBRIGHT_MouseLeave;
            chkRTHUMBUP.MouseLeave += chkRTHUMBUP_MouseLeave;
            chkRTHUMBDOWN.MouseLeave += chkRTHUMBDOWN_MouseLeave;
            chkRTRIGGER.MouseLeave += chkRTRIGGER_MouseLeave;

            tbLTX.MouseUp += tbLTX_MouseUp;
            tbLTY.MouseUp += tbLTY_MouseUp;

            tbLTX.ValueChanged += tbLTX_ValueChanged;
            tbLTY.ValueChanged += tbLTY_ValueChanged;

            tbLQX.ValueChanged += tbLQX_ValueChanged;
            tbLQY.ValueChanged += tbLQY_ValueChanged;
            tbLQZ.ValueChanged += tbLQZ_ValueChanged;
            tbLQW.ValueChanged += tbLQW_ValueChanged;

            tbRTX.MouseUp += tbRTX_MouseUp;
            tbRTY.MouseUp += tbRTY_MouseUp;

            tbRTX.ValueChanged += tbRTX_ValueChanged;
            tbRTY.ValueChanged += tbRTY_ValueChanged;

            tbRQX.ValueChanged += tbRQX_ValueChanged;
            tbRQY.ValueChanged += tbRQY_ValueChanged;
            tbRQZ.ValueChanged += tbRQZ_ValueChanged;
            tbRQW.ValueChanged += tbRQW_ValueChanged;

            tbHQX.ValueChanged += tbHQX_ValueChanged;
            tbHQY.ValueChanged += tbHQY_ValueChanged;
            tbHQZ.ValueChanged += tbHQZ_ValueChanged;
            tbHQW.ValueChanged += tbHQW_ValueChanged;

            _TransmitClient = new UdpClient();

            //Default the orientation data at start
            tbLQX.Value = 21;
            tbLQY.Value = 29;
            tbLQZ.Value = -93;
            tbLQW.Value = 4;

            tbRQX.Value = 10;
            tbRQY.Value = -30;
            tbRQZ.Value = 95;
            tbRQW.Value = -8;

            tbHQX.Value = 15;
            tbHQY.Value = -7;
            tbHQZ.Value = 5;
            tbHQW.Value = 99;
        }

        private void Form1_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemCloseBrackets)
            {
                chkReadKeys.Checked = !chkReadKeys.Checked;
            }
            else if (e.KeyCode == Keys.OemOpenBrackets)
            {
                chkAlwaysOnTop.Checked = !chkAlwaysOnTop.Checked;
            }
            else if (chkReadKeys.Checked)
            {
                if (e.KeyCode == Keys.W)
                {
                    keyWDown = false;
                }
                else if (e.KeyCode == Keys.A)
                {
                    keyADown = false;
                }
                else if (e.KeyCode == Keys.S)
                {
                    keySDown = false;
                }
                else if (e.KeyCode == Keys.D)
                {
                    keyDDown = false;
                }
                else if (e.KeyCode == Keys.I)
                {
                    keyIDown = false;
                }
                else if (e.KeyCode == Keys.J)
                {
                    keyJDown = false;
                }
                else if (e.KeyCode == Keys.K)
                {
                    keyKDown = false;
                }
                else if (e.KeyCode == Keys.L)
                {
                    keyLDown = false;
                }
                else if (e.KeyCode == Keys.D1)
                {
                    key1Down = false;
                }
                else if (e.KeyCode == Keys.D2)
                {
                    key2Down = false;
                }
                else if (e.KeyCode == Keys.D3)
                {
                    key3Down = false;
                }
                else if (e.KeyCode == Keys.D4)
                {
                    key4Down = false;
                }
                else if (e.KeyCode == Keys.D5)
                {
                    key5Down = false;
                }
                else if (e.KeyCode == Keys.D6)
                {
                    key6Down = false;
                }
                else if (e.KeyCode == Keys.D7)
                {
                    key7Down = false;
                }
                else if (e.KeyCode == Keys.D8)
                {
                    key8Down = false;
                }
                else if (e.KeyCode == Keys.D9)
                {
                    key9Down = false;
                }
                else if (e.KeyCode == Keys.D0)
                {
                    key0Down = false;
                }
                else if (e.KeyCode == Keys.Y)
                {
                    keyYDown = false;
                }
                else if (e.KeyCode == Keys.NumPad8)
                {
                    keyNum8Down = false;
                }
                else if (e.KeyCode == Keys.NumPad4)
                {
                    keyNum4Down = false;
                }
                else if (e.KeyCode == Keys.NumPad5)
                {
                    keyNum5Down = false;
                }
                else if (e.KeyCode == Keys.NumPad6)
                {
                    keyNum6Down = false;
                }
                else if (e.KeyCode == Keys.NumPad7)
                {
                    keyNum7Down = false;
                }
                else if (e.KeyCode == Keys.NumPad9)
                {
                    keyNum9Down = false;
                }
                else if (e.KeyCode == Keys.E)
                {
                    keyEDown = false;
                }
                else if (e.KeyCode == Keys.Q)
                {
                    keyQDown = false;
                }
                else if (e.KeyCode == Keys.Z)
                {
                    keyZDown = false;
                }
                else if (e.KeyCode == Keys.X)
                {
                    keyXDown = false;
                }
                else if (e.KeyCode == Keys.C)
                {
                    keyCDown = false;
                }
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (chkReadKeys.Checked)
            {
                if (e.KeyCode == Keys.W)
                {
                    keyWDown = true;
                }
                else if (e.KeyCode == Keys.A)
                {
                    keyADown = true;
                }
                else if (e.KeyCode == Keys.S)
                {
                    keySDown = true;
                }
                else if (e.KeyCode == Keys.D)
                {
                    keyDDown = true;
                }
                else if (e.KeyCode == Keys.I)
                {
                    keyIDown = true;
                }
                else if (e.KeyCode == Keys.J)
                {
                    keyJDown = true;
                }
                else if (e.KeyCode == Keys.K)
                {
                    keyKDown = true;
                }
                else if (e.KeyCode == Keys.L)
                {
                    keyLDown = true;
                }
                else if (e.KeyCode == Keys.D1)
                {
                    key1Down = true;
                }
                else if (e.KeyCode == Keys.D2)
                {
                    key2Down = true;
                }
                else if (e.KeyCode == Keys.D3)
                {
                    key3Down = true;
                }
                else if (e.KeyCode == Keys.D4)
                {
                    key4Down = true;
                }
                else if (e.KeyCode == Keys.D5)
                {
                    key5Down = true;
                }
                else if (e.KeyCode == Keys.D6)
                {
                    key6Down = true;
                }
                else if (e.KeyCode == Keys.D7)
                {
                    key7Down = true;
                }
                else if (e.KeyCode == Keys.D8)
                {
                    key8Down = true;
                }
                else if (e.KeyCode == Keys.D9)
                {
                    key9Down = true;
                }
                else if (e.KeyCode == Keys.D0)
                {
                    key0Down = true;
                }
                else if (e.KeyCode == Keys.Y)
                {
                    keyYDown = true;
                }
                else if (e.KeyCode == Keys.NumPad8)
                {
                    keyNum8Down = true;
                }
                else if (e.KeyCode == Keys.NumPad4)
                {
                    keyNum4Down = true;
                }
                else if (e.KeyCode == Keys.NumPad5)
                {
                    keyNum5Down = true;
                }
                else if (e.KeyCode == Keys.NumPad6)
                {
                    keyNum6Down = true;
                }
                else if (e.KeyCode == Keys.NumPad7)
                {
                    keyNum7Down = true;
                }
                else if (e.KeyCode == Keys.NumPad9)
                {
                    keyNum9Down = true;
                }
                else if (e.KeyCode == Keys.E)
                {
                    keyEDown = true;
                }
                else if (e.KeyCode == Keys.Q)
                {
                    keyQDown = true;
                }
                else if (e.KeyCode == Keys.Z)
                {
                    keyZDown = true;
                }
                else if (e.KeyCode == Keys.X)
                {
                    keyXDown = true;
                }
                else if (e.KeyCode == Keys.C)
                {
                    keyCDown = true;
                }
            }
        }

        private void chkRTRIGGER_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRTRIGGER.Checked = false;
        }

        private void chkRTHUMBDOWN_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRTHUMBDOWN.Checked = false;
        }

        private void chkRTHUMBUP_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRTHUMBUP.Checked = false;
        }

        private void chkRTHUMBRIGHT_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRTHUMBRIGHT.Checked = false;
        }

        private void chkRTHUMBLEFT_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRTHUMBLEFT.Checked = false;
        }

        private void chkRTHUMBCLICK_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRTHUMBCLICK.Checked = false;
        }

        private void chkRGRIP_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRGRIP.Checked = false;
        }

        private void chkRB_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRB.Checked = false;
        }

        private void chkRA_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkRA.Checked = false;
        }

        private void chkLY_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLY.Checked = false;
        }

        private void chkLX_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLX.Checked = false;
        }

        private void chkLTRIGGER_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLTRIGGER.Checked = false;
        }

        private void chkLTHUMBDOWN_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLTHUMBDOWN.Checked = false;
        }

        private void chkLTHUMBUP_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLTHUMBUP.Checked = false;
        }

        private void chkLTHUMBRIGHT_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLTHUMBRIGHT.Checked = false;
        }

        private void chkLTHUMBLEFT_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLTHUMBLEFT.Checked = false;
        }

        private void chkLTHUMBCLICK_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLTHUMBCLICK.Checked = false;
        }

        private void chkLMENU_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLMENU.Checked = false;
        }

        private void chkLGRIP_MouseLeave(object? sender, EventArgs e)
        {
            if (chkReleaseBtnOnMouseUp.Checked) chkLGRIP.Checked = false;
        }

        private void tbLTX_MouseUp(object? sender, MouseEventArgs e)
        {
            if (chkZeroThumbs.Checked) tbLTX.Value = 0;
        }

        private void tbLTY_MouseUp(object? sender, MouseEventArgs e)
        {
            if (chkZeroThumbs.Checked) tbLTY.Value = 0;
        }

        private void tbRTX_MouseUp(object? sender, MouseEventArgs e)
        {
            if (chkZeroThumbs.Checked) tbRTX.Value = 0;
        }

        private void tbRTY_MouseUp(object? sender, MouseEventArgs e)
        {
            if (chkZeroThumbs.Checked) tbRTY.Value = 0;
        }

        private void tbLTX_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbLTX, lblLTX);
        }

        private void tbLTY_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbLTY, lblLTY);
        }

        private void tbLQX_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbLQX, lblLQX);
        }

        private void tbLQY_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbLQY, lblLQY);
        }

        private void tbLQZ_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbLQZ, lblLQZ);
        }

        private void tbLQW_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbLQW, lblLQW);
        }

        private void tbRTX_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbRTX, lblRTX);
        }

        private void tbRTY_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbRTY, lblRTY);
        }

        private void tbRQX_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbRQX, lblRQX);
        }

        private void tbRQY_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbRQY, lblRQY);
        }

        private void tbRQZ_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbRQZ, lblRQZ);
        }

        private void tbRQW_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbRQW, lblRQW);
        }

        private void tbHQX_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbHQX, lblHMDQX);
        }

        private void tbHQY_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbHQY, lblHMDQY);
        }

        private void tbHQZ_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbHQZ, lblHMDQZ);
        }

        private void tbHQW_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTBLabel(tbHQW, lblHMDQW);
        }

        void UpdateTBLabel(TrackBar bar, Label lbl)
        {
            if (lbl != null && bar != null)
            {
                string[] originalText = lbl.Text.Split(':');

                if (originalText.Length > 0)
                {
                    string newText = originalText[0] + ": " + (bar.Value * 0.01f).ToString("0.000");

                    lbl.Text = newText;
                }
            }
        }

        private void tbOXRFrameId_ValueChanged(object? sender, EventArgs e)
        {
            lblOXRFrameId.Text = "OpenXR Frame ID: " + tbOXRFrameId.Value.ToString();
        }

        private void btnApplyIP_Click(object sender, EventArgs e)
        {
            if (txtTargetIP.Text != "")
            {
                btnApplyIP.Enabled = false;

                lblDataSending.Text = "SENDING DATA TO " + txtTargetIP.Text;

                IPTarget = txtTargetIP.Text.Replace("localhost", "127.0.0.1");
            }
        }

        private void chkAutoSendUDP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSendFrame_Click(object sender, EventArgs e)
        {
            BuildDataPacket();

            SendUDPFrame();
        }

        private void timSendInterval_Tick(object sender, EventArgs e)
        {
            this.TopMost = chkAlwaysOnTop.Checked;

            if (chkAutoIncrementFrameId.Checked)
            {
                if (tbOXRFrameId.Value < 255)
                {
                    tbOXRFrameId.Value += 1;
                }
                else
                {
                    tbOXRFrameId.Value = 0;
                }
            }

            if (chkReadKeys.Checked)
            {
                if (keyWDown)
                {
                    tbLTY.Value = tbLTY.Maximum;

                    chkLTHUMBUP.Checked = true;
                    chkLTHUMBDOWN.Checked = false;
                }
                else if (keySDown)
                {
                    tbLTY.Value = tbLTY.Minimum;

                    chkLTHUMBUP.Checked = false;
                    chkLTHUMBDOWN.Checked = true;
                }
                else
                {
                    tbLTY.Value = 0;

                    chkLTHUMBUP.Checked = false;
                    chkLTHUMBDOWN.Checked = false;
                }

                if (keyADown)
                {
                    tbLTX.Value = tbLTX.Minimum;

                    chkLTHUMBLEFT.Checked = true;
                    chkLTHUMBRIGHT.Checked = false;
                }
                else if (keyDDown)
                {
                    tbLTX.Value = tbLTX.Maximum;

                    chkLTHUMBLEFT.Checked = false;
                    chkLTHUMBRIGHT.Checked = true;
                }
                else
                {
                    tbLTX.Value = 0;

                    chkLTHUMBLEFT.Checked = false;
                    chkLTHUMBRIGHT.Checked = false;
                }

                if (keyIDown)
                {
                    tbRTY.Value = tbRTY.Maximum;

                    chkRTHUMBUP.Checked = true;
                    chkRTHUMBDOWN.Checked = false;
                }
                else if (keyKDown)
                {
                    tbRTY.Value = tbRTY.Minimum;

                    chkRTHUMBUP.Checked = false;
                    chkRTHUMBDOWN.Checked = true;
                }
                else
                {
                    tbRTY.Value = 0;

                    chkRTHUMBUP.Checked = false;
                    chkRTHUMBDOWN.Checked = false;
                }

                if (keyJDown)
                {
                    tbRTX.Value = tbRTX.Minimum;

                    chkRTHUMBLEFT.Checked = true;
                    chkRTHUMBRIGHT.Checked = false;
                }
                else if (keyLDown)
                {
                    tbRTX.Value = tbRTX.Maximum;

                    chkRTHUMBLEFT.Checked = false;
                    chkRTHUMBRIGHT.Checked = true;
                }
                else
                {
                    tbRTX.Value = 0;

                    chkRTHUMBLEFT.Checked = false;
                    chkRTHUMBRIGHT.Checked = false;
                }

                if (keyEDown)
                {
                    if (keyNum8Down)
                    {
                        if (tbHQX.Value < tbHQX.Maximum) tbHQX.Value += 1;
                    }
                    else if (keyNum5Down)
                    {
                        if (tbHQX.Value > tbHQX.Minimum) tbHQX.Value -= 1;
                    }

                    if (keyNum4Down)
                    {
                        if (tbHQY.Value < tbHQY.Maximum) tbHQY.Value += 1;
                    }
                    else if (keyNum6Down)
                    {
                        if (tbHQY.Value > tbHQY.Minimum) tbHQY.Value -= 1;
                    }

                    if (keyNum7Down)
                    {
                        if (tbHQZ.Value < tbHQZ.Maximum) tbHQZ.Value += 1;
                    }
                    else if (keyNum9Down)
                    {
                        if (tbHQZ.Value > tbHQZ.Minimum) tbHQZ.Value -= 1;
                    }
                }
                else if (keyQDown)
                {
                    if (keyNum8Down)
                    {
                        if (tbLQY.Value < tbLQY.Maximum) tbLQY.Value += 1;
                    }
                    else if (keyNum5Down)
                    {
                        if (tbLQY.Value > tbLQY.Minimum) tbLQY.Value -= 1;
                    }

                    if (keyNum4Down)
                    {
                        if (tbLQX.Value > tbLQX.Minimum) tbLQX.Value -= 1;
                    }
                    else if (keyNum6Down)
                    {
                        if (tbLQX.Value < tbLQX.Maximum) tbLQX.Value += 1;
                    }

                    if (keyNum7Down)
                    {
                        if (tbLQW.Value < tbLQW.Maximum) tbLQW.Value += 1;
                    }
                    else if (keyNum9Down)
                    {
                        if (tbLQW.Value > tbLQW.Minimum) tbLQW.Value -= 1;
                    }
                }
                else if (keyZDown)
                {
                    if (keyNum8Down)
                    {
                        txtRPos.Text = ModifyPosString(txtRPos.Text, 2, -1.0f);
                    }
                    else if (keyNum5Down)
                    {
                        txtRPos.Text = ModifyPosString(txtRPos.Text, 2, 1.0f);
                    }

                    if (keyNum4Down)
                    {
                        txtRPos.Text = ModifyPosString(txtRPos.Text, 0, -1.0f);
                    }
                    else if (keyNum6Down)
                    {
                        txtRPos.Text = ModifyPosString(txtRPos.Text, 0, 1.0f);
                    }

                    if (keyNum7Down)
                    {
                        txtRPos.Text = ModifyPosString(txtRPos.Text, 1, -1.0f);
                    }
                    else if (keyNum9Down)
                    {
                        txtRPos.Text = ModifyPosString(txtRPos.Text, 1, 1.0f);
                    }
                }
                else if (keyXDown)
                {
                    if (keyNum8Down)
                    {
                        txtLPos.Text = ModifyPosString(txtLPos.Text, 2, -1.0f);
                    }
                    else if (keyNum5Down)
                    {
                        txtLPos.Text = ModifyPosString(txtLPos.Text, 2, 1.0f);
                    }

                    if (keyNum4Down)
                    {
                        txtLPos.Text = ModifyPosString(txtLPos.Text, 0, -1.0f);
                    }
                    else if (keyNum6Down)
                    {
                        txtLPos.Text = ModifyPosString(txtLPos.Text, 0, 1.0f);
                    }

                    if (keyNum7Down)
                    {
                        txtLPos.Text = ModifyPosString(txtLPos.Text, 1, -1.0f);
                    }
                    else if (keyNum9Down)
                    {
                        txtLPos.Text = ModifyPosString(txtLPos.Text, 1, 1.0f);
                    }
                }
                else if (keyCDown)
                {
                    if (keyNum8Down)
                    {
                        txtHPos.Text = ModifyPosString(txtHPos.Text, 2, -1.0f);
                    }
                    else if (keyNum5Down)
                    {
                        txtHPos.Text = ModifyPosString(txtHPos.Text, 2, 1.0f);
                    }

                    if (keyNum4Down)
                    {
                        txtHPos.Text = ModifyPosString(txtHPos.Text, 0, -1.0f);
                    }
                    else if (keyNum6Down)
                    {
                        txtHPos.Text = ModifyPosString(txtHPos.Text, 0, 1.0f);
                    }

                    if (keyNum7Down)
                    {
                        txtHPos.Text = ModifyPosString(txtHPos.Text, 1, -1.0f);
                    }
                    else if (keyNum9Down)
                    {
                        txtHPos.Text = ModifyPosString(txtHPos.Text, 1, 1.0f);
                    }
                }
                else
                {
                    if (keyNum8Down)
                    {
                        if (tbRQY.Value > tbRQY.Minimum) tbRQY.Value -= 1;
                    }
                    else if (keyNum5Down)
                    {
                        if (tbRQY.Value < tbRQY.Maximum) tbRQY.Value += 1;
                    }

                    if (keyNum4Down)
                    {
                        if (tbRQX.Value < tbRQX.Maximum) tbRQX.Value += 1;
                    }
                    else if (keyNum6Down)
                    {
                        if (tbRQX.Value > tbRQX.Minimum) tbRQX.Value -= 1;
                    }

                    if (keyNum7Down)
                    {
                        if (tbRQW.Value > tbRQW.Minimum) tbRQW.Value -= 1;
                    }
                    else if (keyNum9Down)
                    {
                        if (tbRQW.Value < tbRQW.Maximum) tbRQW.Value += 1;
                    }
                }

                chkLTRIGGER.Checked = key1Down;
                chkLGRIP.Checked = key2Down;
                chkRTRIGGER.Checked = key3Down;
                chkRGRIP.Checked = key4Down;

                chkLTHUMBCLICK.Checked = key5Down;
                chkRTHUMBCLICK.Checked = key6Down;

                chkLX.Checked = key7Down;
                chkLY.Checked = key8Down;
                chkRB.Checked = key9Down;
                chkRA.Checked = key0Down;

                chkLMENU.Checked = keyYDown;

                readKeysWasChecked = true;
            }
            else
            {
                keyWDown = false;
                keyADown = false;
                keySDown = false;
                keyDDown = false;
                keyIDown = false;
                keyJDown = false;
                keyKDown = false;
                keyLDown = false;
                key1Down = false;
                key2Down = false;
                key3Down = false;
                key4Down = false;
                key5Down = false;
                key6Down = false;
                key7Down = false;
                key8Down = false;
                key9Down = false;
                key0Down = false;
                keyYDown = false;
                keyNum8Down = false;
                keyNum4Down = false;
                keyNum5Down = false;
                keyNum6Down = false;
                keyNum7Down = false;
                keyNum9Down = false;
                keyEDown = false;
                keyQDown = false;
                keyZDown = false;
                keyXDown = false;
                keyZDown = false;

                if (readKeysWasChecked)
                {
                    chkLTRIGGER.Checked = false;
                    chkLGRIP.Checked = false;
                    chkRTRIGGER.Checked = false;
                    chkRGRIP.Checked = false;
                    chkLX.Checked = false;
                    chkLY.Checked = false;
                    chkRB.Checked = false;
                    chkRA.Checked = false;
                    chkLTHUMBCLICK.Checked = false;
                    chkRTHUMBCLICK.Checked = false;

                    chkLTHUMBUP.Checked = false;
                    chkLTHUMBLEFT.Checked = false;
                    chkLTHUMBDOWN.Checked = false;
                    chkLTHUMBRIGHT.Checked = false;
                    chkRTHUMBUP.Checked = false;
                    chkRTHUMBLEFT.Checked = false;
                    chkRTHUMBDOWN.Checked = false;
                    chkRTHUMBRIGHT.Checked = false;

                    chkLMENU.Checked = false;

                    tbLTX.Value = 0;
                    tbLTY.Value = 0;
                    tbRTX.Value = 0;
                    tbRTY.Value = 0;
                    readKeysWasChecked = false;
                }
            }

            BuildDataPacket();

            if (chkAutoSendUDP.Checked)
            {
                SendUDPFrame();
            }
        }

        private string ModifyPosString(string posString, int axis, float dir)
        {
            string ans = "";

            string[] parts = posString.Split(" ");

            if (parts.Length != 3) return posString;

            float modPart = 0f;

            float.TryParse(parts[axis], System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out modPart);

            modPart += dir * moveSpd;

            switch (axis)
            {
                case 0:
                    ans = modPart.ToString() + " " + parts[1] + " " + parts[2];
                    break;
                case 1:
                    ans = parts[0] + " " + modPart.ToString() + " " + parts[2];
                    break;
                case 2:
                    ans = parts[0] + " " + parts[1] + " " + modPart.ToString();
                    break;
            }

            return ans;
        }

        private void BuildDataPacket()
        {
            string newUDPData = "client0";

            //Add the float values

            newUDPData += " " + (tbLQX.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbLQY.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbLQZ.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbLQW.Value * 0.01f).ToString("0.000");

            newUDPData += " " + (tbLTX.Value * 0.01f).ToString("0.0");
            newUDPData += " " + (tbLTY.Value * 0.01f).ToString("0.0");

            string[] LPos = txtLPos.Text.Split(' ');

            if (LPos.Length == 3)
            {
                newUDPData += " " + txtLPos.Text;
            }
            else
            {
                //Invalid line, use example data
                newUDPData += " -0.008 -0.229 -0.173";
            }

            newUDPData += " " + (tbRQX.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbRQY.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbRQZ.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbRQW.Value * 0.01f).ToString("0.000");

            newUDPData += " " + (tbRTX.Value * 0.01f).ToString("0.0");
            newUDPData += " " + (tbRTY.Value * 0.01f).ToString("0.0");

            string[] RPos = txtRPos.Text.Split(' ');

            if (RPos.Length == 3)
            {
                newUDPData += " " + txtRPos.Text;
            }
            else
            {
                //Invalid line, use example data
                newUDPData += " 0.154 -0.240 -0.140";
            }

            newUDPData += " " + (tbHQX.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbHQY.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbHQZ.Value * 0.01f).ToString("0.000");
            newUDPData += " " + (tbHQW.Value * 0.01f).ToString("0.000");

            string[] HPos = txtHPos.Text.Split(' ');

            if (HPos.Length == 3)
            {
                newUDPData += " " + txtHPos.Text;
            }
            else
            {
                //Invalid line, use example data
                newUDPData += " 0.037 0.006 -0.017";
            }

            string[] IPDFOV = txtIPDFOV.Text.Split(' ');

            if (IPDFOV.Length == 3)
            {
                newUDPData += " " + txtIPDFOV.Text;
            }
            else
            {
                //Invalid line, use example data
                newUDPData += " 0.0678 99.00 103.40";
            }

            //Add OpenXR Frame ID
            newUDPData += " " + tbOXRFrameId.Value.ToString();

            //Add the button bools
            newUDPData += " " + (chkLGRIP.Checked ? "T" : "F");
            newUDPData += (chkLMENU.Checked ? "T" : "F");
            newUDPData += (chkLTHUMBCLICK.Checked ? "T" : "F");
            newUDPData += (chkLTHUMBLEFT.Checked ? "T" : "F");
            newUDPData += (chkLTHUMBRIGHT.Checked ? "T" : "F");
            newUDPData += (chkLTHUMBUP.Checked ? "T" : "F");
            newUDPData += (chkLTHUMBDOWN.Checked ? "T" : "F");
            newUDPData += (chkLTRIGGER.Checked ? "T" : "F");
            newUDPData += (chkLX.Checked ? "T" : "F");
            newUDPData += (chkLY.Checked ? "T" : "F");
            newUDPData += (chkRA.Checked ? "T" : "F");
            newUDPData += (chkRB.Checked ? "T" : "F");
            newUDPData += (chkRGRIP.Checked ? "T" : "F");
            newUDPData += (chkRTHUMBCLICK.Checked ? "T" : "F");
            newUDPData += (chkRTHUMBLEFT.Checked ? "T" : "F");
            newUDPData += (chkRTHUMBRIGHT.Checked ? "T" : "F");
            newUDPData += (chkRTHUMBUP.Checked ? "T" : "F");
            newUDPData += (chkRTHUMBDOWN.Checked ? "T" : "F");
            newUDPData += (chkRTRIGGER.Checked ? "T" : "F");

            //Add HMD
            newUDPData += " " + txtHMD.Text;

            txtSentData.Text = newUDPData;
        }

        private void SendUDPFrame()
        {
            try
            {
                lblDataSending.Visible = true;
                timHideSendTxt.Enabled = true;
                timHideSendTxt.Start();

                byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(txtSentData.Text);

                _TransmitClient.Send(serverMessageAsByteArray, serverMessageAsByteArray.Length, new IPEndPoint(IPAddress.Parse(IPTarget), TransmitPort));
            }
            catch
            {

            }
        }

        private void btnCopyUDPData_Click(object sender, EventArgs e)
        {
            if (txtSentData.Text != "")
            {
                Clipboard.SetText(txtSentData.Text);
            }
        }

        private void tbOXRFrameId_Scroll(object sender, EventArgs e)
        {

        }

        private void chkAutoIncrementFrameId_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timHideSendTxt_Tick(object sender, EventArgs e)
        {
            lblDataSending.Visible = false;
            timHideSendTxt.Stop();
            timHideSendTxt.Enabled = false;
        }

        private void txtTargetIP_TextChanged(object sender, EventArgs e)
        {
            if (txtTargetIP.Text != "")
            {
                btnApplyIP.Enabled = true;
            }
        }

        private void txtLPos_TextChanged(object sender, EventArgs e)
        {
            if (txtLPos.Text.Split(' ').Length != 3) chkAutoSendUDP.Checked = false;
        }

        private void txtRPos_TextChanged(object sender, EventArgs e)
        {
            if (txtRPos.Text.Split(' ').Length != 3) chkAutoSendUDP.Checked = false;
        }

        private void txtHPos_TextChanged(object sender, EventArgs e)
        {
            if (txtHPos.Text.Split(' ').Length != 3) chkAutoSendUDP.Checked = false;
        }

        private void txtIPDFOV_TextChanged(object sender, EventArgs e)
        {
            if (txtIPDFOV.Text.Split(' ').Length != 3) chkAutoSendUDP.Checked = false;
        }

        private void chkZeroThumbs_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void SetInputUDP(string data = "")
        {
            inUDP = data;
        }

        private void btnImportUDP_Click(object sender, EventArgs e)
        {
            inUDP = "";

            Form2 inputUDP = new Form2();
            inputUDP.SetReturnDataAction(SetInputUDP);
            inputUDP.ShowDialog(this);
            inputUDP.Dispose();

            if (inUDP == null || inUDP == "") return;

            string[] parts = inUDP.Split(' ');

            string btnbools = "";

            int i = 1;
            int maxParts = parts.Length - 1;

            if (maxParts >= i) tbLQX.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbLQY.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbLQZ.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbLQW.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbLTX.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbLTY.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));

            txtLPos.Text = "";

            i++;
            if (maxParts >= i) txtLPos.Text = parts[i];
            i++;
            if (maxParts >= i) txtLPos.Text += " " + parts[i];
            i++;
            if (maxParts >= i) txtLPos.Text += " " + parts[i];

            i++;
            if (maxParts >= i) tbRQX.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbRQY.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbRQZ.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbRQW.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbRTX.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbRTY.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));


            txtRPos.Text = "";

            i++;
            if (maxParts >= i) txtRPos.Text = parts[i];
            i++;
            if (maxParts >= i) txtRPos.Text += " " + parts[i];
            i++;
            if (maxParts >= i) txtRPos.Text += " " + parts[i];

            i++;
            if (maxParts >= i) tbHQX.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbHQY.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbHQZ.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));
            i++;
            if (maxParts >= i) tbHQW.Value = (int)Math.Round(100.0f * TryParseStr(parts[i]));

            txtHPos.Text = "";

            i++;
            if (maxParts >= i) txtHPos.Text = parts[i];
            i++;
            if (maxParts >= i) txtHPos.Text += " " + parts[i];
            i++;
            if (maxParts >= i) txtHPos.Text += " " + parts[i];

            txtIPDFOV.Text = "";

            i++;
            if (maxParts >= i) txtIPDFOV.Text = parts[i];
            i++;
            if (maxParts >= i) txtIPDFOV.Text += " " + parts[i];
            i++;
            if (maxParts >= i) txtIPDFOV.Text += " " + parts[i];
            i++;
            if (maxParts >= i) tbOXRFrameId.Value = TryParseStrToInt(parts[i]);
            i++;
            if (maxParts >= i) btnbools = parts[i];
            i++;
            if (maxParts >= i) txtHMD.Text = parts[i];

            if (btnbools != "")
            {
                chkLGRIP.Checked = ParseBtnBool(btnbools, 0);
                chkLMENU.Checked = ParseBtnBool(btnbools, 1);
                chkLTHUMBCLICK.Checked = ParseBtnBool(btnbools, 2);
                chkLTHUMBLEFT.Checked = ParseBtnBool(btnbools, 3);
                chkLTHUMBRIGHT.Checked = ParseBtnBool(btnbools, 4);
                chkLTHUMBUP.Checked = ParseBtnBool(btnbools, 5);
                chkLTHUMBDOWN.Checked = ParseBtnBool(btnbools, 6);
                chkLTRIGGER.Checked = ParseBtnBool(btnbools, 7);
                chkLX.Checked = ParseBtnBool(btnbools, 8);
                chkLY.Checked = ParseBtnBool(btnbools, 9);
                chkRA.Checked = ParseBtnBool(btnbools, 10);
                chkRB.Checked = ParseBtnBool(btnbools, 11);
                chkRGRIP.Checked = ParseBtnBool(btnbools, 12);
                chkRTHUMBCLICK.Checked = ParseBtnBool(btnbools, 13);
                chkRTHUMBLEFT.Checked = ParseBtnBool(btnbools, 14);
                chkRTHUMBRIGHT.Checked = ParseBtnBool(btnbools, 15);
                chkRTHUMBUP.Checked = ParseBtnBool(btnbools, 16);
                chkRTHUMBDOWN.Checked = ParseBtnBool(btnbools, 17);
                chkRTRIGGER.Checked = ParseBtnBool(btnbools, 18);
            }
        }

        private float TryParseStr(string str)
        {
            float ans = 0f;

            float.TryParse(str, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out ans);

            return ans;
        }

        private int TryParseStrToInt(string str)
        {
            int ans = 0;

            int.TryParse(str, out ans);

            return ans;
        }

        private bool ParseBtnBool(string boolstring, int index)
        {
            if (boolstring.Length > index && boolstring.ToUpper().Substring(index, 1) == "T")
            {
                return true;
            }

            return false;
        }

        private void chkReadKeys_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnKeyEmulationControls_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(Application.StartupPath, "XrAPITestUDPEmulatedControls.png"));
        }
    }
}

