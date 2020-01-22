using System;
using System.Collections.Generic;

namespace CSI {
    public class Matrix {
        private int size;
        private List<List<double>> matrix;

        public Matrix(int size) {
            this.size = size;
            this.matrix = new List<List<double>>();
            for(int i = 0; i < size; i++) {
                this.matrix.Add(new List<double>());
                for(int j = 0; j < size; j++){
                    this.matrix[i].Add(0);
                }
            }
        }

        public int getSize() {
            return this.size;
        }

        public void setSize(int size) {
            this.size = size;
        }

        public List<double> getRow(int i) { return matrix[i]; }
    
        public double Get(int x, int y) {
            return matrix[x][y];
        }
        
        public void Set(int x, int y, double z) {
            this.matrix[x][y] = z;
        }

        public void rowSwap(int x, int y) {
            List<double> temp = matrix[x];
            matrix[x] = matrix[y];
            matrix[y] = temp;
        }

        public Matrix Copy() {
            Matrix returnMatrix = new Matrix(this.size);
            for(int i = 0; i < this.size; i++) {
                for(int j = 0; j < this.size; j++) {
                    returnMatrix.Set(i,j,this.Get(i,j));
                }
            }
            return returnMatrix;
        }

        public static Matrix operator * (Matrix x, Matrix y) {
            if(x.getSize() != y.getSize()) {
                throw new ArgumentException("Cannot multiply matrixes!");
            } 

            Matrix returnMatrix = new Matrix(x.getSize());

            for(int i = 0; i < x.getSize(); i++) { 
                for(int j = 0; j < x.getSize(); j++) {
                    for(int k = 0; k < x.getSize(); k++) {
                        double value = x.Get(i,k) * y.Get(k,j);
                        returnMatrix.Set(i,j, returnMatrix.Get(i,j) + value);
                    }
                }
            }

            return returnMatrix;
        }

        public static Vector operator * (Matrix matrix, Vector vector) {
            
            if(matrix.getSize() != vector.getSize()) {
                throw new ArgumentException("Cannot multiply matrix with vector!");
            } 

            Vector returnVector = new Vector(vector.getSize());

            for (int i = 0; i < vector.getSize(); i++) {
                for(int j = 0; j < matrix.getSize(); j++) {
                    returnVector.Set(i, returnVector.Get(i) + matrix.Get(i,j)*vector.Get(j));
                }
            }
            return returnVector;
        }  
        
    }
}