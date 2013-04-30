using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Size
{
    public double width;
    public double heigth;

    public Size(double width, double heigth)
    {
        this.width = width;
        this.heigth = heigth;
    }

    public static Size GetRotatedSize(Size s, double rotationAngle)
    {
        double sinusOfRotationAngle = Math.Abs(Math.Sin(rotationAngle));
        double cosinusOfRotationAngle = Math.Abs(Math.Cos(rotationAngle));

        double rotatedWidth = cosinusOfRotationAngle * s.width + sinusOfRotationAngle * s.heigth;
        double rotatedHeight = sinusOfRotationAngle * s.width + cosinusOfRotationAngle * s.heigth;

        Size rotatedSize = new Size(rotatedWidth, rotatedHeight);

        return rotatedSize;
    }

}