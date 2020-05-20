using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domaca_naloga
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        struct Tocka {
            public float x;
            public float y;
        }
        List<Tocka> tocke = new List<Tocka>();
        Tocka tocka = new Tocka();
        bool risem_tocko = false;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Brush aBrush = (Brush)Brushes.Black; // za risanje tock
            Brush bBrush = (Brush)Brushes.Red; // za risanje tock
            Pen pen = new Pen(ForeColor); // za risanje daljic med tockama
            Graphics g = this.CreateGraphics();
            //float x1 = e.X;
            //float y1 = e.Y;

            if (!risem_tocko)
            {
                Tocka t1;
                t1.x = e.X;
                t1.y = e.Y;
                tocke.Add(t1);
                g.FillRectangle(aBrush, t1.x, t1.y, 2, 2); // narisemo tocko
            }
            else {
                tocka.x = e.X;
                tocka.y = e.Y;
                // narisi mnogokotnik
                narisi_mnogokotnik();
                g.FillRectangle(bBrush, tocka.x, tocka.y, 2, 2); // narisemo tocko
                // klicem ostale funkcije
            }
            //label2.Text = "Tocka 1: x1: " + x1 + " y1: " + y1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            risem_tocko = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Brush aBrush = (Brush)Brushes.Black; // za risanje tock
            Brush bBrush = (Brush)Brushes.Red; // za risanje tock
            Pen pen = new Pen(ForeColor); // za risanje daljic med tockama
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White); // pocistim vse tocke in daljice ko je zacetek novih koordinat
            risem_tocko = false;
            tocke.Clear();
        }

        private void narisi_mnogokotnik() {
            Brush aBrush = (Brush)Brushes.Black; // za risanje tock
            Brush bBrush = (Brush)Brushes.Red; // za risanje tock
            Pen pen = new Pen(ForeColor); // za risanje daljic med tockama
            Graphics g = this.CreateGraphics();
            int d = tocke.Count() - 1;
            //MessageBox.Show("st: " + (d + 1));
            for (int i = 1; i < tocke.Count(); i++) {
                g.DrawLine(pen, tocke[i-1].x, tocke[i - 1].y, tocke[i].x, tocke[i].y);// narisemo crto med njima
            }
            
            g.DrawLine(pen, tocke[0].x, tocke[0].y, tocke[d].x, tocke[d].y); // poveze prvo pa zadno
        }
    }
}
