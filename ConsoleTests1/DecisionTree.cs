using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests1
{
    class DecisionTree
    {
        private Calculator calculator = new Calculator();
        private ListGenerator listgen = new ListGenerator();
        private List<string> classAndGIPair = new List<string>();
        double min = 999;
        Node root;
        public DecisionTree()
        {
            // root sukurimas
            if (root == null)
            {
                // nustatyti klase su maziausiu GI ir priskirti root;
                List<string> columnTypesListPairedWithPlay, classList;
                string columnName;
                for (int columnIndex =1; columnIndex <= 4; columnIndex++)
                {
                    columnTypesListPairedWithPlay = listgen.getClassAndPlayPair(columnIndex);
                    classList = listgen.getListOfClass(columnIndex);
                    columnName = listgen.getColumnName(columnIndex);
                    classAndGIPair.Add($"{columnName},{calculator.calculateClassGI_By_Pairs(columnTypesListPairedWithPlay, classList)}");
                }
                string classWithLowestGI = getClassWithLowestGI();
                root = new Node();
                root.Name = classWithLowestGI.Split(',').ToList()[0];
                root.GIvalue = double.Parse(classWithLowestGI.Split(',').ToList()[1]);
                // sukurti children lista, ten sudeti root atributus,
                root.Attributes = getAttributes(); // ?????????????????????????
            }
        }
        public Node Root { get { return this.root; } }
        public string getNodeInfo(Node node) { return node.fullNodeInfo(); }
        private string getClassWithLowestGI()
        {
            int Minindex = -1;
            for (int i = 0; i < classAndGIPair.Count; i++)
            {
                if (double.Parse(classAndGIPair[i].Split(',').ToList()[1]) < min) {min = double.Parse(classAndGIPair[i].Split(',').ToList()[1]); Minindex++; }
            }
            
            return classAndGIPair[Minindex];
        }
        private List<Attribute> getAttributes() // ?????????????????????????
        {
            List<Attribute> output = new List<Attribute>();

            //List<string> temp = listgen.pair

            return output;
        }
        public List<string> getClasses() => classAndGIPair;
    }
}
