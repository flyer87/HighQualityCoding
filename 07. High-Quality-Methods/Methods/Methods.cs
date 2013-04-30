using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides of the triangle must be possitive!");
            }

            if (!FormsTriangle(a, b, c))
            {
                throw new ArgumentOutOfRangeException("These sides don't form a triangle!");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        static string ConvertDigitToText(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    {
                        throw new ArgumentOutOfRangeException("Digit must be between 0 and 9");
                    }
            }
        }

        static int FindMaximumElement(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("No elements to operate!");
            }

            int maximumElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maximumElement)
                {
                    maximumElement = elements[i];
                }
            }

            return maximumElement;
        }

        static void PrintNumber(double number, int decimals)
        {
            string format = "{0:f" + decimals + "}";
            Console.WriteLine(format, number);
        }

        static void PrintPercent(double number, int decimals)
        {
            string format = "{0:p" + decimals + "}";
            Console.WriteLine(format, number);
        }

        static void PrintNumberAligned(double number, int width)
        {
            string format = "{0," + width + "}";
            Console.WriteLine(format, number);
        }

        static bool isLineVertical(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("points coincide!");
            }

            return x1 == x2;
        }

        static bool isLineHorizontal(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("points coincide!");
            }

            return y1 == y2;
        }

        static double CalcDistanceOfTwoPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        private static bool FormsTriangle(double a, double b, double c)
        {
            return a + b > c && b + c > a && a + c > b;
        }

        private static bool PointsCoincide(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToText(5));

            Console.WriteLine(FindMaximumElement(5, -1, 3, 2, 14, 2, 3));

            PrintNumber(1.3, 3);
            PrintPercent(0.75, 3);
            PrintNumberAligned(2.30, 10);

            Console.WriteLine(CalcDistanceOfTwoPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + isLineHorizontal(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + isLineVertical(3, -1, 3, 2.5));

            Student peter = new Student("Peter", "Ivanov", DateTime.Parse("17.03.1992"), "Sofia");
            Student stella = new Student("Stella", "Markova", DateTime.Parse("03.11.1993"), "Vidin", "gamer", "hieg results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
