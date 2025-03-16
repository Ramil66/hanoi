//Подключение бибилотек
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Курсовая
{
    public partial class MainForm : Form
    {
        Graphics g;         //Элемент графики
        Pen MyPen;          //Элемент для рисования
        Brush MyBrush;      //Элемент для закраски
        public MainForm()
        {
            InitializeComponent();
        }
        //Инициализация элементов и загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            MyBrush = new SolidBrush(Color.Black);
            MyPen = new Pen(Color.Black, 2);
        }
        //Действие на нажатие первой кнопки(Октрытие формы для игры)
        private void roundButton1_Click(object sender, EventArgs e)
        {
            Form form = new PlayGame();
            form.Show();
        }
        //Действие на нажатие третьей кнопки(Закрытие текущей формы)
        private void roundButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Действие на нажатие второй кнопки(Октрытие формы для сравнения алгоритмов)
        private void roundButton2_Click(object sender, EventArgs e)
        {
            Form form = new ComparisonAlgorithms();
            form.Show();
        }
    }
}
