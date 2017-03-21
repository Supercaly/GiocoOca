using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiocoOca
{
    public partial class Vista : Form
    {
        private List<Label> pedine;

        public Vista()
        {
            InitializeComponent();
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            string[] stringArray = new string[3];

            stringArray[0] = "Yes";
            stringArray[1] = "No";
            stringArray[2] = "Maybe";

            System.Windows.Forms.RadioButton[] radioButtons =
                new System.Windows.Forms.RadioButton[3];

            for (int i = 0; i < 3; ++i)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].Text = stringArray[i];
                radioButtons[i].Location = new System.Drawing.Point(
                    10, 10 + i * 20);
                this.Controls.Add(radioButtons[i]);
            }
        }

        private void BottLanciaDadi_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        public Button getBottLanciaDadi()
        {
            return bottLanciaDadi;
        }

        public void SetTextLabel1(String s)
        {
            label1.Text = s;
        }
        public void SetTextLabel2(String s)
        {
            label2.Text = s;
        }
        public void SetTextLabel3(String s)
        {
            label3.Text = s;
        }
        public void SetTextLabel4(String s)
        {
            label4.Text = s;
        }
        public void SetTextbutt(String s)
        {
            Pedina1.Text = s;
            //System.Threading.Thread.Sleep(2000);
            //Application.Exit();
        }
        private void ContenitoreTavolo_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button63_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
