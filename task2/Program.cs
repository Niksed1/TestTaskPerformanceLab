using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace task2
{
    class Program
    {
        class Coordinates
        {
            public Coordinates(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
            public float x { get; set; }
            public float y { get; set; }
        }

        class Calculations
        {
            public List<float> coordinatesX { get; set; }
            public List<float> coordinatesY { get; set; }
            public List<Coordinates> arguments { get; set; }

            public void FileReading()
            {
                Console.WriteLine("Enter the directory of the file1: ");
                string dir1 = Console.ReadLine();

                Console.WriteLine("Enter the directory of the file2: ");
                string dir2 = Console.ReadLine();

                StreamReader file1 = new StreamReader(dir1);
                StreamReader file2 = new StreamReader(dir2);

                coordinatesX = new List<float>();
                coordinatesY = new List<float>();
                arguments = new List<Coordinates>();

                //reading coordinates into a list
                file1.BaseStream.Seek(0, SeekOrigin.Begin);

                string line = file1.ReadLine();

                while (line != null)
                {
                    string[] coords = line.Split(' ');
                   // Console.WriteLine(coords[1]);
                   //to parse through dot as a float using culture info
                    float cord1 = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
                    float cord2 = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);

                    coordinatesX.Add(cord1);
                    coordinatesY.Add(cord2);
                    line = file1.ReadLine();
                }

                //reading arguments into a list
                file2.BaseStream.Seek(0, SeekOrigin.Begin);

                line = file2.ReadLine();

                while (line != null)
                {
                    string[] coords = line.Split(' ');
                    //to parse through dot as a float using culture info
                    float cord1 = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
                    float cord2 = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);

                    arguments.Add(new Coordinates(cord1, cord2));
                    line = file2.ReadLine();
                }

                /* Debugging
                foreach (Coordinates i in arguments)
                {
                    Console.WriteLine(i.x);
                    Console.WriteLine(i.y);
                }
                */

                coordinatesY.Sort();
                coordinatesX.Sort();
                bool isVertex;

                for(int i=0; i<arguments.Count; i++)
                {
                    isVertex = false;

                    for (int k=0; k<4; k++)
                    {
                        if (arguments[i].x == coordinatesX[k] & arguments[i].y == coordinatesY[k])
                        {
                         // Console.WriteLine($"argx = {arguments[i].x} coordx = {coordinatesX[k]} argy = {arguments[i].y} coordy = {coordinatesY[k]}");
                            Console.WriteLine(0); //точка на одной из вершин
                            isVertex = true;
                            break;
                        }
                    }

                    if(!isVertex)
                    {
                        if ((coordinatesX.Contains(arguments[i].x) | coordinatesY.Contains(arguments[i].y)) & arguments[i].x <= coordinatesX[3] & arguments[i].x >= coordinatesX[0] &
                               arguments[i].y <= coordinatesY[3] & arguments[i].y >= coordinatesY[0])
                        { 
                         //   Console.WriteLine($"argx = {arguments[i].x} coordxmax = {coordinatesX[3]} argy = {arguments[i].y} coordymax = {coordinatesY[3]} " +
                         //       $"coordxmin = {coordinatesX[0]} coordymin = {coordinatesY[0]} x cointaints argx {coordinatesX.Contains(arguments[i].x)} y cointaints argy {coordinatesY.Contains(arguments[i].y)}");
                         //   Console.WriteLine(arguments[i].y >= coordinatesY[0]);
                            Console.WriteLine(1);
                        }

                        else if (arguments[i].x <= coordinatesX[3] & arguments[i].x >= coordinatesX[0] &
                        arguments[i].y <= coordinatesY[3] & arguments[i].y >= coordinatesY[0])
                            Console.WriteLine(2);
                        else
                            Console.WriteLine(3);
                    }

                    
                }
                
            }

        }

        static void Main(string[] args)
        {
            Calculations calcs = new Calculations();
            calcs.FileReading();
        }
    }
}
