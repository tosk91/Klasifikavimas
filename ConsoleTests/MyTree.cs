using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class MyTree
    {
        // 0: sunny, 1: rain, 2: overcast
        List<double> outlookGIs;// = new List<double>();
        // 0: cold, 1: mild, 2: hot
        List<double> temperatureGIs;// = new List<double>();
        // 0: normal, 1: high
        List<double> humidityGIs;// = new List<double>();
        // 0: weak, 1: strong
        List<double> windGIs;// = new List<double>();
        
        List<string> trainData = File.ReadAllLines("C:\\Users\\Tomas\\OneDrive - Vilniaus kolegija\\3_Kursas\\Intelektika\\Duomenu_bazes_darbams\\varzybos.csv").ToList();
        Node root;
        public MyTree() { }
        public void addNode(Node root, List<List<string>> classes)
        {
            List<double> classesGIs = new List<double>();
            List<double> tempClassesGIs = classesGIs;
            for (int i = 0; i < classes.Count; i++)
                classesGIs.Add(Program.calculateClassGI(trainData,classes[i]));
            classesGIs.IndexOf(classesGIs.Min());
            if (this.root == null)
            {
                this.root = new Node();
                root = this.root;
                string nodeName;
                if (classesGIs.IndexOf(classesGIs.Min()) == 0) root.Name = "outlook";// = new Node("outlook");
                else if (classesGIs.IndexOf(classesGIs.Min()) == 1) root.Name = "temperature";// = new Node("temperature");
                else if (classesGIs.IndexOf(classesGIs.Min()) == 2) root.Name = "humidity";// = new Node("humidity");
                else if (classesGIs.IndexOf(classesGIs.Min()) == 3) root.Name = "wind";// = new Node("wind");
            }
        }

        // for testing.
        public string printTree()
        {
            StringBuilder sb = new StringBuilder();
            if (root != null)
                sb.Append(root.Name);
            return sb.ToString();
        }
    }
}
