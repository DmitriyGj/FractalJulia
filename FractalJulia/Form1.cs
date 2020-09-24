using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalJulia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            button1.Location = new Point(this.Width / 2 - button1.Width / 2 - 15, button1.Location.Y);
            pictureBox1.Size = new Size(this.Width, this.Height - button1.Height);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //функция зарисовки фрактала
        public void DrawFractal() 
        {
            //битмап для рисовния
            Bitmap Drawer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // при каждой итерации, вычисляется znew = zold² + С
            // вещественная  и мнимая части постоянной C
            double cRe, cIm;
            // вещественная и мнимая части старой и новой
            double newRe, newIm, oldRe, oldIm;
            // Можно увеличивать и изменять положение
            double zoom = 1.5, moveX = 0, moveY = 0;
            //Определяем после какого числа итераций функция должна прекратить свою работу
            int maxIterations = 300;
            //выбираем несколько значений константы С, это определяет форму фрактала Жюлиа
            cRe = -0.69176;
            cIm = -0.37721;
            //"перебираем" каждый пиксель
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    //вычисляется реальная и мнимая части числа z
                    //на основе расположения пикселей,масштабирования и значения позиции
                    newRe = 1.5 * (x - pictureBox1.Width / 2) / (0.5 * zoom * pictureBox1.Width) + moveX;
                    newIm = (y - pictureBox1.Height / 2) / (0.5 * zoom * pictureBox1.Height) + moveY;
                    //i представляет собой число итераций 
                    int i;
                    //начинается процесс итерации
                    for (i = 0; i < maxIterations; i++)
                    {
                        //Запоминаем значение предыдущей итерации
                        oldRe = newRe;
                        oldIm = newIm;
                        // в текущей итерации вычисляются действительная и мнимая части 
                        newRe = oldRe * oldRe - oldIm * oldIm + cRe;
                        newIm = 2 * oldRe * oldIm + cIm;
                        // если точка находится вне круга с радиусом 2 - прерываемся
                        if ((newRe * newRe + newIm * newIm) >= 4) break;
                    }
                    Drawer.SetPixel(x, y, i != maxIterations ? Color.FromArgb(255,(i * 9) % 255,1, (i * 9) % 255) : Color.FromArgb(0, 0, 0));
                }
                pictureBox1.Image = Drawer;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DrawFractal();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
