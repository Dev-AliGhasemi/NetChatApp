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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        int i = 20;
        string host = Dns.GetHostName();
        bool click = false;
        int mousex, mousey;
        bool back = false;
        bool back2 = false;
        bool back3 = false;
        bool back4 = false;
        private void picclose_MouseEnter(object sender, EventArgs e)
        {
        }

        private void picclose_MouseLeave(object sender, EventArgs e)
        {

        }

        private void picmini_MouseEnter(object sender, EventArgs e)
        {

        }

        private void picmini_MouseLeave(object sender, EventArgs e)
        {

        }

        private void picclose_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void picmini_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.Silver;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Silver;
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            time_admin.Start();
        }

        private void time_admin_Tick(object sender, EventArgs e)
        {
            if (back == false)
            {
                panel1.Left -= i;
                if (panel1.Left + panel1.Width < 0)
                {
                    time_admin.Stop();
                    time_admin2.Start();
                    back = true;
                }
            }
            else
            {
                panel1.Left += i;
                if (panel1.Left >= 0)
                {
                    time_admin.Stop();
                    back = false;
                }
            }
        }

        private void time_admin2_Tick(object sender, EventArgs e)
        {
            if (back2 == false)
            {
                panel2.Left -= i;
                this.Height = 284;
                lbl1.Top = 246;
                lbl2.Top = 246;
                if (panel2.Left <= 70)
                {
                    lbl1.BackColor = Color.FromArgb(180, 180, 180);
                    lbl2.BackColor = Color.FromArgb(105, 105, 105);
                    time_admin2.Stop();
                    back2 = true;
                }
            }
            else
            {
                panel2.Left += i;
                this.Height = 228;
                lbl1.Top = 192;
                lbl2.Top = 192;
                if (panel2.Left >=this.Width)
                {
                    lbl1.BackColor = Color.FromArgb(105, 105, 105);
                    lbl2.BackColor = Color.FromArgb(180, 180, 180);
                    time_admin2.Stop();
                    time_admin.Start();
                    back2 = false;
                }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            time_admin2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="20200001")
            {
                MessageBox.Show("Welcome admin");
                if (!File.Exists("\\\\" + Dns.GetHostByName(host).AddressList[0] + "\\chat\\chat.txt"))
                {
                    File.WriteAllText("\\\\" + Dns.GetHostByName(host).AddressList[0] + "\\chat\\chat.txt", "");
                    File.WriteAllText("\\\\" + Dns.GetHostByName(host).AddressList[0] + "\\chat\\talk.txt", "");
                }
                else
                {
                    File.WriteAllText("\\\\" + Dns.GetHostByName(host).AddressList[0] + "\\chat\\chat.txt", "                                 Admin joined" + "\r\n");
                    Class.adamin = true;
                    Class.name = "Admin";
                    Class.ip = Dns.GetHostByName(host).AddressList[0].ToString();
                    Chat chat = new Chat();
                    this.Hide();
                    chat.Show();
                }
            }
        }

        private void time_client_Tick(object sender, EventArgs e)
        {
            if (back3 == false)
            {
                panel1.Left -= i;
                if (panel1.Left + panel1.Width < 0)
                {
                    time_client.Stop();
                    time_client2.Start();
                    back3 = true;
                }
            }
            else
            {
                panel1.Left += i;
                if (panel1.Left >= 0)
                {
                    time_client.Stop();
                    back3 = false;
                }
            }
        }

        private void time_client2_Tick(object sender, EventArgs e)
        {
            if (back4 == false)
            {
                panel3.Left -= i;
                this.Height = 397;
                lbl1.Top = 364;
                lbl2.Top = 364;
                if (panel3.Left <= 70)
                {
                    lbl1.BackColor = Color.FromArgb(180, 180, 180);
                    lbl2.BackColor = Color.FromArgb(105, 105, 105);
                    time_client2.Stop();
                    back4 = true;
                }
            }
            else
            {
                panel3.Left += i;
                this.Height = 228;
                lbl1.Top = 192;
                lbl2.Top = 192;
                if (panel3.Left >= this.Width)
                {
                    lbl1.BackColor = Color.FromArgb(105, 105, 105);
                    lbl2.BackColor = Color.FromArgb(180, 180, 180);
                    time_client2.Stop();
                    time_client.Start();
                    back4 = false;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            time_client.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            time_client2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class.ip = textBox3.Text;
            if (textBox2.Text=="" || textBox3.Text=="")
            {
                MessageBox.Show("Some Fields are not have value!");
            }
            else if (!File.Exists("\\\\" + textBox3.Text + "\\chat\\chat.txt"))
            {
                MessageBox.Show("Still admin not sign in please wait! or the ip is invalid");
            }
            else
            {
                try
                {
                    File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n");
                    File.AppendAllText("\\\\" + textBox3.Text + "\\chat\\chat.txt", "                                 " + textBox2.Text + " joined" + "\r\n");
                    File.AppendAllText("\\\\" + Class.ip + "\\chat\\chat.txt", "\r\n");
                }
                catch
                {
                    MessageBox.Show("Please wait or Try again!");
                }
              
                Class.ip = textBox3.Text;
                Class.adamin = false;
                Class.name = textBox2.Text;
                this.Hide();
                Chat cht = new Chat();
                cht.Show();
            }
        }

        private void picclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (click == true)
            {
                this.Left += e.X - mousex;
                this.Top += e.Y - mousey;
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                click = false;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                click = true;
                mousex = e.X;
                mousey = e.Y;
            }
        }
    }
}
