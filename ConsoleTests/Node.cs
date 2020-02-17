using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Node
    {
        private string name;
        Node left;
        Node right;
        public Node() { }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
