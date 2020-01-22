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

            Vector v = new Vector(vector.getSize());
            Vector returnVector = new Vector(vector.getSize());

            double diff = 0;

            do
            {
                for(int i = 0; i < matrix.getSize(); i++) {
                    double sum = 0;
                    sum+= vector.Get(i);

                    for(int j = 0; j < matrix.getSize(); j++) {
                        if(i != j)
                            sum -= matrix.Get(i,j)*v.Get(j);
                    }
                    
                    returnVector.Set(i , sum / matrix.Get(i,i));
                }
                diff = (returnVector - v).Norm();
                for(int i = 0; i < v.getSize(); i++) {
                   v.Set(i,returnVector.Get(i));
                }
            } while(diff > Variables.DIFFERENCE);
            return returnVector;
        }

    }
}