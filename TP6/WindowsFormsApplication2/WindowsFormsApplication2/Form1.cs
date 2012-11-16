using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyTinyDemineur
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newGame();
        }

        static List<Button> buttons;
        static Button bomb;

        private void newGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4 };
            bomb = buttons[new Random().Next(0, buttons.Count)];

            foreach (Button b in buttons)
            {
                b.Enabled = true;
                b.Text = "_";
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.Black;
            }

            button6.Enabled = false;
            button6.BackColor = Color.Transparent;
            button6.ForeColor = Color.Black;
            button6.Text = "-";
        }

        private void endGame()
        {
            foreach (Button b in buttons)
            {
                b.Enabled = false;
            }

            bomb.BackColor = Color.Red;
            bomb.ForeColor = Color.Black;

            button6.Enabled = true;
        }

        private bool isEnded()
        {
            bool x = true;
            foreach (Button b in buttons)
            {
                if (b.Text == "_" && b != bomb)
                    x = false;
            }
            return x;
        }

        private void play(Button button)
        {
            if (button.Text == "0")
            {
                return;
            }

            else
            {
                if (button == bomb)
                {
                    button6.BackColor = Color.Red;
                    button6.ForeColor = Color.Black;
                    button6.Text = ":D NOOB !";
                    endGame();
                }

                else
                {
                    button.Text = "0";
                    button.BackColor = Color.Green;
                    button.ForeColor = Color.White;

                    if (isEnded())
                    {
                        button6.BackColor = Color.Green;
                        button6.ForeColor = Color.White;
                        button6.Text = "GG :'(";
                        endGame();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            play(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            play(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            play(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            play(button4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            newGame();
        }
    }
}