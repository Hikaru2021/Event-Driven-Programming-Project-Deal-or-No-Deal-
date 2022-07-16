using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deal_or_No_Deal
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 1;
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.BringToFront();
            timer1.Start();
            label1.Visible = true;
            progressBar1.Visible = true;
            button1.Visible = false;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Visible = false;
            progressBar1.Parent = pictureBox1;
            progressBar1.ForeColor = Color.Gold;
            progressBar1.Visible = false;
   

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            label1.Text = progressBar1.Value + "%";
            if(progressBar1.Value == 100)
            {
                Game game = new Game();
                game.Show();
                this.Hide();
                timer1.Stop();
            }
        }
    }
}
