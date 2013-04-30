using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.ILS.Common;


class Program
{
    static void Main(string[] args)
    {
        string s = "123";
        byte[] arr = s.ToByteArray();
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);            
        }
    }
}