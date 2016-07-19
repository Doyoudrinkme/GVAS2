using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoVar.cAlgorithm {
    static class Average {
        //一维数组平均
        public static double average(int[] arr) {
            double s = 0;
            for (int i = 0; i < arr.Length; i++) {
                s += arr[i];
            }
            return s / arr.Length;
        }
        public static double average(double[] arr) {
            double s = 0;
            for (int i = 0; i < arr.Length; i++) {
                s += arr[i];
            }
            return s / arr.Length;
        }
        //每行均值
        public static double average2D(double[][] arr,int line) {
            double s = 0;
            for (int i = 0; i < arr.Length; i++) {
                s += arr[line][i];
            }
            return s / arr.Length;
        }
    }
}
