using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Balloon
    {
        private string color, size, act, age;
        private bool inflated;
        private double GI;
        public Balloon(string color, string size, string act, string age) {
            this.size = size;
            this.act = act;
            this.color = color;
            this.age = age;
        }
        public string Color
        {
            get { return color; }
            set { this.color = value; }
        }
        public string Size
        {
            get { return size; }
            set { this.size = value; }
        }
        public string Act
        {
            get { return act; }
            set { this.act = value; }
        }
        public string Age
        {
            get { return age; }
            set { this.age = value; }
        }
        public bool Inflated
        {
            get { return inflated; }
            set { this.inflated = value; }
        }
        public string fullInfo
        {
            get
            {
                return $"{this.color}, {this.size}, {this.act}, {this.age}, {this.inflated}";
            }
        }
    }
}
