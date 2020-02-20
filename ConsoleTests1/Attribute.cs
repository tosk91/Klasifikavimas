using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests1
{
    class Attribute
    {
        private string name;
        private double gi;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Gi
        {
            get { return this.gi; }
            set { this.gi = value; }
        }
        public override string ToString()
        {
            return $"{this.name},{this.gi}";
        }
    }
}
