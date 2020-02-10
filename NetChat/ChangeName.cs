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

namespace NetChat
{
    public partial class ChangeName : Form
    {
        public ChangeName()
        {
            InitializeComponent();
        }

        private void btnChange_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter your name.");
                textBox3.Text = "";
            }
            if (textBox3.Text.ToLower() == "admin")
            {
                MessageBox.Show("You cant change your name to admin because it is save.");
                textBox3.Text = "";
            }
            if (textBox3.Text!="")
            {
                File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n");
                File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "                                 " + Class.name + " changed name to " + textBox3.Text + "\r\n");
                File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n");
                Class.name = textBox3.Text;
                this.Close();
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)==false && e.KeyChar!='\b')
            {
                e.Handled = true;
            }
        }
    }
}
