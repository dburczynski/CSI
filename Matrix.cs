using System;
using System.Collections.Generic;

namespace CSI {
    public class Matrix {
        private int size;
        private List<List<double>> matrix;

        public Matrix(int size) {
            this.size = size;
            this.matrix = new List<List<double>>(size);
            for(int i = 0; i < size; i++) {
                matrix[i] = new List<double>(size);
            }
        }

        public int Size { get; set; }

        public List<double> getRow(int i) { return matrix[i]; }
    
        public double Get(int x, int y) {
            return matrix[x][y];
        }
        
        public void Set(int x, int y, double z) {
            matrix[x][y] = z;
        }

        public void rowSwap(int x, int y) {
            List<double> temp = matrix[x];
            matrix[x] = matrix[y];
            matrix[y] = temp;
        }

        public Matrix Copy() {
            Matrix returnMatrix = new Matrix(this.Size);
            for(int i = 0; i < this.Size; i++) {
                for(int j = 0; j < this.Size; j++) {
                    returnMatrix.Set(i,j,this.Get(i,j));
                }
            }
            return returnMatrix;
        }

        public static Matrix operator * (Matrix x, Matrix y) {
            if(x.Size != y.Size) {
                throw new ArgumentException("Cannot multiply matrixes!");
            } 

            Matrix returnMatrix = new Matrix(x.Size);

            for(int i = 0; i < x.Size; i++) { 
                for(int j = 0; j < x.Size; j++) {
                    for(int k = 0; k < x.Size; k++) {
                        double value = x.Get(i,k) * y.Get(k,j);
                        returnMatrix.Set(i,j, returnMatrix.Get(i,j) + value);
                    }
                }
            }

            return returnMatrix;
        }

        public static Vector operator * (Matrix matrix, Vector vector) {
            
            if(matrix.Size != vector.Size) {
                throw new ArgumentException("Cannot multiply matrix with vector!");
            } 

            Vector returnVector = new Vector(vector.Size);

            for (int i = 0; i < vector.Size; i++) {
                for(int j = 0; j < matrix.Size; j++) {
                    returnVector.Set(i, returnVector.Get(i) + matrix.Get(i,j)*vector.Get(j));
                }
            }
            return returnVector;
        }  
        
    }
}