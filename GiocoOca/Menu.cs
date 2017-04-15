using System;
using System.Windows.Forms;

namespace GiocoOca
{
    public partial class Menu : Form
    {
        private RadioButton selectedrb;
        private RadioButton selectedrb2;
        private int numGiocatori;
        private int numCaselle;

        public Menu()
        {
            InitializeComponent();
            InizializzaRadioButton();
            selectedrb = radioButton3;
            selectedrb2 = radioButton8;
        }

        public int getCaselle
        {
            get { return numCaselle; }
        }

        public int getGiocatori
        {
            get { return numGiocatori; }
        }

        private void InizializzaRadioButton()
        {
            radioButton3.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton4.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton5.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton6.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton7.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton8.CheckedChanged += new EventHandler(radioButton_CheckedChanged2);
            radioButton9.CheckedChanged += new EventHandler(radioButton_CheckedChanged2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedrb.Text.Contains("2"))
                numGiocatori = 2;
            else if(selectedrb.Text.Contains("3"))
                numGiocatori = 3;
            else if (selectedrb.Text.Contains("4"))
                numGiocatori = 4;
            else if (selectedrb.Text.Contains("5"))
                numGiocatori = 5;
            else if (selectedrb.Text.Contains("6"))
                numGiocatori = 6;

            if (selectedrb2.Text.Contains("63"))
                numCaselle = 63;
            else if (selectedrb2.Text.Contains("90"))
                numCaselle = 90;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                selectedrb = rb;
            }
        }

        private void radioButton_CheckedChanged2(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                selectedrb2 = rb;
            }
        }
    }
}
