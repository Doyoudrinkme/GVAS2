using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MSExcel = Microsoft.Office.Interop.Excel;
namespace writeToExcel {
    class Program {
        static void Main(string[] args) {
            object path;//文件路径变量
            MSExcel.Application excelApp;//Excel 应用程序变量
            MSExcel.Workbook excelDoc;//Excel文档变量

            path = @"D:\MyDesktop\e.xlsx";
            excelApp = new MSExcel.ApplicationClass();//初始化
            if (File.Exists((String)path)) {
                File.Delete((string)path);
            }
            //由于使用的是COM库，因此许多变量需要用Nothing代替
            Object misspara = Missing.Value;
            excelDoc = excelApp.Workbooks.Add(misspara);
            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range类型的变量r
            MSExcel.Range r1,r2,r3,r4,r5,r6,r7;
            r1 = ws.get_Range("A2", "A2");//获取A2处的表格，并赋值
            r2 = ws.get_Range("B2", "B2");//获取A2处的表格，并赋值
            r3 = ws.get_Range("C2", "C2");//获取A2处的表格，并赋值
            r4 = ws.get_Range("D2", "D2");//获取A2处的表格，并赋值
            r5 = ws.get_Range("E2", "E2");//获取A2处的表格，并赋值
            r6 = ws.get_Range("F2", "F2");//获取A2处的表格，并赋值
            r7 = ws.get_Range("G2", "G2");//获取A2处的表格，并赋值

            //ws.Cells[]
            //                                         
            r1.Value2 = "行号";
            r2.Value2 = "背景均值";
            r3.Value2 = "背景方差";
            r4.Value2 = "地物均值";
            r5.Value2 = "地物方差";
            r6.Value2 = "混合均值";
            r7.Value2 = "混合方差 ";

            Random r = new Random();
            for (int i = 3; i < 7; i++) { 
                for (int j =1; j < 8; j++) {
                    ws.Cells[i, j] = Convert.ToString(r.Next(100));
                }
            }


        //WdSaveFormat为Excel文档的保存格式
        object format = MSExcel.XlFileFormat.xlWorkbookDefault;
            //将excelDoc文档对象的内容保存为XLSX
            excelDoc.SaveAs(path, format, misspara, misspara, misspara, misspara,
                MSExcel.XlSaveAsAccessMode.xlExclusive, misspara, misspara, misspara, misspara, misspara);
            //关闭excelDoc文档对象
            excelDoc.Close(misspara, misspara, misspara);
            //关闭excelApp组件对象
            excelApp.Quit();
            Console.WriteLine(path + "创建完毕");



        }
    }
}
