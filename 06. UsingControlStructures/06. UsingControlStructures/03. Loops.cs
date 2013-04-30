using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Loops
{
    private static void PrintExpectedValueFound(int[] array, int expectedValue)
    {
		// разкарах ненужната част от кода :)

        bool expectedValueFound = false;
        for (int index = 0; index < array.Length; index++)
        {
            if (array[index] == expectedValue)
            {
                expectedValueFound = true;
                break;
            }
        }

        if (expectedValueFound)
        {
            Console.WriteLine("Value Found");
        }
    }
}
