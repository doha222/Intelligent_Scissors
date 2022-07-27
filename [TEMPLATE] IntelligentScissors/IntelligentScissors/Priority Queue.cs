using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Priority_Queue;

namespace IntelligentScissors
{
    class Priorty_Queue
    {
        public static int pixelToIndex(int x, int y, int width) 
        {

            int index = y * width + x;

            return index;
        }
       
      
           
        public static  Dictionary<int, int> DisjkstraDistance(int src, int dist, Dictionary<int, Dictionary<int, double>> graphDict,RGBPixel[,] ImageMatrix)

        {
            //OutPut File
            string fileName = @"C:\Users\First\OneDrive\Desktop\final\[TEMPLATE] IntelligentScissors\Testcases\Sample\Case1\OutShort.txt";
            StreamWriter fs;
             fs = File.AppendText(fileName);
          
            int width = ImageOperations.GetWidth(ImageMatrix);
            int height = ImageOperations.GetHeight(ImageMatrix);
            int size = height * width;
            //graph output will be queue's input 
            SimplePriorityQueue<int, double> priority_queue = new SimplePriorityQueue<int, double>();
            priority_queue.Enqueue(src, 0);
            //Dictionry of distances for each vertex
            Dictionary<int, double> distances = new Dictionary<int, double>
            {
                { src, 0 }
            };
           //Dictionary of parent for each vertex
           // key-> child value->parent
            Dictionary<int, int> parent = new Dictionary<int, int>
            {
                { src, -1 }
            };
              //parent = Enumerable.Repeat(-1, size).ToArray();       
            Dictionary<int, string> dequeued = new Dictionary<int, string>();
            while (!(priority_queue.Count == 0))
            {
                int value;
                string status;
                value = priority_queue.Dequeue();
                status = "black";
                dequeued.Add(value, status);
                //black(visited) dont visit agian
                //white(not visited ) weight infinity 
                //grey not sure

                if (value == dist)
                {
                    break;
                }
                
                //fs.WriteLine(dist + " Node: " + parent[dist]/*+ " at position X = " + parent[dist] % width + ", and  position Y= " + parent[dist] / width*/);
               
                foreach (var neighbors in graphDict[value])
                {

                    if (!dequeued.ContainsKey(neighbors.Key)) // check if it not black
                    {
                        if (priority_queue.Contains(neighbors.Key)) //if true it means that is grey
                        {
                            //check if path is less than stored
                            if (distances[neighbors.Key] > neighbors.Value + distances[value])
                            {
                                //update in distance and parent
                                priority_queue.UpdatePriority(neighbors.Key, neighbors.Value + distances[value]);
                                distances[neighbors.Key] = neighbors.Value + distances[value];
                                parent[neighbors.Key] = value;
                            }
                        }
                        else // white
                        {

                            //update value from infitinty 
                            priority_queue.Enqueue(neighbors.Key, neighbors.Value + distances[value]);
                            distances.Add(neighbors.Key, neighbors.Value + distances[value]);
                            parent.Add(neighbors.Key, value);
                        }
                      
                    }

                }

                //Console.WriteLine("Min:" + Min);
                //onsole.WriteLine("Count:"+distances.Count);
                //Console.WriteLine("Dist index:"+dist);
                foreach (var d in parent)
                {
                    fs.WriteLine(d+ " Node: " + d.Value+ " at position X = " + parent[d.Key] % width + ", and  position Y= " + parent[d.Key] / width);

                }    

            }
            fs.Close();
            return parent;
        }

      
        public static List<Point> BackTrack(Dictionary<int, int> Parent, int dist , int width)
        {
            List<Point> Path = new List<Point>();
            Stack<int> indices = new Stack<int>();
            int parentIndex;
            
            //starting from destination to the source

            parentIndex = Parent[dist];
                while (parentIndex != -1)
                {
                    indices.Push(parentIndex);
                    parentIndex = Parent[parentIndex];
                }
                 Console.WriteLine("indices just added! count:");


            Point point = new Point();
            // convert indices to points to use it in drawing 
            while (indices.Count!=0)

            {
              
                int calc = indices.Pop();
                point.X = calc % width;
                point.Y = calc / width;

                Path.Add(point);
            }

            Console.WriteLine("In backtrack");
            return Path;

        }

        public static Point drawPath(Point src,Point dist, Graphics g, int width, Pen P,Dictionary<int, Dictionary<int, double>> graphDict,RGBPixel[,] ImageMatrix)
        {
            Dictionary<int, int> parents;
            List<Point> points;
            int srcInd;
            int distInd;
            
            Console.WriteLine("Source:  (" + src.X + ", " + src.Y + ")");

            srcInd = pixelToIndex(src.X, src.Y, width);
            distInd =pixelToIndex(dist.X, dist.Y, width);
            parents = DisjkstraDistance(srcInd, distInd,graphDict,ImageMatrix);
            points = BackTrack(parents, distInd, width);


            for (int i = 0; i < points.Count; i++)
            {

                //count-1 --> source
               if(i<points.Count-1)
                {
                    g.DrawLine(P, points[i], points[i + 1]);
                    Console.WriteLine("From src: (" + points[i].X + " , " + points[i].Y + ") to point: ( " + points[i + 1].X + ", " + points[i + 1].Y + ")");
                    Console.WriteLine("In second condition ");

                }
            
            }
            Console.WriteLine("In drawpath");
            return dist;

        }

     }
 }
           



