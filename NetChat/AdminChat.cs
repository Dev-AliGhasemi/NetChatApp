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
    public partial class AdminChat : Form
    {
        public AdminChat()
        {
            InitializeComponent();
        }
        bool click = false;
        int mousex, mousey;
        private void AdminChat_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Filter = "talk.txt";
            fileSystemWatcher1.Path= "\\\\" + Class.ip + "\\chat\\";
            textBox1.Text = File.ReadAllText("\\\\" + Class.ip + "\\chat\\talk.txt");
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                textBox1.Text = File.ReadAllText("\\\\" + Class.ip + "\\chat\\talk.txt");
                if (textBox1.Text == "")
                {
                    this.Close();
                }
            }
            catch
            {

            }
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                File.AppendAllText("\\\\" + Class.ip + "\\chat\\talk.txt", Class.name+" : "+textBox2.Text+"\r\n");
                textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText("\\\\" + Class.ip + "\\chat\\talk.txt", "");
            this.Close();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Focused==false && textBox2.Text=="")
            {
                textBox2.Text = "Type here...";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text=="Type here..." )
            {
                textBox2.Text = "";

            }
        }

        private void AdminChat_Shown(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                File.AppendAllText("\\\\" + Class.ip + "\\chat\\talk.txt", Class.name+" : "+textBox2.Text + "\r\n");
            }
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (click==true)
            {
                this.Left += e.X - mousex;
                this.Top += e.Y - mousey;
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                click = false;
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                click = true;
                mousex = e.X;
                mousey = e.Y;
            }
        }
    }
}
