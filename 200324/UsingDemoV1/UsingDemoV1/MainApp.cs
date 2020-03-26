using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLib;

namespace UsingDemoV1
{
    class MainApp
    {
        static void Main(string[] args)
        {
            DemoClass dc = new DemoClass();
            dc.Foo();
            Console.ReadLine();
        }
    }
}
