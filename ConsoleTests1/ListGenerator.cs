using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests1
{
    class ListGenerator
    {
        static string path = "C:\\Users\\Tomas\\OneDrive - Vilniaus kolegija\\3_Kursas\\Intelektika\\Duomenu_bazes_darbams\\varzybos.csv";
        List<string> trainData = File.ReadAllLines(path).ToList();
        public ListGenerator() { }
        public string getColumnName(int index)
        {
            return trainData[0].Split(',').ToList()[index];
        }
        public string getTypeName(List<string> typeList,int index)
        {
            return typeList[index];
        }
        public List<string> getListOfClass(int index)
        {
            List<string> output = new List<string>();
            for (int i = 1; i < trainData.Count; i++)
            {
                if (!output.Contains(trainData[i].Split(',').ToList()[index]))
                {
                    output.Add(trainData[i].Split(',').ToList()[index]);
                }
            }
            return output;
        }
        public List<string> getClassAndPlayPair(int columnIndex)
        {
            List<string> output = new List<string>();
            string result;
            for(int i=1; i<trainData.Count;i++)
            {
                result = $"{trainData[i].Split(',').ToList()[columnIndex]},{trainData[i].Split(',').ToList()[5]}";
                output.Add(result);
            }
            return output;
        }
    }
}
