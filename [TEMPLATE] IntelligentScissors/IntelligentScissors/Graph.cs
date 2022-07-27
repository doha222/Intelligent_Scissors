using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace IntelligentScissors
{
    public struct Vertex
    {
        public int SRC;
        public int DIST;
        public double weight;

        public Vertex(int SRC, int DIST, double weight)
        {
            this.SRC = SRC;
            this.DIST = DIST;
            this.weight = weight;
        }
    } 
    public class Graph
    {
 
        //Begin OF GRAPH CONSTRUCTION Function ....
        public static Dictionary<int ,Dictionary<int,double>> Get_Graph(RGBPixel[,] ImageMatrix){

            Dictionary<int, Dictionary<int, double>> My_graph = new Dictionary<int, Dictionary<int, double>>();
            int height = ImageOperations.GetHeight(ImageMatrix);
            int width = ImageOperations.GetWidth(ImageMatrix);
            int parent;
            const double infinity = 10000000000000;
            Vertex adj;
            for (int i = 0; i < height; i++) // Row
            {
             
                for (int j = 0; j < width; j++) //Column
                {
                    double weights;
                    int indices;
                    parent = (i * width)+j; //position
                    Dictionary<int, double> pair = new Dictionary<int, double>();
                    if (i == 0) // first row
                    {
                        if (j == 0)
                        {

                            //bottom
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if(adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = ((i + 1) * width) + j;
                            pair.Add(indices, weights);
                            //right
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).X;
                            weights=1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices =(i * width) + (j + 1);

                             pair.Add(indices, weights);

        }
                        else if (j == width - 1)
                        {
                            //bottom
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = ((i + 1) * width) + j;

                            pair.Add(indices, weights);

                      
                          //  My_graph.Add(parent, pair);


                            //left
                            adj.weight = ImageOperations.CalculatePixelEnergies(j - 1, i, ImageMatrix).X;
                            weights=1 / adj.weight;
                            if (adj.weight==0)
                            {
                                weights = infinity;

                            }
                            indices =(i * width) + (j - 1);
                            pair.Add(indices, weights);
                         //   My_graph.Add(parent, pair);



                        }
                        else
                        {
                            //bottom
                            //bottom
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = ((i + 1) * width) + j;

                            pair.Add(indices, weights);

                            
                            //My_graph.Add(parent, pair);
                            //left
                            adj.weight = ImageOperations.CalculatePixelEnergies(j - 1, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j - 1);
                            pair.Add(indices, weights);
                           // My_graph.Add(parent, pair);

                            //right
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j + 1);

                            pair.Add(indices, weights);
                           // My_graph.Add(parent, pair);

                        }
                    }
                    else if (j == 0) //fisrt column
                    {

                        if (i == height - 1)
                        {
                            //bottom
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = ((i + 1) * width) + j;

                            pair.Add(indices, weights);
                            // My_graph.Add(parent, pair);
                            //right
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j + 1);

                            pair.Add(indices, weights);
                          //  My_graph.Add(parent, pair);
                        }
                        else
                        {
                            //bottom
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                                    if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = ((i + 1) * width) + j;

                            pair.Add(indices, weights);
                            //  My_graph.Add(parent, pair);

                            //up
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i - 1, ImageMatrix).Y;
                            weights=1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices =(i - 1) * width + j;
                            pair.Add(indices, weights);
                         //   My_graph.Add(parent, pair);

                            //right
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j + 1);

                            pair.Add(indices, weights);
                          //  My_graph.Add(parent, pair);
                        }

                    }
                    else if (i == height - 1)
                    {

                        if (j == width - 1)
                        {
                            //up
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i - 1, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i - 1) * width + j;
                            pair.Add(indices, weights);
                           // My_graph.Add(parent, pair);
                            //left
                            adj.weight = ImageOperations.CalculatePixelEnergies(j - 1, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j - 1);
                            pair.Add(indices, weights);
                            //My_graph.Add(parent, pair);


                        }
                        else
                        {
                            //up
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i - 1, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i - 1) * width + j;
                            pair.Add(indices, weights);
                            //My_graph.Add(parent, pair);

                            //right
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j + 1);

                            pair.Add(indices, weights);
                            //My_graph.Add(parent, pair);

                            //left
                            adj.weight = ImageOperations.CalculatePixelEnergies(j - 1, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j - 1);
                            pair.Add(indices, weights);
                           // My_graph.Add(parent, pair);



                        }
                    }
                    else if (j == width - 1)
                    {

                        if (i == height - 1)
                        {

                            //left
                            adj.weight = ImageOperations.CalculatePixelEnergies(j - 1, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j - 1);
                            pair.Add(indices, weights);
                           // My_graph.Add(parent, pair);


                            //up
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i - 1, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i - 1) * width + j;
                            pair.Add(indices, weights);
                           // My_graph.Add(parent, pair);
                        }

                        else
                        {


                            //bottom
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = ((i + 1) * width) + j;

                            pair.Add(indices, weights);
                            // My_graph.Add(parent, pair);
                            //up
                            adj.weight = ImageOperations.CalculatePixelEnergies(j, i - 1, ImageMatrix).Y;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i - 1) * width + j;
                            pair.Add(indices, weights);
                           // My_graph.Add(parent, pair);
                            //left
                            adj.weight = ImageOperations.CalculatePixelEnergies(j - 1, i, ImageMatrix).X;
                            weights = 1 / adj.weight;
                            if (adj.weight == 0)
                            {
                                weights = infinity;

                            }
                            indices = (i * width) + (j - 1);
                            pair.Add(indices, weights);
                            //My_graph.Add(parent, pair);

                        }
                    }
                    else
                    {
                        //bottom
                        //bottom
                        adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).Y;
                        weights = 1 / adj.weight;
                        if (adj.weight == 0)
                        {
                            weights = infinity;

                        }
                        indices = ((i + 1) * width) + j;

                        pair.Add(indices, weights);
                        //My_graph.Add(parent, pair);
                        //up
                        adj.weight = ImageOperations.CalculatePixelEnergies(j, i - 1, ImageMatrix).Y;
                        weights = 1 / adj.weight;
                        if (adj.weight == 0)
                        {
                            weights = infinity;

                        }
                        indices = (i - 1) * width + j;
                        pair.Add(indices, weights);
                      //  My_graph.Add(parent, pair);
                        //right
                        adj.weight = ImageOperations.CalculatePixelEnergies(j, i, ImageMatrix).X;
                        weights = 1 / adj.weight;
                        if (adj.weight == 0)
                        {
                            weights = infinity;

                        }
                        indices = (i * width) + (j + 1);

                        pair.Add(indices, weights);
                       // My_graph.Add(parent, pair);

                        //left
                        adj.weight = ImageOperations.CalculatePixelEnergies(j - 1, i, ImageMatrix).X;
                        weights = 1 / adj.weight;
                        if (adj.weight == 0)
                        {
                            weights = infinity;

                        }
                        indices = (i * width) + (j - 1);
                        pair.Add(indices, weights);
                      //  My_graph.Add(parent, pair);

                    }

                    My_graph.Add(parent, pair);

                }

            }

            int sz = width * height;
            string fileName = @"C:\Users\First\OneDrive\Desktop\final\[TEMPLATE] IntelligentScissors\Testcases\Sample\Case1\out.txt";
            StreamWriter fs;
            fs = File.AppendText(fileName);
            for (int m = 0; m < sz; m++)
            {
                //   int pos = (j * width) + i;
                fs.Write("The Node index is:");
                fs.WriteLine(m);
                foreach (var x in My_graph[m])
                {
                    fs.Write("The weight is:");
                    fs.WriteLine(x.Value);

                }


            }

            fs.Close();

            Console.WriteLine("In graph");
            return My_graph;


        }

    }
}








