using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    static class DivisionTests
    {
        public static void DivideInt(int startValue, int endValue, int offset)
        {
            for (int i = startValue; i <= endValue; i /= offset) { }
        }

        public static void DivideLong(long startValue, long endValue, long offset)
        {
            for (long i = startValue; i <= endValue; i /= offset) { }
        }

        public static void DivideDecimal(decimal startValue, decimal endValue, decimal offset)
        {
            for (decimal i = startValue; i <= endValue; i /= offset) { }
        }

        public static void DivideFloat(float startValue, float endValue, float offset)
        {
            for (float i = startValue; i <= endValue; i /= offset) { }
        }

        public static void DivideDouble(double startValue, double endValue, double offset)
        {
            for (double i = startValue; i <= endValue; i /= offset) { }
        }
    }
}
