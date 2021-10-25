using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcolatrice
{
    public partial class Calcolatrice : Form
    {

        double n1;
        double n2;
        double val;
        double i;
        int opp;
        int dot;
        private object brake;

        public Calcolatrice()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            n1 = 0;
            n2 = 0;
            val = 0;
            i = 0;
            dot = 0;   
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "1";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.1;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "2";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.2;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "3";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.3;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "4";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.4;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "5";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.5;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "6";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.6;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "7";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.7;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "8";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.8;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "9";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.9;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                textBox1.Clear();
                visualBox.Clear();
                i = 0;
            }
            if (dot == 0)
            {
                textBox1.Text = textBox1.Text + "0";
            }
            else if (dot == 1)
            {
                val = Convert.ToDouble(textBox1.Text) + 0.0;
                textBox1.Text = Convert.ToString(val);
                dot = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            visualBox.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(textBox1.Text);
            visualBox.Text = textBox1.Text + " + ";
            textBox1.Clear();
            opp = 1;
            if (i == 1)
            {
                i = 0;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(textBox1.Text);
            visualBox.Text = textBox1.Text + " - ";
            textBox1.Clear();
            opp = 3;
            if (i == 1)
            {
                i = 0;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(textBox1.Text);
            visualBox.Text = textBox1.Text + " x ";
            textBox1.Clear();
            opp = 2;
            if (i == 1)
            {
                i = 0;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            n1 = Convert.ToDouble(textBox1.Text);
            visualBox.Text = textBox1.Text + " / ";
            textBox1.Clear();
            opp = 4;
            if (i == 1)
            {
                i = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            n2 = Convert.ToDouble(textBox1.Text);
            switch (opp) {
                case 1:
                    textBox1.Text = Convert.ToString(n1 + n2);
                    visualBox.Text = visualBox.Text + Convert.ToString(n2) + " =";
                    opp = 0;
                    break;
                case 2:
                    textBox1.Text = Convert.ToString(n1 * n2);
                    visualBox.Text = visualBox.Text + Convert.ToString(n2) + " =";
                    opp = 0;
                    break;
                case 3:
                    textBox1.Text = Convert.ToString(n1 - n2);
                    visualBox.Text = visualBox.Text + Convert.ToString(n2) + " =";
                    opp = 0;
                    break;
                case 4:
                    textBox1.Text = Convert.ToString(n1 / n2);
                    visualBox.Text = visualBox.Text + Convert.ToString(n2) + " =";
                    opp = 0;
                    break;
                default:
                    break;
            }
            dot = 0;
            i = 1;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dot = 1;
            textBox1.Text = textBox1.Text + ".";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
