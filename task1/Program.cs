//C# program task 1

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace task1
{
    class Program
    {
        //class to calculate 90th percentile, median, max/min vals and average value
        //from a list
        class Calculations
        {
            public List<int> data { get; set; }
            private int listLength { get; set; }
            public void FileReading()
            {
                Console.WriteLine("Enter the directory of the file: ");
                string dir = Console.ReadLine();

                StreamReader file = new StreamReader(dir);
                data = new List<int>();
                int number;

                // start at the beg of the file
                file.BaseStream.Seek(0, SeekOrigin.Begin);

                string line = file.ReadLine();
 
                while (line != null)
                {
                    bool isParsable = Int32.TryParse(line, out number);
                    if(isParsable)
                    {
                        data.Add(number);
                        line = file.ReadLine();
                    }
                }


                //sorting a list
                data.Sort();
                listLength = data.Count;

                file.Close();
            }

            public void Percentile90th()
            {
                //List.Percentile(data, 0.90); ??
                double n = (listLength - 1) * 0.9 + 1;
                // Another method: double n = (N + 1) * excelPercentile;
                if (n == 1d) Console.WriteLine(string.Format("{0:0.00}", data[0]));
                else if (n == listLength) Console.WriteLine(string.Format("{0:0.00}", data[listLength - 1]));
                else
                {
                    int k = (int)n;
                    double d = n - k;
                    Console.WriteLine(string.Format("{0:0.00}", data[k - 1] + d * (data[k] - data[k - 1])));
                }
            }

            public void Median()
            {

                if (listLength % 2 == 0)
                {
                    int sum = data[listLength / 2] + data[(listLength / 2)];
                    double median = (double)sum / 2;
                    Console.WriteLine(string.Format("{0:0.00}", median));
                }
                else
                    Console.WriteLine(string.Format("{0:0.00}", data[listLength / 2]));
            }

            public void MaxVal()
            {
                Console.WriteLine(string.Format("{0:0.00}", data[listLength - 1]));
            }

            public void MinVal()
            {
                Console.WriteLine(string.Format("{0:0.00}", data[0]));
            }

            public void AvgVal()
            {
                Console.WriteLine(string.Format("{0:0.00}", data.Average()));
            }
        }

        static void Main(string[] args)
        {
            Calculations file = new Calculations();
            file.FileReading();
            file.Percentile90th();
            file.Median();
            file.MaxVal();
            file.MinVal();
            file.AvgVal();
        }

    }
}
