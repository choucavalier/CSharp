using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void updateText()
        {
            string name = radioButton1.Checked ? textBox1.Text : textBox2.Text;
            string lang = comboBox1.Text;

            button2.Text = lang + " " + name + " !";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button2.ForeColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateText();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            updateText();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateText();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            updateText();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            updateText();
        }
    }
}
