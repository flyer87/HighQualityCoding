﻿using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Geometry2DUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Geometry3DUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Geometry3DUtils.Width = 3;
            Geometry3DUtils.Height = 4;
            Geometry3DUtils.Depth = 5;

            Console.WriteLine("Volume = {0:f2}", Geometry3DUtils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3DUtils.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry3DUtils.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry3DUtils.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry3DUtils.CalcDiagonalYZ());
        }
    }
}
