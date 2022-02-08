/*Накопление сумм и произведений*/
/*1.3.2  Составить циклический алгоритм и программу для вычисления результата по формуле.
 * Для проверки программы задать X = 0,5 ; n = 20*/

/*Accumulation of sums and products*/
/*1.3.2 Write a cyclic algorithm and a program for calculating the result using a formula.
  * To test the program set X = 0.5 ; n = 20*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23_variant_CSharp_1_3_2
{
    public partial class AccumulationOfSums : Form
    {
        public AccumulationOfSums()
        {
            InitializeComponent();
            
        }


        public static double Prelim()                                                 //функция для предварительного расчета
        {
            int n = 20;
            double x = 0.5;
            double prelim = Math.Sin(Math.PI * Convert.ToDouble(n) / (x + 3));
            return prelim;
        }



        public static double functValTable(double x, double k)
        {
            double y;
            y = Prelim() * Math.Sqrt(Math.Pow(Math.Pow(x, k-1)+Math.Pow(Math.Exp(k-3.0/2.0), 1.0 / k), 1.0 / k) / 1.0 + Math.Log(x));
            return y;
        }



        private void tableName_Text(object sender, EventArgs e)
        {
            tableName.Text = "Таблица значений функции";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int n = 20;
            double x = 0.5;
            double[,] tableXYk = new double[20, 3];
            dataGridView1.RowCount = n;                                //кол-во строк
            dataGridView1.ColumnCount = 3;                               //столбцов
            dataGridView1.Columns[0].HeaderText = "Шаг (k)";
            dataGridView1.Columns[1].HeaderText = "X";
            dataGridView1.Columns[2].HeaderText = "Y";
            string[] tableY = new string[20];

            for (int count_row = 0; count_row < n; count_row++)
            {
                for (int count_column = 0; count_column < dataGridView1.ColumnCount; count_column++)                                         //заполняем значения X
                {
                    tableXYk[count_row, 0] = count_row+1;                                      //заполняем массив случайными значениями координат
                    dataGridView1.Rows[count_row].Cells[0].Value = "k = " + tableXYk[count_row, 0];

                    tableXYk[count_row, 1] = x;                                             //X
                    dataGridView1.Rows[count_row].Cells[1].Value = tableXYk[count_row, 1];

                    tableY[count_row] = functValTable(x, count_row+1).ToString("0.####");                                             //Y
                    dataGridView1.Rows[count_row].Cells[2].Value = tableY[count_row];
                }
            }

        }
    }
}
