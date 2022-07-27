using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IntelligentScissors
{
    public partial class MainForm : Form
    {
               
        static  Pen P;

        bool clickedOn = false;
        public MainForm()
        {
           
                AllocConsole();
                InitializeComponent();
                P = new Pen(Color.Red, 2);
              
            //  myList = new List<List<double>>();
                clickedOn = false;
            
        }   

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        private void MainForm_Load(object sender, EventArgs e)
        {

            Console.WriteLine("I'm in load method!");
           
        }


        private void pictureBox1_Click(object sender, EventArgs q)
        {
            Console.WriteLine("I'm in click method!");
            var e = q as MouseEventArgs;


            if (clickedOn == true) {

                // src= drawPath(src, e, pictureBox1.CreateGraphics());
                //add new width parameter give it ImageOperations.GetWidth(ImageMatrix)
                //add image matrix parameter
                //add graph parameter
                //add pen parameter

                // src=
                dist.X = e.X;
                dist.Y = e.Y;
                Console.WriteLine("Distination: (" + dist.X + ", " + dist.Y + ")");
                src = Priorty_Queue.drawPath(src,dist,pictureBox1.CreateGraphics(), ImageOperations.GetWidth(ImageMatrix),P, graphDict,ImageMatrix);

            }

            //   coordinates srcCpy;
            else {
              // src = new Priorty_Queue.coordinates();
                src.X = e.X;
                src.Y=e.Y;
               
                Console.WriteLine("first time Src: ( " + src.X + ", " + src.Y + " )");
                clickedOn = true;

            }

        }
        Point src,dist;
        Dictionary<int, Dictionary<int, double>> graphDict;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }


        RGBPixel[,] ImageMatrix;



        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
             graphDict = Graph.Get_Graph(ImageMatrix);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            double sigma = double.Parse(txtGaussSigma.Text);
            int maskSize = (int)nudMaskSize.Value;
            ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          //  Priorty_Queue.printParent(ImageOperations.GetWidth(ImageMatrix));
            //Graph.printGraph(Graph.Get_Graph(ImageMatrix), ImageOperations.GetWidth(ImageMatrix) * ImageOperations.GetHeight(ImageMatrix));
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           // if (clickedOn == true)
            {
               
             
             //   src=pq.drawPath(src, e, pictureBox1.CreateGraphics(), ImageOperations.GetWidth(ImageMatrix), ImageMatrix, P);


            }
           

        }





   




    }
} 