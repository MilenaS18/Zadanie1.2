using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kursovik2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].LegendText = "График функции z1";

            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(-20, 20);
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-7, 7);
            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle; // стиль маркера точки данных
            chart1.Series[0].MarkerSize = 6;
            chart1.Series[0].MarkerColor = chart1.Series[0].Color; //цвет точки маркера
            chart1.Series[0].Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold); //настройка шрифта маркера
            chart2.Series[0].LegendText = "График функции z2";
            chart2.Series[0].Points.AddXY(0, 0);
            chart2.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle; // стиль маркера точки данных
            chart2.Series[0].MarkerSize = 6;
            chart2.Series[0].MarkerColor = chart2.Series[0].Color; //цвет точки маркера
            chart2.Series[0].Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold); //настройка шрифта маркера
            chart2.ChartAreas[0].AxisX.ScaleView.Zoom(-20, 20);
            chart2.ChartAreas[0].AxisY.ScaleView.Zoom(-7, 7);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            double Xmin = double.Parse(textBoxXmin.Text);
            double Xmax = double.Parse(textBoxXmax.Text);
            double Step = double.Parse(textBoxStep.Text);
            // Количество точек графика
            int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;
            // Массив значений X – общий для обоих графиков
            double[] x = new double[count];
            // Два массива Z– по одному для каждого графика
            double[] z1= new double[count];
            double[] z2=new double[count];

            // Расчитываем точки для графиков функции
            for (int i = 0; i < count; i++)
            {
                // Вычисляем значение X
            x[i] = Xmin + Step * i;
            z1[i] = ((Math.Sin((Math.PI / 2) + 3 * x[i])) / (1 - Math.Sin(3 * x[i] - Math.PI)));
            z2[i] = 1 / Math.Tan(5 / 4 * Math.PI + 3 / 2 * x[i]);
            }

            chart1.Series[0].Points.DataBindXY(x, z1);
            chart2.Series[0].Points.DataBindXY(x, z2);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}