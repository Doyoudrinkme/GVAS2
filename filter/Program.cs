using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter {
    class Program {
        static void Main(string[] args) {
            String str = "D:\\MyDesktop\\k.txt";
            //写出计算结果
            //  str.Substring(str.LastIndexOf('.'), 3) == ".txt";
            Console.WriteLine(str.Substring(str.LastIndexOf('.'), 3+1));
            Console.ReadKey();
            
        }
    }
}
