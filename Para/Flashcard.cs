using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BluePurple
{
    public partial class Flashcard : Form
    {
        Random rnd = new Random();
        int randomint;
        private string[] splitTextG;
        BluePurple bp;
        Paragraph para;
        public Flashcard(BluePurple Bp, Paragraph Para)
        {
            InitializeComponent();
            bp = Bp;
            para = Para;
            string workstring = "";
            
            string localText = bp.retTv();
            string[] splitText = localText.Split(' ');
            splitTextG = splitText;
            randomint = rnd.Next(0, splitTextG.Length-1);
            for(int i=0;i<splitText.Length; i++)
            {
                if (i == randomint)
                {
                    workstring += "_____" + " ";
                    continue;
                }
                    
                workstring += splitText[i] + " ";
            }
            richTextBox1.Text = workstring;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            para.Show();
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Flashcard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == splitTextG[randomint])
            {
                MessageBox.Show("Correct answer");
                para.Show();
                this.Close();
            }
            else
                MessageBox.Show("Try again");
        }
    }
}
