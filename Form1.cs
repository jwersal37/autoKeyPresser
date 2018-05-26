using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Input;


namespace AutoKeyMoist
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        bool isRunning = true;

        GlobalKeyboardHook gHook;

        private void Form1_Load(object sender, EventArgs e)
        {
            gHook = new GlobalKeyboardHook(); // Create a new GlobalKeyboardHook
                                              // Declare a KeyDown Event
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            // Add the keys you want to hook to the HookedKeys list
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
        }

        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            string moist = ((char)e.KeyValue).ToString();

            if(moist == "p")
            {
                button1_Click(sender, e);
            }
            else if(moist == "q")
            {
                button2_Click(sender, e);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            string str = textBox1.Text;
            str = str.Replace(" ", string.Empty); 

            for (i = 0; i < str.Length; i++)
            {
                SendKeys.Send(str[i].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                int interval = int.Parse(textBox2.Text);
                timer1.Interval = interval * 1000;
            }
            catch
            {
                timer1.Enabled = false;
                MessageBox.Show("No Input");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gHook.unhook();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
