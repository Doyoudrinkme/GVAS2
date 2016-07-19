using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarTest {
    class Program {
        static void Main1(string[] args) {
            Random R = new Random();
            double [,]arr=new double[10,10];
            int maxh = 5;
            double[,] dResult = new double[arr.GetLength(0), maxh];
            for (int i = 0; i < arr.GetLength(0); i++) {
                for (int j = 0; j < arr.GetLength(1); j++) {
                    arr[i, j] = R.Next(11);
                    Console.Write(arr[i, j]+"   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(); Console.WriteLine();
            for (int h = 1; h < maxh; h++) {           //变异滞后距离
                    double n = 0;           //计算次数         
                    ArrayList p = new ArrayList();        //以h为滞后距离的差的平方                         
                    for (int i = 0; i < arr.GetLength(0); ++i) {      //每行变异   
                        double pp = 0;                    //差的平方的和
                        for (int j = 0; j < arr.GetLength(1)-h; j++) { //最大变异宽幅
                            p.Add(Math.Pow(arr[i, j] - arr[i, j + h], 2));
                            pp += (Double)p[j];      //将h为滞后距离的差的平方相加
                        }
                        p.Clear();
                        n = arr.GetLength(0) - h;
                        dResult[i, h] = pp / (2 * n);
                }    
            }
            for (int i = 0; i < arr.GetLength(0); ++i) {
                for (int h = 1; h < maxh; h++) {
                    Console.Write(String.Format("{0:N3}", dResult[i, h]) + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
