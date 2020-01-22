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

            using(var fileReader = new StreamReader("googleApi/gory.txt")) {

                while(!fileReader.EndOfStream) {
                    
                    var line = fileReader.ReadLine();
                    //line = line.Replace('.',',');
                    var point = line.Split(';');
                    double x = Convert.ToDouble(point[0]);
                    double y = Convert.ToDouble(point[1]);
                    pointList.Add(new Point(x,y));
                }
            }
            return pointList;
        }
    }

}