using System;
using System.Collections.Generic;

namespace CSI {

    static class Variables {
        public static double DIFFERENCE = 0.001;
        //number of variables in polynomials
        public static int POLYVAR = 4;


        
        public static double F_x(int i, List<Point> pointList) { return pointList[i].Y; }

        public static double H(int i, List<Point> pointList) { return pointList[i].X - pointList[i-1].X; }

        public static double Lambda(int i, List<Point> pointList) {
            return H(i+1,pointList)/(H(i,pointList) + H(i+1,pointList)); 
        }

        public static double Mi(int i, List<Point> pointList) {
            return H(i,pointList) / (H(i,pointList) + H(i+1,pointList));
        }

        public static double Delta(int i, List<Point> pointList) {

            double var1 = 6/ (H(i,pointList) + H(i+1,pointList));
            double var2 = (F_x(i+1,pointList) - F_x(i,pointList)) / H(i+1,pointList);
            double var3 = (F_x(i,pointList) - F_x(i-1,pointList)) / H(i,pointList);

            return var1 * (var2 - var3);
        }

    }
}