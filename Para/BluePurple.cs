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
    
    
    public partial class BluePurple : Form
    {
        public static string text="";
        public static string[] tv = new string[100];
        public static int tvi = 0;
        public static int tvii = 0;
        public static string[] notes = new string[100];
        
        public BluePurple()
        {
            InitializeComponent();
            richTextBox2.Hide();
            for(int i=0;i<notes.Length;i++)
            {
                notes[i] = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indi = 0;
            int ind = 0;
            text = richTextBox1.Text;
            
            
            indi = text.IndexOf("\n");
            if(indi==-1)
            {
                tv[tvi++] = text;
            }
            else
            {
                string t = "";
                for(int i=0;i<indi;i++)
                {
                    t += text[i].ToString();
                }
                tv[tvi++] = t;
                t = "";
                ind = text.IndexOf("\n",indi+1);
                do
                {

                    //MessageBox.Show(ind.ToString());
                    for (int i = indi; i < ind; i++)
                    {
                        //char tx = text[i];

                        t += text[i].ToString();
                    }
                    //richTextBox2.Text = t;
                    tv[tvi++] = t;
                    //MessageBox.Show(t);
                    t = "";
                    indi = ind;
                    ind = text.IndexOf("\n", indi + 1);
                } while (ind != -1);
                for (int i = indi; i < text.Length; i++)
                {
                    char tx = text[i];
                    t += text[i].ToString();
                    
                }
                tv[tvi++] = t;
                //MessageBox.Show(t);
            }
            progressBar2.Maximum = tvi-1;
            progressBar2.Value = 0;
            progressBar2.Step = 1;
            progressBar2.PerformStep();
            Paragraph p1 = new Paragraph(this);
            p1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //richTextBox2.Text = text;
            richTextBox2.Show();
            string texwork = "";
            string tex = richTextBox1.Text;
            string[] texlist = tex.Split(' ','\n');
            int[] freqvect=new int[1000];
            int freqi = 0;
            for(int i=0;i<texlist.Length;i++)
            {
                int counter = 0;
                for (int j = i; j < texlist.Length;j++)
                {
                    if (texlist[i] == "this" || texlist[i] == "is" || texlist[i] == "I" || texlist[i] == "with"|| texlist[i]=="the"||texlist[i]=="of"|| texlist[i]=="and"|| texlist[i]=="in" ||texlist[i]=="from"|| texlist[i]=="to"||texlist[i]=="can"||texlist[i]=="be")
                        continue;
                    if (i == j)
                        continue;
                    if(texlist[i]==texlist[j])
                    {
                        counter++;
                    }
                    
                }
                freqvect[i] = counter;
            }
            for (int k = 0; k < 4; k++)
            {
                int a = 0;
                for (int i = 0; i < texlist.Length; i++)
                {
                    if (freqvect[a] < freqvect[i])
                        a = i;
                }
                texwork += texlist[a] + '\n';
                freqvect[a] = -1;
            }
            richTextBox2.Text = texwork;
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bruh");
            progressBar2.Step = 100 / tvi;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void incrementBar()
        {
            this.progressBar2.PerformStep();
        }
        public string retTv()
        {
            return tv[tvii];
        }
        public void incrementTvii()
        {
            tvii++;
            if (tvii == tvi)
                tvii = 0;
        }
        public void checkBar()
        {
            if (progressBar2.Value == progressBar2.Maximum)
                progressBar2.Value = progressBar2.Minimum;
        }
        public string retNot()
        {
            return notes[tvii];
        }
        public void writeNot(string txt)
        {
            notes[tvii] = txt;
        }
        public void writeNotes()
        {
            string work = "";
            for(int i=0;i<tvi;i++)
            {
                work += (i+1).ToString() + " " + notes[i] + "\n" ;
            }
            richTextBox3.Text = work;
        }

        private void BluePurple_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
