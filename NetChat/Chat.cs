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
using System.Net;

namespace NetChat
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }
        int i = 10;
        int b = 0;
        bool click = false;
        int mousex, mousey;
        bool on = false;
        bool talk = false;
        private void Chat_Load(object sender, EventArgs e)
        {
            if (Class.adamin == true)
            {
                fileSystemWatcher2.EnableRaisingEvents = true;
                fileSystemWatcher2.Filter = "talk.txt";
                fileSystemWatcher2.Path = "\\\\" + Class.ip + "\\chat\\";
            }
            fileSystemWatcher1.Filter = "chat.txt";
            fileSystemWatcher1.Path = "\\\\" + Class.ip + "\\chat\\";
            textBox1.Text = File.ReadAllText("\\\\"+Class.ip+"\\chat\\chat.txt");
            talk = false;
            Class.open = false;
            textBox2.Focus();
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                textBox1.Text = File.ReadAllText("\\\\" + Class.ip + "\\chat\\chat.txt");
            }
            catch 
            {
                MessageBox.Show("Please wait! **big data**");       
            }
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                try
                {
                    File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", Class.name + " : " + textBox2.Text + "                   " + Dns.GetHostName() + "\r\n");
                }
                catch
                {
                    MessageBox.Show("Message not sent");

                }
                textBox2.Clear();
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
               // File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n");
                File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "                                 " + Class.name + " left the chat" + "\r\n");
             //   File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n"); 
        }

        private void picclose_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void picmini_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Focused == false)
            {
                textBox2.Text = "Type here...";
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (on == false)
            {
                if (panel1.Left > 490)
                {
                    panel1.Left -= i;
                }
                else if (panel1.Left < 490 && panel1.Left > 477)
                {
                    i = 1;
                    panel1.Left -= i;
                }
                else if (panel1.Left <= 477)
                {
                    panel1.Left += 1;
                    on = true;
                    timer1.Stop();
                    i = 10;
                }
            }
            else
            {
                if (panel1.Left<=594)
                {
                    panel1.Left += i;
                }
                else if (panel1.Left>594 && panel1.Left<615)
                {
                    i = 1;
                    panel1.Left += i;
                }
                else if (panel1.Left>=615)
                {
                   // panel1.Left += 1;
                    on = false;
                    timer1.Stop();
                    i = 10;
                }
            }
        }

        private void lblChange_MouseEnter(object sender, EventArgs e)
        {
            lblChange.BackColor = Color.Silver;
        }
        private void lblChange_MouseLeave(object sender, EventArgs e)
        {
            lblChange.BackColor = Color.FromKnownColor(KnownColor.AppWorkspace);

        }

        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.Silver;
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.BackColor = Color.FromKnownColor(KnownColor.AppWorkspace);
        }

        private void lblAdmin_MouseEnter(object sender, EventArgs e)
        {
            lblAdmin.BackColor = Color.Silver;
        }

        private void lblAdmin_MouseLeave(object sender, EventArgs e)
        {
            lblAdmin.BackColor = Color.FromKnownColor(KnownColor.AppWorkspace);
        }

        private void lblThem_MouseEnter(object sender, EventArgs e)
        {
            lblThem.BackColor = Color.Silver;
        }

        private void lblThem_MouseLeave(object sender, EventArgs e)
        {
            lblThem.BackColor = Color.FromKnownColor(KnownColor.AppWorkspace);
        }
        private void Chat_Shown(object sender, EventArgs e)
        {
          
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void lblChange_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeName chg = new ChangeName();
            chg.ShowDialog();
        }

        private void lblLogout_MouseClick(object sender, MouseEventArgs e)
        {
            File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n");
            File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "                                 " + Class.name + " loged out" + "\r\n");
            File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n");
            this.Close();
            Home home = new Home();
            home.Show();
        }

        private void lblAdmin_MouseClick(object sender, MouseEventArgs e)
        {
            string ip =  File.ReadAllText("\\\\" + Class.ip + "\\chat\\talk.txt");
            if (ip=="")
            {
                talk = true;
                File.WriteAllText("\\\\" + Class.ip + "\\chat\\talk.txt",Dns.GetHostName() + "\r\n");
                if (Class.adamin==false)
                {
                    AdminChat admin = new AdminChat();
                    admin.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Another client is talking to admin please wait!");
            }
        }

        private void fileSystemWatcher2_Changed(object sender, FileSystemEventArgs e)
        {
            string request = File.ReadAllText("\\\\" + Class.ip + "\\chat\\talk.txt");
                if (request != "")
                {
                Class.b++;
                if (Class.b==1)
                {
                    AdminChat Admin = new AdminChat();
                    Admin.Show();
                }   
            }
            else
            {
                Class.b = 0;
            }
         }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (on==true)
            {
                timer1.Start();
            }
            if (textBox2.Text == "Type here...")
            {
                textBox2.Text = "";
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (on == true)
            {
                timer1.Start();
            }
            if (textBox2.Focused == false && textBox2.Text == "")
            {
                textBox2.Text = "Type here...";
            }
        }

        private void Chat_MouseClick(object sender, MouseEventArgs e)
        {
            if (on == true)
            {
                timer1.Start();
            }
        }

        private void lblThem_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("This ithem is not complete");
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
