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
        List<Node> children;
        List<Attribute> attributes;

        public Node()
        {
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
        public List<Node> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }
        public List<Attribute> Attributes
        {
            get { return this.attributes; }
            set { this.attributes = value; }
        }
        public string fullNodeInfo() { return $"Name: {this.name}, GI index: {this.giValue}"; }

        public override string ToString()
        {
            return $"Name: {this.name}, GI index: {this.giValue}";
        }
    }
}
