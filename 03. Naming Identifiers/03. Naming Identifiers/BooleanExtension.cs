using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BooleanExtension
{
    private const int MAX_COUNT = 6;      

    public static void Main2()
    {
        BooleanExtension.Operations instance = new BooleanExtension.Operations();
        instance.PrintBooleanAsString(true);
    }

    private class Operations
    {
        public void PrintBooleanAsString(bool boolValue)
        {
            string valueAsString = boolValue.ToString();
            Console.WriteLine(valueAsString);
        }
    }
}