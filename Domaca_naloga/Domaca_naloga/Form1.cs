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
                if (Na_Tocki())
                {
                    MessageBox.Show("Tocka lezi na oglišču");
                }
                else if (Na_Robu())
                {
                    MessageBox.Show("Tocka lezi na robu");
                }
                else if (V_Mnogokotniku() == 1) {
                    MessageBox.Show("Tocka lezi v mnogokotniku");
                }
                else
                {
                    MessageBox.Show("Tocka lezi izven mnogokotnika");
                }
            }
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
            risem_tocko = false; // ne risemo več moje točke
            tocke.Clear(); // pocistimo kootdinate tock
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

        private bool Na_Tocki() {
            // gremo skozi vse tocke, imamo manjso napako
            float napaka_x, napaka_y;
            for (int i = 0; i < tocke.Count(); i++) {
                napaka_x = Math.Abs(tocke[i].x - tocka.x);
                napaka_y = Math.Abs(tocke[i].y - tocka.y);
                if (napaka_x < 2.6 && napaka_y < 2.6) {
                    return true;
                }
            }
            return false;
        }

        private bool Na_Robu()
        {
            Pen pen = new Pen(ForeColor); // za risanje daljic med tockama
            Graphics g = this.CreateGraphics();
            /*
             float xDiff = x2 - x1;
             float yDiff = y2 - y1;
                return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
             */

            for (int i = 0; i < tocke.Count()-1; i++) {
                // let AB = Math.sqrt(Math.pow(A.x - C.x, 2) + Math.pow(A.y - C.y, 2));
                float t1_t = (float)Math.Sqrt(Math.Pow(tocke[i].x - tocka.x, 2) + Math.Pow(tocke[i].y - tocka.y, 2));
                float t2_t = (float)Math.Sqrt(Math.Pow(tocke[i + 1].x - tocka.x, 2) + Math.Pow(tocke[i + 1].y - tocka.y, 2));
                float t1_t2 = (float)Math.Sqrt(Math.Pow(tocke[i].x - tocke[i + 1].x, 2) + Math.Pow(tocke[i].y - tocke[i + 1].y, 2));
                // Math.acos((BC * BC + AC * AB - AC * AB) / (2 * BC * AB)) * 180 / Math.PI;
                float rez = (float)Math.Acos((t2_t * t2_t + t1_t2 * t1_t - t1_t2 * t1_t) / (2 * t2_t * t1_t) * 180 / Math.PI);
                /*
                float xDiff_1 = tocke[i].x - tocka.x;
                float yDiff_1 = tocke[i].y - tocka.y;
                float xDiff_2 = tocke[i+1].x - tocka.x;
                float yDiff_2 = tocke[i+1].y - tocka.y;
                float a = (float)(Math.Atan2(yDiff_1, xDiff_1) * 180.0 / Math.PI);
                float b = (float)(Math.Atan2(yDiff_2, xDiff_2) * 180.0 / Math.PI);
                */
                //MessageBox.Show("Kot: " + rez);
                if ( rez >= 178) {
                    g.DrawLine(pen, tocke[i].x, tocke[i].y, tocke[i+1].x, tocke[i+1].y);
                    return true;
                }
            }
            return false;
        }

        private int V_Mnogokotniku() {
            // testno tocko postavimo kot izhodisče
            List<Tocka> nove_tocke = new List<Tocka>(); // odstete tocke
            for (int i = 0; i < tocke.Count(); i++) {
                Tocka t;
                t.x = tocke[i].x - tocka.x;
                t.y = tocke[i].y - tocka.y;
                nove_tocke.Add(t);
            }
            // sedaj imamo vse tocke odstete
            int st = 0;
            Tocka t1, t2;
            for (int i = 0; i < nove_tocke.Count(); i++) {
                if (i == nove_tocke.Count() - 1)
                {
                    // smo v zadni tocki in vzamemo prvo in zadno
                    t1 = nove_tocke[i];
                    t2 = nove_tocke[0];
                }
                else {
                    t1 = nove_tocke[i];
                    t2 = nove_tocke[i + 1];
                }
                // prvi pogoj 2. in 3.
                if ((t1.x<0 && t1.y >0) && (t2.x<0 && t2.y<0) ||
                    (t1.x < 0 && t1.y < 0) && (t2.x < 0 && t2.y > 0))
                {
                    st++;
                }
                // drugi pogoj 1. in 3.
                if ((t1.x > 0 && t1.y > 0) && (t2.x < 0 && t2.x < 0) ||
                   (t1.x < 0 && t1.y < 0) && (t2.x > 0 && t2.x > 0)) {
                    //D = (xi * yi+1 - xi+1 * yi) * (yi - yi+1)
                    float D = (float)(t1.x * t2.y - t2.x * t1.y) * (t1.y - t2.y);
                    if (D > 0) { st++; }
                }
                // tretji pogoj 2. in 4.
                if ((t1.x < 0 && t1.y > 0) && (t2.x > 0 && t2.y < 0) ||
                   (t1.x > 0 && t1.y < 0) && (t2.x < 0 && t2.y > 0)) {
                    //D = (xi * yi+1 - xi+1 * yi) * (yi - yi+1)
                    float D = (float)(t1.x * t2.y - t2.x * t1.y) * (t1.y - t2.y);
                    if (D > 0) { st++; }
                }
            }

            return st%2; // da bomo ugotovili ce je sod ali lih
        }
    }   

}
