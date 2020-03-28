using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class Splash : Form
    {
        double x = 0;
        //string load;
        public Splash()
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
        }



        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text += ".";
            x += 0.5;

            if (x == 10)
            {
                timer1.Stop();
                timer2.Start();
            }

            if (label1.Text == "")
            {

                label1.Text = "";

            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;

            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
                Home_Page log = new Home_Page();
                log.Show();
            }
        }

        private void Splash_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
