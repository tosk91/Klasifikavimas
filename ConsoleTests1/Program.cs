using System;
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
            string columnName="";
            List<string> columnTypesListPairedWithPlay, classList, typeGIPairs = new List<string>();
            
            for (columnIndex = 1; columnIndex <= 4; columnIndex++)
            {
                columnTypesListPairedWithPlay = listGenerator.getClassAndPlayPair(columnIndex);
                classList = listGenerator.getListOfClass(columnIndex);
                columnName = listGenerator.getColumnName(columnIndex);
                Console.WriteLine($"{columnName} Gini index: {calculator.calculateClassGI_By_Pairs(columnTypesListPairedWithPlay, classList)}");
                for (int i = 0; i < classList.Count; i++)
                {
                    Console.WriteLine($"{listGenerator.getTypeName(classList, i)} Gini index: {calculator.calculateClassTypeGI_Class_Play_pairs(columnTypesListPairedWithPlay, classList[i])}");
                    typeGIPairs.Add($"{listGenerator.getTypeName(classList, i)},{calculator.calculateClassTypeGI_Class_Play_pairs(columnTypesListPairedWithPlay, classList[i])}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Type and GI pairs:");
            for (int i = 0; i < typeGIPairs.Count; i++)
                Console.WriteLine(typeGIPairs[i]);

            DecisionTree tree = new DecisionTree();
            List<string> temp = tree.getClasses();
            Console.WriteLine();
            foreach (var item in temp)
                Console.WriteLine(item);

            Console.WriteLine($"\nRoot node:\n{tree.Root}");

            Console.ReadKey();
        }
        static void printMyList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{list[i]} ");
        }
    }
}
