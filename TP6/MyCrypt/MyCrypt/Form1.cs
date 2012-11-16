using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            if (hideButton.Text == "Hide")
                textBox.PasswordChar = '*';
            else
                textBox.PasswordChar = (char)0;
            hideButton.Text = hideButton.Text == "Hide" ? "Show" : "Hide";
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            String s = "";
            int r = 26 - (Convert.ToInt32(cryptBox.Text) % 26);
            foreach (char c in textBox.Text)
            {
                if (c >= 'A' && c <= 'Z')
                    s += Convert.ToChar((c - 65 + r) % 26 + 65);
                else
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        s += Convert.ToChar((c - 97 + r) % 26 + 97);
                    }
                    else
                    {
                        s += c;
                    }
                }

            }

            textBox.Text = s;
        }

        private void cryptButton_Click(object sender, EventArgs e)
        {
            String s = "";
            int r = Convert.ToInt32(cryptBox.Text);

            foreach (char c in textBox.Text)
            {
                if (c >= 'A' && c <= 'Z')
                    s += Convert.ToChar((c - 65 + r) % 26 + 65);
                else
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        s += Convert.ToChar((c - 97 + r) % 26 + 97);
                    }
                    else
                    {
                        s += c;
                    }
                }

            }

            textBox.Text = s;
        }
    }
}
