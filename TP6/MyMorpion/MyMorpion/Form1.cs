using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyMorpion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Button> buttons, thewin;

        private int who, p1, p2;

        static private Button[][] w;

        private void NewGame()
        {
            who = 1;
            foreach (Button b in buttons)
            {
                b.Text = "";
                b.Enabled = true;
                b.BackColor = Color.White;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            w = new Button[][]
            {
                new Button[] {case1,case2,case3},
                new Button[] {case4,case5,case6},
                new Button[] {case7,case8,case9},
                new Button[] {case1,case4,case7},
                new Button[] {case2,case5,case8},
                new Button[] {case3,case6,case9},
                new Button[] {case1,case5,case9},
                new Button[] {case3,case5,case7}
            };

            buttons = new List<Button> { case1, case2, case3, case4, case5, case6, case7, case8, case9 };

            p1 = 0;
            p2 = 0;

            label1.Text = "X : " + p1;
            label2.Text = "O : " + p2;

            NewGame();
        }
        

        private int IsEnded()
        {
            for (int i = 0; i < w.Count(); i++)
            {
                if ((w[i][0].Text == w[i][1].Text && w[i][1].Text == w[i][2].Text) && (w[i][0].Text == "X" || w[i][0].Text == "O"))
                {
                    thewin = new List<Button> { w[i][0], w[i][1], w[i][2] };
                    foreach (Button b in thewin)
                    {
                        b.BackColor = Color.Green;
                        b.ForeColor = Color.White;
                    }
                    return (w[i][0].Text == "X") ? 1 : 2;
                }
            }

            foreach (Button b in buttons)
            {
                if (b.Text == "")
                    return 0;
            }

            return 3;
        }

        private void Play(Button c)
        {
            string s = (who == 1) ? "X" : "O";
            c.Text = s;
            c.Enabled = false;
            int a = IsEnded();
            if (a != 0)
            {
                foreach (Button b in buttons) { b.Enabled = false; }

                if (a == 1)
                {
                    p1++;
                    label1.Text = "X : " + p1;
                }
                if (a == 2)
                {
                    p2++;
                    label2.Text = "O : " + p2;
                }
            }

            else
                who = (who == 1) ? 2 : 1;
        }

        private void case1_Click(object sender, EventArgs e)
        {
            Play(case1);
        }

        private void case2_Click(object sender, EventArgs e)
        {
            Play(case2);
        }

        private void case3_Click(object sender, EventArgs e)
        {
            Play(case3);
        }

        private void case4_Click(object sender, EventArgs e)
        {
            Play(case4);
        }

        private void case5_Click(object sender, EventArgs e)
        {
            Play(case5);
        }

        private void case6_Click(object sender, EventArgs e)
        {
            Play(case6);
        }

        private void case7_Click(object sender, EventArgs e)
        {
            Play(case7);
        }

        private void case8_Click(object sender, EventArgs e)
        {
            Play(case8);
        }

        private void case9_Click(object sender, EventArgs e)
        {
            Play(case9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
