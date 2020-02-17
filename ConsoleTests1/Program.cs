﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            ListGenerator listGenerator = new ListGenerator();
            // 1: Outlook
            // 2: Temperature
            // 3: Humidity
            // 4: Wind
            int columnIndex;
            List<string> classList;
            string columnName;
            List<string> columnTypesListPairedWithPlay;

            for (columnIndex = 1; columnIndex <= 4; columnIndex++)
            {
                columnTypesListPairedWithPlay = listGenerator.getClassAndPlayPair(columnIndex);
                classList = listGenerator.getListOfClass(columnIndex);
                columnName = listGenerator.getColumnName(columnIndex);
                Console.WriteLine($"{columnName} Gini index: {calculator.calculateClassGI_By_Pairs(columnTypesListPairedWithPlay, classList)}");
                for(int i=0;i< classList.Count; i++)
                {
                    Console.WriteLine($"{listGenerator.getTypeName(classList, i)} Gini index: {calculator.calculateClassTypeGI_Class_Play_pairs(columnTypesListPairedWithPlay,classList[i])}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static void printMyList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{list[i]} ");
        }
    }
}