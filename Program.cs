using System;
using System.Collections.Generic;

namespace CSI
{
    class Program
    {
        static List<Point> samplePoints = new List<Point>
        {
            new Point(1, 2),
            new Point(2, 3),
            new Point(3, 5),
            new Point(4, 1),
            new Point(5, 6),
            new Point(7, 4),
            new Point(8, 9)
        };

        static List<Point> criticalPoints = new List<Point>
        {
            new Point(2, 75),
            new Point(11, 9),
            new Point(54, -15),
            new Point(98, 272)
        };

        static List<Point> googleMapsData = CSVToData.Read();



        static void Main(string[] args)
        {   
            CubicAlgo csi = new CubicAlgo(googleMapsData);
            csi.getGSVector();
            csi.Print(250);
        }
    }
}
