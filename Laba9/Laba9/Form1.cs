using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Laba9
{
    public partial class Form1 : Form
    {
        Graphics dc; Pen p;
        public Form1()
        {
            InitializeComponent();
            dc = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.Red, 1);
        }
        /* Метод преобразования вещественной координаты X в целую */
        private int IX(double x)
        {
            double xx = x * (pictureBox1.Size.Width / 10.0) + 0.5;
            return (int)xx;
        }
        /* Метод преобразования вещественной координаты Y в целую */
        private int IY(double y)
        {
            double yy = pictureBox1.Size.Height - y * (pictureBox1.Size.Height / 7.0) + 0.5;
            return (int)yy;
        }
        /* Своя функция вычерчивания линии (экран 10х7 условных единиц) */
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            dc.DrawLine(p, point1, point2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double[] x; x = new double[3] { 1.0, 6.0, 3.0};
            double[] y; y = new double[3] { 1.0, 1.0, 5.0};
            int i, j;
            double Pi, Phi, cos_Phi, sin_Phi, dx, dy;
            double x0 = 3.0, y0 = 3.0, xold = 0.0, yold = 0.0;
            Pi = 4.0 * Math.Atan(1.0);
            Phi = 3 * Pi / 180;
            cos_Phi = Math.Cos(Phi);
            sin_Phi = Math.Sin(Phi);

            //смещение относительно центра вращения
            for (j = 0; j < 3; j++) { x[j] += x0; y[j] += y0; }
            //цикл прорисовки треугольников
            for (i = 0; i < 100; i++)
            {
                //прорисовка текущего треугольника
                for (j = 0; j <= 2; j++)
                {
                    //пересчет координат для текущего треугольника

                    dx = x[j] - x0;
                    dy = y[j] - y0;
                    x[j] = x0 + dx * cos_Phi - dy * sin_Phi;
                    y[j] = y0 + dx * sin_Phi + dy * cos_Phi;
                }
                // прорисовка треугольника
                xold = x[2]; yold = y[2];
                for (j = 0; j <= 2; j++)
                {
                    Draw(xold, yold, x[j], y[j]);
                    xold = x[j]; yold = y[j];

                }
            }
            // ******************************************** Подпись ***************
            Brush blueBrush = Brushes.Blue;
            Font boldTimesFont = new Font("Times New Roman", 12, FontStyle.Bold |

            FontStyle.Underline);

            string str = "Лабораторная работа No9";
            SizeF sizefText = dc.MeasureString(str, boldTimesFont);
            dc.DrawString(str, boldTimesFont, blueBrush,
            (pictureBox1.Size.Width - sizefText.Width) / 2,
            (pictureBox1.Size.Height - sizefText.Height) / 2);

        }
    }
}