using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rtaNetworking.Streaming;
using System.Net;

namespace rtaVideoStreamer
{
    public partial class Form1 : Form
    {

        private ImageStreamingServer _Server;

        public Form1()
        {
            InitializeComponent();
            this.linkLabel1.Text = string.Format("http://{0}:8080", Environment.MachineName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Server = new ImageStreamingServer();
            _Server.Start(8080);
            this.Hide();
        }

        private DateTime time = DateTime.MinValue;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int count = (_Server.Clients != null) ? _Server.Clients.Count() : 0;

            this.sts.Text = "Clients: " + count.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", this.linkLabel1.Text);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
