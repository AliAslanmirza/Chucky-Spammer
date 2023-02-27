using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Program
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
UIntPtr dwExtraInfo);
        public Form1()
        {
            InitializeComponent();
        }
        Point lastpoint;



        
            private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private async void timer1_Tick(object sender, EventArgs e)
        {

            int rmc = Convert.ToInt32(textBox3.Text);
            string intervalstr = textBox2.Text + "000";
            int interval = Convert.ToInt32(intervalstr);




            for (int i = 0; i < rmc;i++)
            {
                SendKeys.Send(textBox1.Text);

                SendKeys.Send("{ENTER}");
            }

            Task.Delay(interval).Wait();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                timer2.Start();
                if (Control.IsKeyLocked(Keys.CapsLock)) // Checks Capslock is on
                {
                    const int KEYEVENTF_EXTENDEDKEY = 0x1;
                    const int KEYEVENTF_KEYUP = 0x2;
                    keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                    keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                    (UIntPtr)0);
                }
            }
            else if (checkBox1.Checked == false)
            {
                timer1.Start();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                this.TopMost = true;
            }
            else { this.TopMost = false; }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int rmc = Convert.ToInt32(textBox3.Text);
            string intervalstr = textBox2.Text + "000";
            int interval = Convert.ToInt32(intervalstr);
            for (int i = 0; i < rmc; i++)
            {
                SendKeys.Send("@silent");
                SendKeys.Send(" ");
                SendKeys.Send(textBox1.Text);

                SendKeys.Send("{ENTER}");
            }

            Task.Delay(interval).Wait();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F7) {
                if (checkBox1.Checked == true)
                {
                    timer2.Start();
                }
                else if (checkBox1.Checked == false)
                {
                    timer1.Start();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Made by Ali";
            textBox2.Text = "2";
            textBox3.Text= "5";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            timer1.Stop();
            timer2.Stop();

        }
        bool goster = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) 
            {
                if (goster == true)
                {
                    MessageBox.Show("This Setting is For The Discord", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    goster = false;
                }
            
            
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/ggjR77grDt");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/AliAslanmirza");
        }
    }
}
