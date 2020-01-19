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
        }

        public void Insert() {
            matrix.Set(0,0,2);
            for(int i = 1; i < matrix.Size -1; i++) {
                matrix.Set(i,i-1, Variables.M(i,pointList));
                matrix.Set(i,i,2);
                matrix.Set(i,i+1, Variables.Lambda(i,pointList));
                vector.Set(i,Variables.Delta(i,pointList));
            }
            matrix.Set(matrix.Size-1, matrix.Size-1, 2);
        }

        public void getGaussVector() {
            this.matrixVector = new PartialGauss(matrix,vector).Calculate();
        }

        public void getGSVector() {
            this.matrixVector = new PartialGauss(matrix,vector).Calculate();
        }

        public void getJacobianMatrix() {
            this.matrixVector = new Jacobian(matrix,vector).Calculate();
        }
    }
}