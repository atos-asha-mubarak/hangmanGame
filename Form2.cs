using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HangMan
{
    public partial class Form2 : Form
    {
        int select = -1;
        
      

        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //adjectives
            select = 0;
            this.Close();
        }

      
        

        public int returnSelect()
        {
            return select;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Sports
            select = 1;
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Animals
            select =2 ;
            this.Close();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Animals
            select = 2;
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Countries
            select = 3;
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Motivation
            select = 4;
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Actions
            select = 5;
            this.Close();
        }


        
    }
}
