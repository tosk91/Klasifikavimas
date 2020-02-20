using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Calculator
    {
        public double calculateClassTypeGI_Class_Play_pairs(List<string> typePairs, string typeName) // Skaiciuoja gerai
        {
            int tempYesCount = 0, tempNoCount = 0;
            for (int i = 0; i < typePairs.Count; i++)
            {
                if (typePairs[i].Contains(typeName) && typePairs[i].Contains("yes")) tempYesCount++;
                else if (typePairs[i].Contains(typeName) && typePairs[i].Contains("no")) tempNoCount++;
            }
            return 1 - Math.Pow(Convert.ToDouble(tempYesCount) / Convert.ToDouble(tempYesCount + tempNoCount), 2) - Math.Pow(Convert.ToDouble(tempNoCount) / Convert.ToDouble(tempYesCount + tempNoCount), 2);
        }
        public double calculateClassGI_By_Pairs(List<string> classTypesNamesPair, List<string> classTypes) // Skaiciuoja gerai
        {
            // calculate different types GI: (Outlook: Sunny, Rain, Overcast)
            double[] classTypesGIs = new double[classTypes.Count];
            int[] typeOccurences = new int[classTypes.Count];
            for (int i = 0; i < classTypes.Count; i++)
            {
                classTypesGIs[i] = calculateClassTypeGI_Class_Play_pairs(classTypesNamesPair, classTypes[i]);
                for (int j = 0; j < classTypesNamesPair.Count; j++)
                    if (classTypesNamesPair[j].Contains(classTypes[i])) typeOccurences[i]++;
            }
            // calculate whole column GI: (Outlook, Temperature,Humidity, Wind)
            double result = 0;
            int typeOccurencesSum = 0;
            for (int i = 0; i < typeOccurences.Length; i++)
                typeOccurencesSum += typeOccurences[i];
            for (int i = 0; i < classTypes.Count; i++)
                result += Convert.ToDouble(typeOccurences[i]) / Convert.ToDouble(typeOccurencesSum) * classTypesGIs[i];
            return result;
        }
        public double getLowestGI(List<double> GIList)
        {
            double min = 999;
            foreach (double item in GIList)
            {
                if (item == 0) { }
                else if (item <= min) min = item;
            }
            return min;
        }
    }
}
