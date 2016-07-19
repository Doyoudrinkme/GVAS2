using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarTest {
    class VarLineTest {
        static void Main2682(string[] args) {
            Random R = new Random();
            double[,] arr = new double[10, 10];
            int maxh = 5;
            double[,] dResult = new double[arr.GetLength(0), maxh];
            for (int i = 0; i < arr.GetLength(0); i++) {
                for (int j = 0; j < arr.GetLength(1); j++) {
                    arr[i, j] = R.Next(11);
                    Console.Write(arr[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(); Console.WriteLine();

            for (int line = 0; line < arr.GetLength(0); line++) {
                double[] var2 = new double[arr.Length];//存储每行的方差
                double sum = 0;//均值与数组元素值得差的平方和
                double avg = average2D(arr, line);
                Console.WriteLine(avg + "  avg ");
                for (int j= 0; j < arr.GetLength(1); j++) {
                    sum += Math.Pow(arr[line, j] - avg, 2);
                }          
                var2[line] = sum / arr.GetLength(1);
                Console.WriteLine(var2[line] + "   ");
            }
            Console.ReadKey();
        }

        private static double average2D(double[,] arr, int line) {
            double[] s = new double[100];
            double[] a = new double[100];
            for (int j = 0; j < arr.GetLength(1); j++) {   
                s[line] += arr[line, j];
            }
            a[line] = s[line] / arr.GetLength(1);
            return a[line]; 
        }
    
    }
}
