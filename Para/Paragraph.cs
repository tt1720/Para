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
    public partial class Paragraph : Form
    {
        BluePurple bp;
        public Paragraph(BluePurple Bp)
        {
            InitializeComponent();
             bp = Bp;
            richTextBox1.Text = bp.retTv();
            richTextBox2.Text = bp.retNot();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bp.incrementBar();
            bp.checkBar();
           
            bp.writeNot(richTextBox2.Text);
            
            bp.incrementTvii();
            bp.writeNotes();
            richTextBox1.Text = bp.retTv();
            richTextBox2.Text = bp.retNot();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Flashcard flash = new Flashcard(bp,this);
            this.Hide();
            flash.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
