using System;
using System.Collections.Generic;
using OpenTK;
using System.Linq;

namespace XMLParser
{
    class Program
    {
        private static void Main()
        {
           List<Element> e = new ExtractElements().Start();
            Console.WriteLine(e[0].Transform);
        }      
    }
}
