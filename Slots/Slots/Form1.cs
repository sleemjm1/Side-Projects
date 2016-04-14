using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slots
{
    public partial class Form1 : Form
    {
        CardGenerator generator;
        Graphics graphics;
        int timerTime;
        int multiplier;
        int credit;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = groupBox2.CreateGraphics();
            generator = new CardGenerator(graphics);
            timerTime = 0;
            multiplier = 0;
            credit = 100;
            rbBetFive.Checked = true;
            generator.Credit = credit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool allowedToBet = false;
            if (rbBetFifty.Checked && credit >= 50)
            {
                allowedToBet = true;
                multiplier = 50;
            }
            else if (rbBetTwenty.Checked && credit >= 20)
            {
                allowedToBet = true;
                multiplier = 20;
            }

            else if (rbBetTen.Checked && credit >= 10)
            {
                allowedToBet = true;
                multiplier = 10;
            }
            else if (rbBetFive.Checked && credit >= 5)
            {
                allowedToBet = true;
                multiplier = 5;
            }
            else
                MessageBox.Show("Not enough credit to bet");

            if (allowedToBet)
            {
                credit -= multiplier;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            generator.GenerateCards();
            generator.DrawAllCards();
            timerTime++;

            if (timerTime == 10)
            {
                timer1.Enabled = false;
                generator.CheckCards(label1, multiplier);
                timerTime = 0;
                lblCredit.Text = generator.Credit.ToString();
            }
        }
    }
}
