using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Node
    {
        private string name;
        private double giValue;
        List<Node> neighbors;
        List<Node> children;
        //private Node[] neighbors; // n = 3 
        //private Node[] children; // n = 3

        public Node()
        {
            this.neighbors = null;
            this.children = null;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double GIvalue
        {
            get { return this.giValue; }
            set { this.giValue = value; }
        }
        //public Node[] Neighbors { get { return this.neighbors; }
        //public Node[] Children { get { return this.children; } }
        public List<Node> Neighbors
        {
            get { return this.neighbors; }
            set { this.neighbors = value; }
        }
        public List<Node> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }
        public string fullNodeInfo() { return $"Name: {this.name}, GI index: {this.giValue}"; }
    }
}
