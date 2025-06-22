using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assimilation
{
    public partial class frmScanIP : Form
    {
        public frmMain m_frmMain;

        public frmScanIP()
        {
            InitializeComponent();
        }

        private void ScanNetworkProgress()
        {
            toolStripProgressBar1.Increment(1);
        }

        void setup()
        {
            if (m_frmMain.m_stDeviceInfo.device == null)
            {
                MessageBox.Show("Null device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            comboBox1.Items.AddRange(new string[]
            {
                "ARP",
                "ICMP",
            });

            comboBox1.SelectedIndex = 0;
            numericUpDown1.Value = 20;

            radioButton1.Checked = true;

            textBox1.Text = m_frmMain.m_stDeviceInfo.IPv4Address;
            textBox2.Text = textBox1.Text;

            textBox3.Text = $"{textBox1.Text}/{IPTool.SubnetMask2CIDR(m_frmMain.m_stDeviceInfo.IPv4Mask)}";

            if (!Tools.IsMethodSubscribed(m_frmMain.ScanIpProgress, nameof(ScanNetworkProgress)))
                m_frmMain.ScanIpProgress += ScanNetworkProgress;
        }

        private void frmScanIP_Load(object sender, EventArgs e)
        {
            setup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nThreadCount = (int)numericUpDown1.Value;
            if (nThreadCount <= 0)
            {
                MessageBox.Show("Thread count must be larger than zero.", "Invalid ThreadCount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress ipStart = null;
            IPAddress ipEnd = null;

            if (radioButton1.Checked)
            {
                (ipStart, ipEnd) = IPTool.CIDR2IpRange(textBox3.Text);
            }
            else if (radioButton2.Checked)
            {
                ipStart = IPAddress.Parse(textBox1.Text);
                ipEnd = IPAddress.Parse(textBox2.Text);
            }

            if (ipStart == null || ipEnd == null)
            {
                return;
            }

            int nCount = (int)(IPTool.IPToUInt32(ipEnd) - IPTool.IPToUInt32(ipStart)) + 1;
            if (nCount <= 0)
            {

                return;
            }

            toolStripProgressBar1.Maximum = nCount;
            toolStripProgressBar1.Value = 0;



            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    m_frmMain.SendArpRequestWithIpRange(ipStart, ipEnd, m_frmMain.SendArpRequest, nThreadCount);
                    break;
                case 1:
                    m_frmMain.SendArpRequestWithIpRange(ipStart, ipEnd, m_frmMain.SendPingRequest, nThreadCount);
                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox3.Enabled = true;
                textBox1.Enabled = textBox2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox3.Enabled = false;
                textBox1.Enabled = textBox2.Enabled = true;
            }
        }

        private void frmScanIP_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Tools.IsMethodSubscribed(m_frmMain.ScanIpProgress, nameof(ScanNetworkProgress)))
                m_frmMain.ScanIpProgress -= ScanNetworkProgress;
        }
    }
}
