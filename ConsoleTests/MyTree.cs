using System;
using System.Collections.Generic;
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
        Node root { get; set; }
        public MyTree() { }
        public void addNode(Node root)
        {
            if (root == null)
            {
                //root = new Node();
            }
        }
        private double calcItemGI(int countYes, int countNo)
        {
            return 1 - Math.Pow(Convert.ToDouble(countYes) / Convert.ToDouble(countYes + countNo), 2) - Math.Pow(Convert.ToDouble(countNo) / Convert.ToDouble(countYes + countNo), 2);
        }

        private double calcClassGI(List<double> column)
        {
            double output;
            List<double> GIlist = new List<double>();
            for (int i = 0; i < column.Count; i++)
            {

            }
            return 2;
        }
    }
}
