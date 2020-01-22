using System;

namespace CSI {
    public class PartialGauss {

        private Matrix matrix;
        private Vector vector;

        public PartialGauss(Matrix matrix, Vector vector) {
            if(matrix.getSize() != vector.getSize()) {
                throw new ArgumentException("Wrong sizes for partialGauss");
            }

            this.matrix = matrix.Copy();
            this.vector = vector.Copy();
        }

        public Vector Calculate() {

            for(int i = 0; i < matrix.getSize(); i++) {

                Partial(i,i);
                ////

                for(int j = i+1; j < matrix.getSize(); j++) {
                    
                    double multi = matrix.Get(j,i) / matrix.Get(i,i);

                    for(int k = i; k < matrix.getSize(); k++) {

                         matrix.Set(j,k, matrix.Get(j,k) - matrix.Get(i,k)*multi);   
                    }
                    vector.Set(j, vector.Get(j) - vector.Get(i)*multi);                }
            }

            return FinalVector();
        }

        private void Partial(int i , int j) {
            int max = GetMax(i,j);
            matrix.rowSwap(i,max);
            vector.rowSwap(i,max);
        }

        private int GetMax(int i, int j) {
            double maxValue = matrix.Get(i,j);
            maxValue = Math.Abs(maxValue);
            int max = i;

            for(int k = i + 1; k < matrix.getSize(); k++) {
                double temp = matrix.Get(k,j);
                temp = Math.Abs(temp);
                if(temp > maxValue) {
                    maxValue = temp;
                    max = k;
                }
            }
            return max;
        }

        private Vector FinalVector() {
            double multi;
            double multi2;
            double value;
            
            for(int i = matrix.getSize()-1; i >= 0; i--) {
                for(int j = i + 1; j < matrix.getSize(); j++) {
                    multi = matrix.Get(i,j);
                    value = vector.Get(j);
                    vector.Set(i, vector.Get(i) - multi*value);
                }

                multi2 = matrix.Get(i,i);
                vector.Set(i, vector.Get(i)/multi2);
            }
            return vector;
        }
    }
}