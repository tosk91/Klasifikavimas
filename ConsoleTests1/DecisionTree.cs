using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests1
{
    class DecisionTree
    {
        Node root;
        public DecisionTree()
        {
            root = new Node();
        }
        public Node Root { get { return this.root; } }

    }
}
