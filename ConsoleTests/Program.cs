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
            string path = "C:\\Users\\Tomas\\OneDrive - Vilniaus kolegija\\3_Kursas\\Intelektika\\Duomenu_bazes_darbams\\varzybos.csv";
            List<string> trainData = File.ReadAllLines(path).ToList();
            //DataTable dt = ConvertCSVtoDataTable(path);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < trainData.Count; i++)
                sb.AppendLine(trainData[i]);
            Console.WriteLine(sb.ToString());
            Console.WriteLine("Suskaidau kiekviena eilute i dvimati masyva:\n");

            string[,] attributesTable = DivideInto2DArray(trainData);

            Print2DArray(attributesTable, trainData);

            //Console.WriteLine("\nPrinting DataTable from file:\n");
            //PrintDataTable(dt);
            
            int sunnyCount = 0, rainCount = 0, overcastCount = 0, coolCount = 0, mildCount = 0, hotCount = 0, normalCount = 0, highCount = 0, weakCount = 0, strongCount = 0, yesCount = 0, noCount = 0;
            for (int i = 0; i < trainData.Count; i++)
            {
                if (trainData[i].Contains("sunny")) sunnyCount++;
                if (trainData[i].Contains("rain")) rainCount++;
                if (trainData[i].Contains("overcast")) overcastCount++;
                if (trainData[i].Contains("cool")) coolCount++;
                if (trainData[i].Contains("mild")) mildCount++;
                if (trainData[i].Contains("hot")) hotCount++;
                if (trainData[i].Contains("normal")) normalCount++;
                if (trainData[i].Contains("high")) highCount++;
                if (trainData[i].Contains("weak")) weakCount++;
                if (trainData[i].Contains("strong")) strongCount++;
                if (trainData[i].EndsWith("no")) noCount++;
                if (trainData[i].EndsWith("yes")) yesCount++;
            }
            List<int> typesOccurencesCountList = new List<int>() { sunnyCount, rainCount, overcastCount, coolCount, mildCount, hotCount, normalCount, highCount, weakCount, strongCount };
            Console.Write($"\nSunny count: {sunnyCount}" +
                    $"\nRain count: {rainCount}"+
                    $"\nOvercast count: {overcastCount}"+
                    $"\nCool count: {coolCount}"+
                    $"\nMild count: {mildCount}"+
                    $"\nHot count: {hotCount}"+
                    $"\nNormal count: {normalCount}"+
                    $"\nHigh count: {highCount}"+
                    $"\nWeak count: {weakCount}"+
                    $"\nStrong count: {strongCount}"+
                    $"\nYes count: {yesCount}"+
                    $"\nNo count: {noCount}");

            int[] outlookCounts = new int[3] { sunnyCount,rainCount,overcastCount};
            int[] temperatureCounts = new int[3] { coolCount, mildCount, hotCount };
            int[] humidityCounts = new int[2] { normalCount, highCount };
            int[] windCounts = new int[2] { weakCount, strongCount };
            int[] decisionCounts = new int[2] { yesCount, noCount };

            string typeName = "hot";
            Console.WriteLine($"\n{typeName} GI: {calculateClassTypeGI(trainData, typeName)}");

            List<string> outlooks = new List<string>() { "sunny", "rain", "overcast" };
            Console.WriteLine($"\nOutlooks GI: {calculateClassGI(trainData, outlooks)}");

            List<string> temperatures = new List<string>() { "cool", "mild", "hot" };
            Console.WriteLine($"\nTemperatures GI: {calculateClassGI(trainData, temperatures)}");

            List<string> humidity = new List<string>() { "normal", "high" };
            Console.WriteLine($"\nHumidity GI: {calculateClassGI(trainData, humidity)}");

            List<string> wind = new List<string>() { "weak", "strong" };
            Console.WriteLine($"\nWind GI: {calculateClassGI(trainData, wind)}");

            Console.ReadKey();
        }

        #region utility functions
        static string[,] DivideInto2DArray(List<string> trainData)
        {
            string[,] output = new string[trainData.Count, trainData[0].Split(',').Count()];
            for (int i = 0; i < trainData.Count; i++)
                for (int j = 0; j < trainData[0].Split(',').Count(); j++)
                    output[i, j] = trainData[i].Split(',')[j];
            return output;
        }
        static void Print2DArray(string[,] attributesTable, List<string> trainData)
        {
            for (int i = 0; i < trainData.Count; i++)
            {
                for (int j = 0; j < trainData[0].Split(',').Count(); j++)
                    Console.Write($"{attributesTable[i, j]} ");
                Console.WriteLine();
            }
        }
        static double calculatePropertyGI(int yesCount, int noCount)
        {
            return 1 - Math.Pow(Convert.ToDouble(yesCount) / Convert.ToDouble(yesCount + noCount), 2) - Math.Pow(Convert.ToDouble(noCount) / Convert.ToDouble(yesCount + noCount), 2);
        }
        static double calculateClassTypeGI(List<string> trainData, string typeName)
        {
            int tempYesCount = 0, tempNoCount = 0;
            for (int i = 0; i < trainData.Count; i++)
            {
                if (trainData[i].Contains(typeName) && trainData[i].EndsWith("yes")) tempYesCount++;
                else if (trainData[i].Contains(typeName) && trainData[i].EndsWith("no")) tempNoCount++;
            }
           return calculatePropertyGI(tempYesCount, tempNoCount);
        }
        static double calculateClassGI(List<string> trainData, List<string> classTypesNames)
        {
            double[] classTypesGIs = new double[classTypesNames.Count];
            int[] typeOccurences = new int[classTypesNames.Count];
            for (int i = 0; i < classTypesNames.Count; i++)
            {
                classTypesGIs[i] = calculateClassTypeGI(trainData, classTypesNames[i]);
                for (int j = 0; j < trainData.Count; j++)
                    if (trainData[j].Contains(classTypesNames[i])) typeOccurences[i]++;
            }
            double result = 0;
            int typeOccurencesSum = 0;
            for (int i = 0; i < typeOccurences.Length; i++)
                typeOccurencesSum += typeOccurences[i];
            for (int i = 0; i < classTypesNames.Count; i++)
                result += Convert.ToDouble(typeOccurences[i]) / Convert.ToDouble(typeOccurencesSum) * classTypesGIs[i];
            return result;
        }
        //static DataTable ConvertCSVtoDataTable(string path)
        //{
        //    StreamReader sr = new StreamReader(path);
        //    string[] headers = sr.ReadLine().Split(',');
        //    DataTable dt = new DataTable("Varzybu_Duomenys");
        //    foreach (string header in headers)
        //        dt.Columns.Add(header);
        //    while (!sr.EndOfStream)
        //    {
        //        string[] rows = new string[sr.ReadLine().Split(',').Count()];
        //        rows = sr.ReadLine().Split(',');
        //        DataRow row = dt.NewRow();
        //        for (int i = 0; i < headers.Length; i++)
        //            row[i] = rows[i];
        //        dt.Rows.Add(row);
        //    }
        //    return dt;
        //}
        //static void PrintDataTable(DataTable dt)
        //{
        //    foreach (DataRow dataRow in dt.Rows)
        //        foreach (var item in dataRow.ItemArray)
        //            Console.WriteLine(item);
        //}
        #endregion
    }
}
