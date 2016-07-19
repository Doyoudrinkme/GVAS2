using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoVar.cAlgorithm {
    static class ArrayCacu {
        //一维数组平均
        public static double average(int [] arr) {
            double s = 0;
            for(int i = 0; i < arr.Length; i++) {
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

        //计算一维数组的方差
        public static double variance(int []arr) {
            double var = 0;//存储方差
            double avg = average(arr);
            double sum = 0;//均值与数组元素值得差的平方和
            for(int i = 0; i < arr.Length; i++) {
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

    }
}
