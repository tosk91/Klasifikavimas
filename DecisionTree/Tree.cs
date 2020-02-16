using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Tree
    {
        Node head;
        Calculator calc = new Calculator();
        public Tree() { this.head = null; }

        public Node insert(Node root, Balloon balloon)
        {
            if (root == null )
            {
                root = new Node();
                root.value = balloon;
            }
            else if (root.left.value > root.right.value) //  
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }
        public Node Head
        {
            get { return head; }
            set { this.head = value; }
        }
    }
}
