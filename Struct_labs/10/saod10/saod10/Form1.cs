using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saod10
{
    public partial class Form1 : Form
    {
        private const int Level = 3;
        //Высота и ширина для отрисовки
        private int _width;
        private int _height;
        // Bitmap
        private Bitmap _fractal;
        //для отрисовки
        private Graphics _graph;

        public Form1()
        {
            InitializeComponent();
            //инициализируем ширину и высоту
            _width = pictureBox1.Width;
            _height = pictureBox1.Height;
        }   

        private void CarpetButton_Click(object sender, EventArgs e)
        {
            //создаем Bitmap для прямоугольника
            _fractal = new Bitmap(_width, _height);
            // cоздаем новый объект Graphics из указанного Bitmap
            _graph = Graphics.FromImage(_fractal);
            //создаем прямоугольник и вызываем функцию отрисовки ковра
            RectangleF carpet = new RectangleF(0, 0, _width, _height);
            DrawCarpet(Level, carpet);
            //отображаем результат
            pictureBox1.BackgroundImage = _fractal;
        }       

        private void DrawCarpet(int level, RectangleF carpet)
        {
            //проверяем, закончили ли мы построение
            if (level == 0)
            {
                //Рисуем прямоугольник
                _graph.FillRectangle(Brushes.Blue, carpet);
            }
            else
            {
                // делим прямоугольник на 9 частей
                var width = carpet.Width / 3f;
                var height = carpet.Height / 3f;
                // (x1, y1) - координаты левой верхней вершины прямоугольника
                // от нее будем отсчитывать остальные вершины маленьких прямоугольников
                var x1 = carpet.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;

                var y1 = carpet.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;

                DrawCarpet(level - 1, new RectangleF(x1, y1, width, height)); // левый 1(верхний)
                DrawCarpet(level - 1, new RectangleF(x2, y1, width, height)); // средний 1
                DrawCarpet(level - 1, new RectangleF(x3, y1, width, height)); // правый 1
                DrawCarpet(level - 1, new RectangleF(x1, y2, width, height)); // левый 2
                DrawCarpet(level - 1, new RectangleF(x3, y2, width, height)); // правый 2
                DrawCarpet(level - 1, new RectangleF(x1, y3, width, height)); // левый 3
                DrawCarpet(level - 1, new RectangleF(x2, y3, width, height)); // средний 3
                DrawCarpet(level - 1, new RectangleF(x3, y3, width, height)); // правый 3
            }
        }
    }
}
/*

        //функция вычисления координат средней точки
        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        } 
 
 private void TriangleButton_Click(object sender, EventArgs e)
       {
           //создаем Bitmap для треугольника
           _fractal = new Bitmap(_width, _height);
           // cоздаем новый объект Graphics из указанного Bitmap
           _graph = Graphics.FromImage(_fractal);
           //вершины треугольника
           PointF topPoint = new PointF(_width / 2f, 0);
           PointF leftPoint = new PointF(0, _height);
           PointF rightPoint = new PointF(_width, _height);
           //вызываем функцию отрисовки
           DrawTriangle(Level, topPoint, leftPoint, rightPoint);
           //отображаем получившийся фрактал
           pictureBox1.BackgroundImage = _fractal;
       }
private void DrawTriangle(int level, PointF top, PointF left, PointF right)
        {
            //проверяем, закончили ли мы построение
            if (level == 0)
            {
                PointF[] points = new PointF[3]
                {
                    top, right, left
                };
                //рисуем фиолетовый треугольник
                _graph.FillPolygon(Brushes.BlueViolet, points);
            }
            else
            {
                //вычисляем среднюю точку
                var leftMid = MidPoint(top, left); //левая сторона
                var rightMid = MidPoint(top, right); //правая сторона
                var topMid = MidPoint(left, right); // основание
                //рекурсивно вызываем функцию для каждого и 3 треугольников
                DrawTriangle(level - 1, top, leftMid, rightMid);
                DrawTriangle(level - 1, leftMid, left, topMid);
                DrawTriangle(level - 1, rightMid, topMid, right);
            }
        }
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     */
