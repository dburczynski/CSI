using System;
using System.Collections.Generic;

namespace CSI {

    public class Jacobian {

        private Matrix matrix;
        private Vector vector;

        public Jacobian(Matrix matrix, Vector vector) {
            this.matrix = matrix.Copy();
            this.vector = vector.Copy();
        }

        public Vector Calculate() {

            Vector v = new Vector(vector.Size);
            Vector returnVector = new Vector(vector.Size);

            double diff = 0;

            while(diff > Variables.DIFFERENCE) {
                for(int i = 0; i < matrix.Size; i++) {
                    double sum = 0;
                    sum+= vector.Get(i);

                    for(int j = 0; j < matrix.Size; j++) {
                        if(i != j)
                            sum -= matrix.Get(i,j)*v.Get(j);
                    }
                    
                    returnVector.Set(i , sum / matrix.Get(i,i));
                }
                diff = (returnVector - v).Norm();
                for(int i = 0; i < v.Size; i++) {
                   v.Set(i,returnVector.Get(i));
                }
            }
            return returnVector;
        }

    }
}