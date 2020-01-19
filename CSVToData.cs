using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSI 
{
    class CSVToData 
    {
        public static List<Point> Read()
        {
            List<Point> pointList = new List<Point>();

            using(var fileReader = new StreamReader(@"..\data.csv")) {

                while(!fileReader.EndOfStream) {
                    
                    var line = fileReader.ReadLine();
                    var point = line.Split(';');
                    double x = Double.Parse(point[0]);
                    double y = Double.Parse(point[1]);

                    pointList.Add(new Point(x*1000,y));
                }
            }
            return pointList;
        }
    }

}