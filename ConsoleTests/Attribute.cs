using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Attribute
    {
        string name;
        string gi;
        public Attribute() { }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Gi
        {
            get => this.gi;
            set => this.gi = value;
        }
        public override string ToString()
        {
            return $"{name},{gi}\n";
        }
    }
}
