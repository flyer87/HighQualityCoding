using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    class AdditionTests
    {
        // https://github.com/Rokata/TelerikAcademy/blob/master/high-quality-code/10.%20Code%20Tuning%20and%20Optimization/MathOperationsTest/MultiplicationTests.cs

        public static void AddInt(int startValue, int endValue, int offset)
        {
            for (int i = startValue; i <= endValue; i += offset) { }
        }

        public static void AddLong(long startValue, long endValue, long offset)
        {
            for (long i = startValue; i <= endValue; i += offset) { }
        }

        public static void AddDecimal(decimal startValue, decimal endValue, decimal offset)
        {
            for (decimal i = startValue; i <= endValue; i += offset) { }
        }

        public static void AddFloat(float startValue, float endValue, float offset)
        {
            for (float i = startValue; i <= endValue; i += offset) { }
        }

        public static void AddDouble(double startValue, double endValue, double offset)
        {
            for (double i = startValue; i <= endValue; i += offset) { }
        }

    }
}
