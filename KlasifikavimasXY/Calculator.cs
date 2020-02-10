using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasifikavimasXY
{
    class Calculator
    {
        public Calculator() { }
        #region Formulas_returns_distance_list
        public List<double> Formula1(ObjectTrainer newObject, List<ObjectTrainer> mokAibe)
        {
            List<double> distanceArray = new List<double>();
            for (int i = 0; i < mokAibe.Count; i++)
            {
                double distance = Math.Sqrt(Math.Pow((Convert.ToDouble(newObject.X1) - Convert.ToDouble(mokAibe[i].X1)), 2) + Math.Pow((Convert.ToDouble(newObject.X2) - Convert.ToDouble(mokAibe[i].X2)), 2));
                distanceArray.Add(distance);
                mokAibe[i].Distance = distance;
            }
            return distanceArray;
        }
        public List<double> Formula2(ObjectTrainer newObject, List<ObjectTrainer> mokAibe)
        {
            List<double> distanceArray = new List<double>();
            for (int i = 0; i < mokAibe.Count; i++)
            {
                double distance = Math.Max(Math.Abs(Convert.ToDouble(newObject.X1) - Convert.ToDouble(mokAibe[i].X1)), Math.Abs(Convert.ToDouble(newObject.X2) - Convert.ToDouble(mokAibe[i].X2)));
                distanceArray.Add(distance);
                mokAibe[i].Distance = distance;
            }
            return distanceArray;
        }
        #endregion
        public string getDistArrayString(List<double> array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public void assignClass(ObjectTrainer newObject, List<double> distanceArray, List<ObjectTrainer> mokAibe2, int k)
        {

            // Sorting

            for (int i = 0; i < distanceArray.Count - 1; i++)
                for (int j = 0; j < distanceArray.Count - i - 1; j++)
                    if (distanceArray[j] > distanceArray[j + 1])
                    {
                        double temp1 = distanceArray[j];
                        distanceArray[j] = distanceArray[j + 1];
                        distanceArray[j + 1] = temp1;
                        ObjectTrainer temp2 = mokAibe2[j];
                        mokAibe2[j] = mokAibe2[j + 1];
                        mokAibe2[j + 1] = temp2;
                    }

            // Assigning a class

            int plusCount = 0;
            int minusCount = 0;
            mokAibe2 = mokAibe2.Take(k).ToList();
            for (int i = 0; i < mokAibe2.Count; i++)
            {
                if (mokAibe2[i].ClassName == "+") plusCount++;
                if (mokAibe2[i].ClassName == "-") minusCount++;
            }
            if (plusCount > minusCount) newObject.ClassName = "+";
            else if (plusCount < minusCount) newObject.ClassName = "-";
            else newObject.ClassName = "0";
        }
        public void sortMyList(List<double> distanceArray)
        {
            for (int i = 0; i < distanceArray.Count - 1; i++)
                for (int j = 0; j < distanceArray.Count - i - 1; j++)
                    if (distanceArray[j] > distanceArray[j + 1])
                    {
                        double temp = distanceArray[j];
                        distanceArray[j] = distanceArray[j + 1];
                        distanceArray[j + 1] = temp;
                    }
        }
        public string getMokAibeWithDistances(List<ObjectTrainer> mokAibe)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mokAibe.Count; i++)
            {
                sb.AppendLine($"{i}) x:{mokAibe[i].X1}, y:{mokAibe[i].X2}, class:{mokAibe[i].ClassName}, dist:{mokAibe[i].Distance}");
            }
            return sb.ToString();
        }
    }
}
