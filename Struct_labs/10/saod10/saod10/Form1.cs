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
        private Bitmap _fr;
        //для отрисовки
        private Graphics _g;

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
            _fr = new Bitmap(_width, _height);
            // cоздаем новый объект Graphics из указанного Bitmap
            _g = Graphics.FromImage(_fr);
            //создаем прямоугольник и вызываем функцию отрисовки ковра
            RectangleF ct = new RectangleF(0, 0, _width, _height);
            DrawCarpet(Level, ct);
            //отображаем результат
            pictureBox1.BackgroundImage = _fr;
        }       

        private void DrawCarpet(int lvl, RectangleF ct)
        {
            //проверяем, закончили ли мы построение
            if (lvl == 0)
            {
                //Рисуем прямоугольник
                _g.FillRectangle(Brushes.Blue, ct);
            }
            else
            {
                // делим прямоугольник на 9 частей
                var width = ct.Width / 3f;
                var height = ct.Height / 3f;
                // (x1, y1) - координаты левой верхней вершины прямоугольника
                // от нее будем отсчитывать остальные вершины маленьких прямоугольников
                var x1 = ct.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;

                var y1 = ct.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;

                DrawCarpet(lvl - 1, new RectangleF(x1, y1, width, height)); // левый 1(верхний)
                DrawCarpet(lvl - 1, new RectangleF(x2, y1, width, height)); // средний 1
                DrawCarpet(lvl - 1, new RectangleF(x3, y1, width, height)); // правый 1
                DrawCarpet(lvl - 1, new RectangleF(x1, y2, width, height)); // левый 2
                DrawCarpet(lvl - 1, new RectangleF(x3, y2, width, height)); // правый 2
                DrawCarpet(lvl - 1, new RectangleF(x1, y3, width, height)); // левый 3
                DrawCarpet(lvl - 1, new RectangleF(x2, y3, width, height)); // средний 3
                DrawCarpet(lvl - 1, new RectangleF(x3, y3, width, height)); // правый 3
            }
        }
    }
}
