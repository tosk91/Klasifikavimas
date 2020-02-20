using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Header
    {
        string name;
        string gi="";
        List<Attribute> attributes;
        public Header() { }
        public string Name
        {
            get => this.name;
            set { this.name = value; }
        }
        public string Gi
        {
            get => this.gi;
            set { this.gi = value; }
        }
        public List<Attribute> Attributes
        {
            get => this.attributes;
            set { ListGen lg = new ListGen(); lg.getAttributes(this); }
        }
        public override string ToString()
        {
            return $"Name: {this.name}, GI index: {this.gi}\n" +
                $"Attributes: {attributes}\n";
        }
    }
}
