using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AdvancedMathOperations
{
    class SinusTests
    {
        public static void SinusOfFloat(float startValue, float endValue, float offset)
        {
            for (float i = startValue; i <= endValue; i += offset)
            {
                Math.Sin(i);
            }            
        }

        public static void SinusOfDeciaml(decimal startValue, decimal endValue, decimal offset)
        {
            for (decimal i = startValue; i <= endValue; i += offset)
            {
                Math.Sin((double)i);
            }
        }

        public static void SinusOfDouble(double startValue, double endValue, double offset)
        {
            for (double i = startValue; i <= endValue; i += offset)
            {
                Math.Sin(i);
            }
        }
    }
}
