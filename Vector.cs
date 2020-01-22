using System;
using System.Collections.Generic;

namespace CSI {
    public class Vector {
        
        private double[] vector;
        private int size;

        public Vector(int size) {
            this.size = size;
            vector = new double[size];
            for(int i = 0; i < size; i++) {
                vector[i] = 0;
            }
        }

        public int getSize() {
            return this.size;
        }
        public void setSize(int size) {
            this.size = size;
        }
        public double Get(int x) {
            return vector[x];
        }

        public void Set(int x, double y) {
            vector[x] = y;
        }

        public static Vector operator +(Vector vector) {
            return vector;
        }

        public void rowSwap(int x, int y) {
            
            double temp = vector[x];
            vector[x] = vector[y];
            vector[y] = temp;
        }

        public static Vector operator -(Vector vector) {
            for(int i = 0; i < vector.getSize(); i++) {
                vector.Set(i, -vector.Get(i));
            }
            return vector;
        }

        public static Vector operator +(Vector x, Vector y) {

            if(x.getSize() !=  y.getSize()) {
                throw new System.ArgumentException("Cant add these vectors!");
            }
            Vector returnVector = new Vector(x.getSize());

            for(int i = 0; i < x.getSize(); i++) {
                returnVector.Set(i, x.Get(i) + y.Get(i));;
            }
            return returnVector;
        }

        public static Vector operator -(Vector x, Vector y) {

            if(x.getSize() !=  y.getSize()) {
                throw new System.ArgumentException("Cant add these vectors!");
            }
            Vector returnVector = new Vector(x.getSize());

            for(int i = 0; i < x.getSize(); i++) {
                returnVector.Set(i, x.Get(i) - y.Get(i));
            }
            return returnVector;
        }

        public double Norm() {
            double sum = 0;
            for(int i = 0; i < this.size; i++) {
                sum += Math.Pow(vector[i], 2);
            }
            return Math.Sqrt(sum);
        }

        public Vector Copy() {
            Vector returnVector = new Vector(this.size);
            for(int i = 0; i < this.size; i++) {
                returnVector.Set(i,vector[i]);
            }
            return returnVector;
        }


    }
}