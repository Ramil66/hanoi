using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Курсовая.Design;
using WindowsFormsApp1;

namespace Курсовая
{
    public partial class PlayGame : Form
    {
        Graphics g;                                                         //Главный графический элемент
        Bitmap bitmap;                                                      //Картина для фона
        Pen pen;                                                            //Перо для рисования
        Brush brush;                                                        //Заливка
        Board board;                                                        //Объект класса Board(доска для ханойской башни) 
        Color colorRods, colorDisk;                                         //Цвета для закраски дисков и стержней
        const int CONTROL_BLOCK_X = 0, CONTROL_BLOCK_Y = 540;               //Координаты блока управления формы
        const int CONTROL_BLOCK_SIZE_X = 1000, CONTROL_BLOCK_SIZE_Y = 260;  //Размер блока управления
        const int RADIUS_FOR_CONTROL_BLOCK = 25;                            //Радиус закругления для блока управления
        int FORM_SIZE_X, FORM_SIZE_Y;                                       //Размер формы
        bool isDown = false;                                                //Нажатие кнопки
        public PlayGame()
        {
            InitializeComponent();
        }
        //Инициализация элементов и загрузка формы  
        private void PlayGame_Load(object sender, EventArgs e)
        {
            FORM_SIZE_X = Size.Width;
            FORM_SIZE_Y = Size.Height;
            colorDisk = Color.FromArgb(61, 138, 247);
            colorRods = Color.Black;
            brush = new SolidBrush(Color.Black);
            board = new Board(FORM_SIZE_X, FORM_SIZE_Y);
            bitmap = new Bitmap(FORM_SIZE_X, FORM_SIZE_Y);
            pen = new Pen(Color.Black, 1);
            g = Graphics.FromImage(bitmap);
            //Отрисовка границ пунтка управления пользователя
            g.DrawLine(pen, RADIUS_FOR_CONTROL_BLOCK, CONTROL_BLOCK_Y, FORM_SIZE_X - RADIUS_FOR_CONTROL_BLOCK, CONTROL_BLOCK_Y);
            g.DrawArc(pen, -1, CONTROL_BLOCK_Y, 2 * RADIUS_FOR_CONTROL_BLOCK, 2 * RADIUS_FOR_CONTROL_BLOCK, 180, 90);
            g.DrawArc(pen, FORM_SIZE_X - 2 * RADIUS_FOR_CONTROL_BLOCK, CONTROL_BLOCK_Y, 2 * RADIUS_FOR_CONTROL_BLOCK, 2 * RADIUS_FOR_CONTROL_BLOCK, 270, 90);
            //Загрузка изображения в форму
            BackgroundImage = bitmap;
        }
        //Действие на нажатие кнопки(закрытие текущей вкладки и переход на предыдущую)
        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Отрисовка кнопки запуска игры
        private void roundButton2Paint()
        {
            Graphics gButton = Start.CreateGraphics();
            Brush brushButton = new SolidBrush(Color.White);
            Point[] point = { new Point(15, 10), new Point(30, 20), new Point(15, 30) };
            gButton.FillPolygon(brushButton, point);
        }
        //Отрисовка кнопки информации о правилах игры
        private void roundButton3Paint()
        {
            Graphics gButton = Info.CreateGraphics();
            Brush brushButton = new SolidBrush(Color.White);
            Font fontButton = new Font("Montserrat ExtraBold", 10);
            gButton.DrawString("?", fontButton, brushButton, 5, 2);
        }
        //Действие на нажатие второй кнопки(Начало игры)
        private void roundButton2_Click(object sender, EventArgs e)
        {
            try
            {
                board.Run(Convert.ToInt16(textBox1.Text), false);
                //Отчистка изображения формы 
                BackgroundImage = null;
                //Прорисовка стержней
                board.PaintBoard(g, 100, 450, 800);
                //Загрузка изображения
                BackgroundImage = bitmap;
                //Прорисовка дисков
                board.PaintRodWithDisks(this);
                //Запуск таймера
                timer1.Enabled = true;
            }
            catch { }
        }
        DateTime date = new DateTime(0, 0);             //Элемент даты и времени для загрузки секундомера
        //Таймер 1(для подсчета времени)
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Прибавление к элементу date секунды через каждую секунду и его последующий вывод в элемент label
            date = date.AddSeconds(1);
            time.Text = date.ToString("mm:ss");
            countMove.Text = board.GetCountMove().ToString();
            //Проверка на конец игры(остановка таймера и вызов события конец игры)
            if (board.Check_End_Game())
            { 
                timer1.Enabled = false;
                End_Game();
            }
        }
        //Таймер 2(для прорисовки кнопок, работает все время через 1 мс и вызывает две функции для прорисовки кнопок)
        private void timer2_Tick(object sender, EventArgs e)
        {
            roundButton2Paint();
            roundButton3Paint();
        }
        public static int parentX, parentY;         //Координаты текущей формы
        //Действие на нажатие третьей кнопки(отрытия правил игры для пользователя)
        private void roundButton3_Click(object sender, EventArgs e)
        {
            Form backGround = new Form();
            using (RulesGame rulesForm=new RulesGame())
            {
                backGround.StartPosition = FormStartPosition.Manual;
                backGround.FormBorderStyle = FormBorderStyle.None;
                backGround.Opacity = 0.5d;
                backGround.BackColor = Color.Black;
                backGround.Size = this.Size;
                backGround.Location = this.Location;
                backGround.ShowInTaskbar = false;
                backGround.Show();
                rulesForm.Owner = backGround;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                rulesForm.ShowDialog();
                backGround.Dispose();

            }
        }
        //Фукнция конец игры запускающаяся при окончании игры(Вызывает форму в которой указаны время и количество ходов игрока)
        private void End_Game()
        {
            Data.date = date;
            Data.countMove = board.GetCountMove();
            Form backGround = new Form();
            using (EndGame endGame = new EndGame())
            {
                backGround.StartPosition = FormStartPosition.Manual;
                backGround.FormBorderStyle = FormBorderStyle.None;
                backGround.Opacity = 0.5d;
                backGround.BackColor = Color.Black;
                backGround.Size = this.Size;
                backGround.Location = this.Location;
                backGround.ShowInTaskbar = false;
                backGround.Show();
                endGame.Owner = backGround;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                endGame.ShowDialog();
                backGround.Dispose();
                this.Close();
            }
        }
    }
}
