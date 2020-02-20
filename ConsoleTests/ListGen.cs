using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class ListGen
    {
        static string path = "C:\\Users\\Tomas\\OneDrive - Vilniaus kolegija\\3_Kursas\\Intelektika\\Duomenu_bazes_darbams\\varzybos.csv";
        List<string> trainData = File.ReadAllLines(path).ToList();
        public ListGen() { }
      
        // returns a list of { outlook, temperature, humidity, wind }
        public List<Header> getHeaders()
        {
            List<Header> headers = new List<Header>();
            string[] headerLine = trainData[0].Split(',');
            for (int i = 1; i<headerLine.Length-1;i++)
            {
                Header header = new Header();
                header.Name = headerLine[i];
                headers.Add(header);
            }
            return headers;
        }
        // returns a list of different attributes for a header { sunny, rain, overcast }
        public void getAttributes(Header header)
        {
            List<Attribute> attributes = new List<Attribute>();
            List<string> attributeNames = new List<string>();
            int columnIndex = 0;
            //List<string> headerLine = trainData[0].Split(',').ToList();
            //headerLine.RemoveAt(0);
            //headerLine.RemoveAt(headerLine.IndexOf(headerLine.Last()));
            //for (int i = 0; i < headerLine.Count; i++)
            //    if (headerLine[i] == header) { columnIndex = i; break; }
            List<Header> headers = getHeaders();
            for(int i=0;i<headers.Count;i++)
                if (headers[i].Name == header.Name) { columnIndex = i; break; }

            for (int i = 0; i < trainData.Count; i++)
            {
                if (!attributeNames.Contains(trainData[i].Split(',').ToArray()[columnIndex]))
                {
                    Attribute attribute = new Attribute();
                    attribute.Name = trainData[i].Split(',').ToArray()[columnIndex];
                    attributes.Add(attribute);
                }
            }
            header.Attributes = attributes;
        }
    }
}
