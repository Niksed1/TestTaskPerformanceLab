using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace task3
{
    class Program
    {
        class Calculations
        {
            public List<float> Cash1 { get; set; }
            public List<float> Cash2 { get; set; }
            public List<float> Cash3 { get; set; }
            public List<float> Cash4 { get; set; }
            public List<float> Cash5 { get; set; }
            public int interval { get; set; }

            public void FileReading()
            {
                Console.WriteLine("Enter the directory of the catalog: ");
                string dir = Console.ReadLine();


                StreamReader cash1 = new StreamReader($"{dir}\\Cash1.txt");
                StreamReader cash2 = new StreamReader($"{dir}\\Cash2.txt");
                StreamReader cash3 = new StreamReader($"{dir}\\Cash3.txt");
                StreamReader cash4 = new StreamReader($"{dir}\\Cash4.txt");
                StreamReader cash5 = new StreamReader($"{dir}\\Cash5.txt");

                Cash1 = new List<float>();
                Cash2 = new List<float>();
                Cash3 = new List<float>();
                Cash4 = new List<float>();
                Cash5 = new List<float>();

                populateList(cash1, Cash1);
                populateList(cash2, Cash2);
                populateList(cash3, Cash3);
                populateList(cash4, Cash4);
                populateList(cash5, Cash5);

                numPeople();
            }

            public void populateList(StreamReader file, List<float> cash)
            {
                file.BaseStream.Seek(0, SeekOrigin.Begin);

                string line = file.ReadLine();

                while (line != null)
                {
                    float time = float.Parse(line, CultureInfo.InvariantCulture.NumberFormat);
                    cash.Add(time);

                    line = file.ReadLine();
                }
            }
            
            //to find interval when most people are in store
            public void numPeople()
            {
                List<float> sum = new List<float>();

                for(int i=0; i<16; i++)
                {
                    sum.Add(Cash1[i] + Cash2[i] + Cash3[i] + Cash4[i] + Cash5[i]);
                }

                interval = sum.IndexOf(sum.Max()) + 1;
                Console.WriteLine($"Interval with most people: {interval}");
            }

        static void Main(string[] args)
        {
                Calculations calcs = new Calculations();
                calcs.FileReading();

                Console.ReadKey();
            }
    }
}
}
