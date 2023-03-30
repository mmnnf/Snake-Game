using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace feistel_folder_browser
{
    public partial class Form1 : Form
    {
        int xx=20,yy=0,yemx=0,yemy=0,randx=0,randy=0,addim=20;
        int c=1;
        int[] x = new int[1];
        int[] y = new int[1];
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //label5.Text = "";
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Black, 5);
            for (int i = 0; i <c; i++)
            {
                
                e.Graphics.FillRectangle((Brushes.Blue), x[i], y[i], addim, addim);
			}
            e.Graphics.FillRectangle((Brushes.Red), yemx, yemy, addim, addim);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //x[0] = 100; y[0] = 100;
            x[0] = (rand.Next(1, 18)) * addim;
            y[0] = (rand.Next(1, 18)) * addim;
            randx = rand.Next(1, 20);
            randy = rand.Next(1, 20);
            yemx = randx * addim;
            yemy = randy * addim;
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Right)
            {
                
                xx = addim;
                yy = 0;
            }
            if (e.KeyData == Keys.Left)
            {
              
                xx = -addim;
                yy = 0;

            }
            if (e.KeyData == Keys.Up)
            {
                xx = 0;
                yy = -addim;
             
            } 
            if (e.KeyData == Keys.Down)
            {
                xx = 0;
                yy = addim;
                
            }
            if (e.KeyData==Keys.Shift)
            {
                timer1.Interval = 100;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
               
           
            for (int i = x.Length - 1; i > 0; i--)
            {
                x[i] = x[i - 1];
                y[i] = y[i - 1];
            }
            
            
            x[0] = x[0] + xx;
            y[0] = y[0] + yy;
            for (int i = 0; i < c; i++)
            {
                if ((x[i] > this.Width) || (x[i] < 0) || (y[i] > this.Height) || (y[i] < 0))
                {
                    timer1.Stop();
                    label2.Text = "oyun bitti";

                }
                //if ((c > 2)&&(i>=1))
                //{
                //    if ((x[i] == x[0]) && (y[i] == y[0]) && (!(x[1] == x[0]) || ((y[1] == y[0]))))
                //    {
                //        timer1.Stop();
                //        label2.Text = "oyun bitti";
                //    }
                //}
                
            }
            for (int i = 1; i < c; i++)
            {

                if (c > 2)
                {
                    if ((x[i] == x[0]) && (y[i] == y[0]) && (!(x[1] == x[0]) && ((y[1] == y[0]))))
                    {
                        timer1.Stop();
                        label2.Text = "oyun bitti";
                    }
                }
            }
            
            
            
            for (int i = 0; i < x.Length; i++)
            {
                        if (i==0)
	                {
		              
                    } 
                if (i>0)
                        {
                                if ((x[i]==x[0])&&(y[i]==y[0]))
                            {
                                 
                            }
                        }
                        
               

            }
            if ((x[0] == yemx) && (y[0] == yemy))
            {

                c = c + 1;

                label1.Text = c.ToString();
                Array.Resize(ref x, c + 1);
                Array.Resize(ref y, c + 1);

                x[0] = yemx;
                y[0] = yemy;
                randx = rand.Next(1, 20);
                randy = rand.Next(1, 20);
                yemx = randx * addim;
                yemy = randy * addim;
            }
            

            
            Invalidate();
        }

        

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            int xx = 20, yy = 0, yemx = 0, yemy = 0, randx = 0, randy = 0, addim = 20;
             c = 1;
            Array.Resize(ref x, 1);
            Array.Resize(ref y, 1);
            Random rand = new Random();
           Form1_Load(sender, e);
           timer1.Start();
           label1.Text = "";
           label2.Text = "";

            

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
            if ( label4.Text == "pausa")
            { timer1.Stop();
            label4.Text = "continue";
            }
            else
            {
                label4.Text = "pausa";
                timer1.Start();
            }
           
        }

        

       

    }
}

