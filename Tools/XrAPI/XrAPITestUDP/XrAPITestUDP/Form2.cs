using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrAPITestUDP
{
    public partial class Form2 : Form
    {
        Action<string> dataAct;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string clipText = Clipboard.GetText();

            if (clipText != null && clipText != "" && clipText.Contains("client0"))
            {
                txtUDPIn.Text = clipText;
            }
        }

        public void SetReturnDataAction(Action<string> act)
        {
            dataAct = act;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataAct != null)
            {
                dataAct.Invoke(txtUDPIn.Text);
            }

            Close();
        }
    }
}
