using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindText
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            logpas = new Dictionary<string, string>();
            logpas.Add("admin", "admin");
        }
        public Dictionary<string, string> logpas;

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginCheck())
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            else
            {
                label1.Text = "Error";
                label1.Visible = true;
            }
        }

        private bool LoginCheck()
        {
            foreach (var t in logpas)
            {
                if (t.Value == textBox2.Text && t.Key == textBox1.Text)
                {
                    return true;
                }
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                logpas.Add(textBox1.Text, textBox2.Text);
                label1.Visible = false;
            }
            catch { label1.Text = "Again?"; }
        }
    }
}
