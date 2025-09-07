using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace XrAPITestUDP
{
    public partial class Form1 : Form
    {
        string IPTarget = "127.0.0.1";
        int TransmitPort = 7872;

        UdpClient _TransmitClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            BuildDataPacket();

            if (chkAutoSendUDP.Checked)
            {
                SendUDPFrame();
            }
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
            chkAutoSendUDP.Checked = false;
        }

        private void txtRPos_TextChanged(object sender, EventArgs e)
        {
            chkAutoSendUDP.Checked = false;
        }

        private void txtHPos_TextChanged(object sender, EventArgs e)
        {
            chkAutoSendUDP.Checked = false;
        }

        private void txtIPDFOV_TextChanged(object sender, EventArgs e)
        {
            chkAutoSendUDP.Checked = false;
        }

        private void chkZeroThumbs_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

