using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace task4
{
    class Program
    {
        class Visitor
        {
            public Visitor() { }
            public Visitor (string e, string ex)
            {

                string[] time1 = e.Split(':');
                string[] time2 = ex.Split(':');

                enter = Int32.Parse(time1[0]) * 60 + Int32.Parse(time1[1]);
                exit = Int32.Parse(time2[0]) * 60 + Int32.Parse(time2[1]);

            }
            public int enter { get; set; } //time in
            public int exit { get; set; } //time out
            public int numV { get; set; }

        }
        class Calculations
        {
            public List<Visitor> times;

            public void FileReading()
            {

                Console.WriteLine("Enter the directory of the file: ");
                string dir1 = Console.ReadLine();

                StreamReader file1 = new StreamReader(dir1);
                times = new List<Visitor>();

                //populate array with times
                file1.BaseStream.Seek(0, SeekOrigin.Begin);

                string line = file1.ReadLine();

                while (line != null)
                {
                    string[] coords = line.Split(' ');

                    times.Add(new Visitor(coords[0], coords[1]));
                    line = file1.ReadLine();
                }

                Visitor maxV = new Visitor();
                maxV = Count(times);

                print(maxV);

              //  inMinutes = new List<Visitor>();
              //hrsToMinutes();

            }

            public Visitor Count(List<Visitor> visitors)
            {
                Visitor maxV = new Visitor();

                HashSet<int> times = convertTime(visitors);

                int count = 0;
                int max = 0;
                int ent = 0;
                int ex = 0;

                foreach (int t in times)
                {
                    //calculating num visitors at each interval
                    foreach (Visitor v in visitors)
                    {
                        if (t >= v.enter & t <= v.exit)
                            count++;
                    }

                    if (count > max)
                    {
                        max = count;
                        ent = t;
                        ex = t;

                    }
                    else if (count == max)
                        ex = t;

                    count = 0;
                }

                //assignment missing
                maxV.enter = ent;
                maxV.exit = ex;
                maxV.numV = max;

                return maxV;

            }

            public HashSet<int> convertTime(List<Visitor> visitors)
            {
                HashSet<int> times = new HashSet<int>();

                foreach (Visitor v in visitors)
                {

            //      Console.WriteLine($"enter time: {v.enter}");

                    times.Add(v.enter);
                    times.Add(v.exit);
                }
                return times;
            }

            public void print(Visitor maxV)
            {
                string enter;
                string exit;
                int hrs = 0;
                int mins = 0;

                hrs = maxV.enter / 60;
                mins = maxV.enter % 60;
                if (mins < 10)
                    enter = hrs.ToString() + ":0" + mins;
                else
                    enter = hrs.ToString() + ":" + mins;

                hrs = maxV.exit / 60;
                mins = maxV.exit % 60;
                if (mins < 10)
                    exit = hrs.ToString() + ":0" + mins;
                else
                    exit = hrs.ToString() + ":" + mins;

                Console.WriteLine($"Get in: {enter} Get out: {exit} Visitors: {maxV.numV}");
            }

        }
        static void Main(string[] args)
        {
            Calculations calcs = new Calculations();
            calcs.FileReading();
        }
    }
}
