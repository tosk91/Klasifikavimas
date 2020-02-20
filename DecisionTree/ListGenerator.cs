using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class ListGenerator
    {
        //static string path = "C:\\Users\\Tomas\\OneDrive - Vilniaus kolegija\\3_Kursas\\Intelektika\\Duomenu_bazes_darbams\\Balloons\\adult_stretch.csv";
        static string path = "C:\\Users\\Tomas\\OneDrive - Vilniaus kolegija\\3_Kursas\\Intelektika\\Duomenu_bazes_darbams\\varzybos.csv";
        List<string> trainData = File.ReadAllLines(path).ToList();
        public ListGenerator() { }
        public string getColumnName(int index)
        {
            return trainData[0].Split(',').ToList()[index];
        }
        public string getTypeName(List<string> typeList, int index)
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
            for (int i = 1; i < trainData.Count; i++)
            {
                result = $"{trainData[i].Split(',').ToList()[columnIndex]},{trainData[i].Split(',').ToList()[5]}";
                output.Add(result);
            }
            return output;
        }
        public List<string> getClassAndGIPair(int columnIndex)
        {
            List<string> output = new List<string>();
            string result;
            Calculator calc = new Calculator();
            for (int i = 1; i < trainData.Count; i++)
            {
                result = $"{trainData[i].Split(',').ToList()[columnIndex]},{calc.calculateClassTypeGI_Class_Play_pairs(getClassAndPlayPair(columnIndex), trainData[i].Split(',').ToList()[columnIndex])}";
                if (output.Contains(trainData[i].Split(',').ToList()[columnIndex]))
                {

                    output.Add(result);
                }
            }
            return output;
        }
        public List<double> getGIList()
        {
            Calculator calculator = new Calculator();
            List<double> templist = new List<double>();
            List<string> columnTypesListPairedWithPlay, classList;
            for (int i = 1; i <= 4; i++)
            {
                columnTypesListPairedWithPlay = getClassAndPlayPair(i);
                classList = getListOfClass(i);
                templist.Add(calculator.calculateClassGI_By_Pairs(columnTypesListPairedWithPlay, classList));
            }
            return templist;
        }
        public List<string> getGIandClassPair()
        {
            List<double> GIList = getGIList();
            List<string> outputList = new List<string>();
            for (int i = 1; i <= GIList.Count; i++)
                outputList.Add($"{getColumnName(i)},{GIList[i - 1]}");
            return outputList;
        }
        public List<string> sortedGIandClassNamePairsList(List<string> myPairsList)
        {
            List<double> GIList = getGIList();
            for (int i = 0; i < GIList.Count - 1; i++)
            {
                if (GIList[i] >= GIList[i + 1])
                {
                    double temp = GIList[i];
                    GIList[i] = GIList[i + 1];
                    GIList[i + 1] = temp;
                    string temp1 = myPairsList[i];
                    myPairsList[i] = myPairsList[i + 1];
                    myPairsList[i + 1] = temp1;
                }
            }
            return myPairsList;
        }
        public List<string> classTypeAndPlayPairs()
        {
            int columnIndex;
            string columnName = "";
            List<string> columnTypesListPairedWithPlay, classList;
            Calculator calculator = new Calculator();
            List<string> output = new List<string>();

            for (columnIndex = 1; columnIndex <= 4; columnIndex++)
            {
                columnTypesListPairedWithPlay = getClassAndPlayPair(columnIndex);
                classList = getListOfClass(columnIndex);
                columnName = getColumnName(columnIndex);

                for (int i = 0; i < classList.Count; i++)
                {
                    output.Add($"{getTypeName(classList, i)},{calculator.calculateClassTypeGI_Class_Play_pairs(columnTypesListPairedWithPlay, classList[i])}");
                }
            }

            return output;
        }
        //public List<string> getTypeAndGIPairs(int index)
        //{

        //}
    }
}
