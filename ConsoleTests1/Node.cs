using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests1
{
    class Node
    {
        private string name;
        private double giValue; 
        private Node[] neighbors; // n = 3 
        private Node[] children; // n = 3

        public Node()
        {
            this.neighbors = new Node[3];
            this.children = new Node[3];
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
        public Node[] Neighbors { get { return this.neighbors; } }
        public Node[] Children { get { return this.children; } }
    }
}
