using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    class MathOperationsTests
    {
        static void Main(string[] args)
        {
            MultiplicationTests.MultiplyInt(3, 100, 3);
            MultiplicationTests.MultiplyLong(3L, 10000L, 3L);
            MultiplicationTests.MultiplyFloat(3f, 100f, 3f);
            MultiplicationTests.MultiplyDouble(3.0, 100.0, 3.0);
            MultiplicationTests.MultiplyDecimal(3m, 100m, 3m);
        }
    }
}
