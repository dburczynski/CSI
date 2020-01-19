using System;
using System.Collections.Generic;

namespace CSI {
    public class Vector {
        
        private List<Double> vector;
        private int size;

        public Vector(int size) {
            this.size = size;
            vector = new List<double>(size);
        }

        public int Size { get; set; }
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
            for(int i = 0; i < vector.Size; i++) {
                vector.Set(i, -vector.Get(i));
            }
            return vector;
        }

        public static Vector operator +(Vector x, Vector y) {

            if(x.Size !=  y.Size) {
                throw new System.ArgumentException("Cant add these vectors!");
            }
            Vector returnVector = new Vector(x.Size);

            for(int i = 0; i < x.Size; i++) {
                returnVector.Set(i, x.Get(i) + y.Get(i));;
            }
            return returnVector;
        }

        public static Vector operator -(Vector x, Vector y) {

            if(x.Size !=  y.Size) {
                throw new System.ArgumentException("Cant add these vectors!");
            }
            Vector returnVector = new Vector(x.Size);

            for(int i = 0; i < x.Size; i++) {
                returnVector.Set(i, x.Get(i) - y.Get(i));
            }
            return returnVector;
        }

        public double Norm() {
            double sum = 0;
            for(int i = 0; i < Size; i++) {
                sum += Math.Pow(vector[i], 2);
            }
            return Math.Sqrt(sum);
        }

        public Vector Copy() {
            Vector returnVector = new Vector(Size);
            for(int i = 0; i < Size; i++) {
                returnVector.Set(i,vector[i]);
            }
            return returnVector;
        }


    }
}