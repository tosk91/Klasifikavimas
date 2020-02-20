using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class MyDecisionTree
    {
        Node root;
        public MyDecisionTree()
        {
            root = new Node();
        }
        private Calculator calculator = new Calculator();
        private ListGenerator listgen = new ListGenerator();
        public Node Root { get { return this.root; } }
        public string getNodeInfo(Node node) { return node.fullNodeInfo(); }
        public MyDecisionTree buildMe()
        {
            List<string> GIandClassNamePairsList = listgen.getGIandClassPair();
            GIandClassNamePairsList = listgen.sortedGIandClassNamePairsList(GIandClassNamePairsList);
            this.root.Name = GIandClassNamePairsList[0].Split(',')[0];
            this.root.GIvalue = double.Parse(GIandClassNamePairsList[0].Split(',')[1]);
            int index = 0;
            if (root.Name == "outlook") index = 1;
            if (root.Name == "temperature") index = 2;
            if (root.Name == "humidity") index = 3;
            if (root.Name == "wind") index = 4;

            List<string> nodeChildrenNames = listgen.getListOfClass(index);
            //List<string> nodeChildrenAndPlayPairs = listgen.getClassAndPlayPair(index);
            List<string> nodeChildrenAndGIPairs;

            //for (int i = 0; i <nodeChildrenAndPlayPairs.Count;i++)
            //    if ()
            return this;
        }
    }
}
