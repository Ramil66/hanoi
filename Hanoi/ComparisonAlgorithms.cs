using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Курсовая.Design;

namespace Курсовая
{
    public partial class ComparisonAlgorithms : Form
    {
        Board board1, board2, board3;                               //Объекты класса Board(Доски для ханойской башни)
        int countMoveRecursive, countMoveTriangle, countMoveCycle;  //Переменные для хранения количества ходов трех алгоритмов
        bool start = false;                                         //Запуск алгоритмов
        public ComparisonAlgorithms()
        {
            InitializeComponent();
        }

        private void ComparisonAlgorithms_Load(object sender, EventArgs e)
        {

        }

        //Действие на нажатие кнопки(Закрытие формы)
        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Отрисовка кнопки запуска алгоритмов
        private void roundButton2Paint()
        {
            Graphics gButton = Start.CreateGraphics();
            Brush brushButton = new SolidBrush(Color.White);
            Point[] point = { new Point(10, 5), new Point(25, 15), new Point(10, 25) };
            gButton.FillPolygon(brushButton, point);
        }
        //Действие на второй нажатие кнопки(Запуск алгоритмов)
        private void roundButton2_Click(object sender, EventArgs e)
        {
            //Отчистка всех groupBox
            Graphics clear=Recursive.CreateGraphics();
            clear.Clear(Color.White);
            clear=Triangle.CreateGraphics();
            clear.Clear(Color.White);
            clear=Cycle.CreateGraphics();
            clear.Clear(Color.White);
            Recursive.Controls.Clear();
            Triangle.Controls.Clear();
            Cycle.Controls.Clear();
            //Инициализация фона
            Bitmap bitmap1 = new Bitmap(Recursive.Width, Recursive.Height);
            Bitmap bitmap2 = new Bitmap(Triangle.Width, Triangle.Height);
            Bitmap bitmap3 = new Bitmap(Cycle.Width, Cycle.Height);
            Graphics g1 = Graphics.FromImage(bitmap1);
            Graphics g2 = Graphics.FromImage(bitmap2);
            Graphics g3 = Graphics.FromImage(bitmap3);
            board1 = new Board(g1);
            board2 = new Board(g2);
            board3 = new Board(g3);
            //Получение от пользователя количества дисков
            try
            {
                //При большом количестве дисков уменьшаем минимальный размер дисков
                if (Convert.ToInt16(textBox1.Text) > 4)
                {
                    board1.SetMinSizeDisk(15);
                    board2.SetMinSizeDisk(15);
                    board3.SetMinSizeDisk(15);
                    board1.SetDifferenceSizeDisk(15);
                    board2.SetDifferenceSizeDisk(15);
                    board3.SetDifferenceSizeDisk(15);
                }
                board1.Run(Convert.ToInt16(textBox1.Text), true);
                board2.Run(Convert.ToInt16(textBox1.Text), true);
                board3.Run(Convert.ToInt16(textBox1.Text), true);
                //Прорисовка трех стержней и дисков
                board1.PaintBoard(g1, 30, 250, 440);
                board1.PaintRodWithDisks(Recursive);
                Recursive.BackgroundImage = bitmap1;
                board2.PaintBoard(g2, 30, 250, 440);
                board2.PaintRodWithDisks(Triangle);
                Triangle.BackgroundImage = bitmap2;
                board3.PaintBoard(g3, 30, 250, 440);
                board3.PaintRodWithDisks(Cycle);
                Cycle.BackgroundImage = bitmap3;
                //Инициализация трех поток для паралельного запуска программы
                board1.th1 = new Thread(board1.Recursive_Algorithm);
                board2.th2 = new Thread(board2.Triangle_Algorithm);
                board3.th3 = new Thread(board3.Cycle_Algorithm);
                //Присваивание им максимального приоритета
                board1.th1.Priority = ThreadPriority.Highest;
                board2.th2.Priority = ThreadPriority.Highest;
                board3.th3.Priority = ThreadPriority.Highest;
                //Запуск потоков
                board1.th1.Start();
                board2.th2.Start();
                board3.th3.Start();
                start = true;
            }
            catch
            { }
        }
        //Таймер для прорисовка кнопки старта и ожидания завершения работы алгоритмов
        private void timer1_Tick(object sender, EventArgs e)
        {
            roundButton2Paint();
            if (start)
            {
                //Вывод количества ходов каждого алгоритма
                if (board1.Check_End_Game() && board2.Check_End_Game() && board3.Check_End_Game())
                {
                    richTextBox1.Text = "\n\n";
                    richTextBox1.Text += "Рекурсивный алгоритм-\t\t" + board1.GetCountMove() + " ходов\n\n";
                    richTextBox1.Text += "Алгоритм треугольника-\t\t" + board2.GetCountMove() + " ходов\n\n";
                    richTextBox1.Text += "Циклический алгоритм-\t\t" + board3.GetCountMove() + " ходов\n\n";
                    start = false;
                }
            }
        }
    }
}
