using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "C:\\Users\\Tomas\\OneDrive - Vilniaus kolegija\\3_Kursas\\Intelektika\\Duomenu_bazes_darbams\\varzybos.csv";
            //List<string> trainData = File.ReadAllLines(path).ToList();
            ListGen listGen = new ListGen();

            List<Header> headers = listGen.getHeaders();
            for (int i = 0; i < headers.Count; i++)
                Console.WriteLine($"{headers[i]}");


            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
