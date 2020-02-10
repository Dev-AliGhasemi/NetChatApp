using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Random rnd2 = new Random();
            switch (rnd2.Next(1,3))
            {
                case 1:
                    label2.Width += rnd.Next(1, 10);
                    break;
                case 2:
                    label2.Width += rnd.Next(20, 30);
                    break;
            }
            if (label2.Width>=348)
            {
                timer1.Stop();
                this.Hide();
                Home home = new Home();
                home.Show();

            }
        }
    }
}
