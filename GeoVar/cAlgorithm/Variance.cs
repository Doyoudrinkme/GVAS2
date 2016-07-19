using System;
using static GeoVar.cAlgorithm.Average;

namespace GeoVar.cAlgorithm {
    static class Variance {
        //计算一维数组的方差
        public static double variance(int[] arr) {
            double var = 0;//存储方差
            double avg = average(arr);
            double sum = 0;//均值与数组元素值得差的平方和
            for (int i = 0; i < arr.Length; i++) {
                sum += Math.Pow(arr[i] - avg, 2);
            }
            var = sum / arr.Length;
            return var;
        }
        public static double variance(double[] arr) {
            double var = 0;//存储方差
            double avg = average(arr);
            double sum = 0;//均值与数组元素值得差的平方和
            for (int i = 0; i < arr.Length; i++) {
                sum += Math.Pow(arr[i] - avg, 2);
            }
            var = sum / arr.Length;
            return var;
        }
        //计算全幅方差

        //计算逐行方差
        public static double variance2D(int[][] arr,int line) {
            double[] var2 = new double[arr.Length];//存储每行的方差
            for (int i = 0; i < arr.Length; i++) {
                double sum = 0;//均值与数组元素值得差的平方和
                double avg = average(arr[i]);
                for (int j = 0; j < arr.Length; j++) {
                       sum += Math.Pow(arr[i][j] - avg, 2);
                }
                var2[i] = sum / arr.Length;
               
            }
            return var2[line];
        }

    }
}
