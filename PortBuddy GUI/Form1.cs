using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace $safeprojectname$
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string option = "";
        string extraoption = "";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string address = "https://github.com/amak-tech/port-buddy/releases/download/1.0.13/portbuddy-windows-x64.exe";
                string text = Path.Combine(Application.StartupPath, "portbuddycli.exe");
                if (File.Exists(text))
                {
                    File.Delete(text);
                }
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(address, text);
                }
                Process.Start(text, "init " + textBox1.Text); // authorize ur token
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message); // show an error
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            option = textBox2.Text;
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Select a protocol.");
                return;
            }

            try
            {
                string address = "https://github.com/amak-tech/port-buddy/releases/download/1.0.13/portbuddy-windows-x64.exe";
                string text = Path.Combine(Application.StartupPath, "portbuddycli.exe");
                if (File.Exists(text))
                {
                    File.Delete(text);
                }
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(address, text);
                }
                if (checkBox1.Checked) option = "http ";
                else if (checkBox2.Checked) option = "tcp ";
                else if (checkBox3.Checked) option = "udp ";

                string args = extraoption + option + textBox2.Text;

                Process.Start(text, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download failed: " + ex.Message);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            option = "http ";
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            option = "tcp ";
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            option = "udp ";
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            extraoption = "-n ";
            if (checkBox4.Checked)
            {
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            extraoption = string.Empty;
            if (checkBox6.Checked)
            {
                checkBox5.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            extraoption = "--verbose ";
            if (checkBox5.Checked)
            {
                checkBox6.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
