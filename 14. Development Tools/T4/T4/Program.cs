using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4
{
    class Program
    {
        static void Main(string[] args)
        {
            T4TemplataClass t4instance = new T4TemplataClass();
            t4instance.data0 = 0.0f;
            t4instance.data1 = 1.0f;
            t4instance.data2 = 2.0f;
            t4instance.data3 = 3.0f;
            t4instance.data3 = 4.0f;

            Console.WriteLine(t4instance.data2);
        }
    }
}
