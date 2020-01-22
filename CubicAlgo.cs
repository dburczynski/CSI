using System;
using System.Collections.Generic;

namespace CSI {
    class CubicAlgo {

        private Matrix matrix;
        private Vector matrixVector;
        private Vector vector;
        private List<Point> pointList;

        public CubicAlgo(List<Point> pointList) {
            
            this.pointList = pointList;
            this.matrix = new Matrix(pointList.Count);
            this.vector = new Vector(pointList.Count);
            Insert();
        }

        public void Insert() {
            matrix.Set(0,0,2);
            for(int i = 1; i < matrix.getSize() -1; i++) {
                matrix.Set(i,i-1, Variables.Mi(i,pointList));
                matrix.Set(i,i,2);
                matrix.Set(i,i+1, Variables.Lambda(i,pointList));
                vector.Set(i,Variables.Delta(i,pointList));
            }
            matrix.Set(matrix.getSize()-1, matrix.getSize()-1, 2);
        }

        public void getGaussVector() {
            // for(int i = 0; i < this.matrix.getSize(); i++)
            //     for(int j = 0; j < this.matrix.getSize(); j++)             
            //         Console.WriteLine(this.matrix.Get(i,j));
            this.matrixVector = new PartialGauss(matrix,vector).Calculate();
            
        }

        public void getGSVector() {
            this.matrixVector = new GS(matrix,vector).Calculate();
        }

        public void getJacobianVector() {
            this.matrixVector = new Jacobian(matrix,vector).Calculate();
        }
        public void Print(int howMany)
        {
            var start = pointList[0].X;
            var stop = pointList[pointList.Count - 1].X;
            var jump = (stop - start) / howMany;
            for (double x = start; x < stop; x += jump)
            {
                Console.WriteLine(new Point(x, S(x,pointList)));
            }
        }

        private double S(double x, List<Point> pointList)
        {
            int i = GetIndexX(x);

            double diff = x - pointList[i].X;
            double value = A(i,pointList) +
                            B(i,pointList) * diff +
                            C(i) * diff * diff +
                            D(i) * diff * diff * diff;
            
            return value;

        }

        private int GetIndexX(double x)
        {
            for (int i = 1; i < pointList.Count; i++)
            {
                if (x <= pointList[i].X)
                {
                    return i - 1;
                }
            }
            throw new Exception("Podano wartość spoza oszacowanych wielomianów");
        }


        private double A(int j, List<Point> pointList)
        {
            return Variables.F_x(j,pointList);
        }

        private double B(int j, List<Point> pointList)
        {
            double partOne = (Variables.F_x(j + 1, pointList) - Variables.F_x(j,pointList)) / Variables.H(j + 1,pointList);
            double partTwo = (2 * M(j) + M(j + 1)) / 6;

            return partOne - partTwo * Variables.H(j + 1,pointList);
        }

        private double C(int j)
        {
            return M(j) / 2;
        }

        private double D(int j)
        {
            double upperPart = M(j + 1) - M(j);
            double lowerPart = 6 * Variables.H(j + 1,pointList);
            return upperPart / lowerPart;
        }

        private double M(int j)
        {
            return matrixVector.Get(j);
        }

    }
}