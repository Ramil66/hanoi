using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Курсовая
{
    internal class Board
    {
        private class Disk
        {
            public int width = 0;                       //Размер диска
            public static int HALF_DISKS_HEIGHT = 15;   //Половина высоты диска для отрисовки
            public int X, Y;                            //Координаты диска на форме
            public PictureBox pictureBox;               //Элемент pictureBox для вывода диска на экран
            public bool isDown = false;                 //Нажатие на диск
            public static Board board;                  //Статический элемент доски на которой будут диски
            public int NumberRods;                      //Номер диска
            public Disk() { }
            //Конструктор диска(Инициализация полей)
            public Disk(int width, Board b)
            {
                this.width = width;
                pictureBox = new PictureBox();
                pictureBox.Width = width;
                pictureBox.Height = 2 * HALF_DISKS_HEIGHT;
                //Закрепление событий на нажатие, движения и отпускание мыши
                pictureBox.MouseDown += MouseDown;
                pictureBox.MouseMove += MouseMove;
                pictureBox.MouseUp += MouseUp;
                board = b;
                NumberRods = 0;
            }
            public static bool operator >(Disk left, Disk right) { return left.width > right.width; }
            public static bool operator <(Disk left, Disk right) { return left.width < right.width; }
            //Метод для прорисовки диска в pictureBox и его размещение на форме
            public void PaintDisk(Form form, Brush brush, int x, int y)
            {
                pictureBox.Location = new Point(x, y);
                form.Controls.Add(pictureBox);
                Bitmap b = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics g = Graphics.FromImage(b);
                g.FillRectangle(brush, HALF_DISKS_HEIGHT, 0, width - 2 * HALF_DISKS_HEIGHT, 2 * HALF_DISKS_HEIGHT);
                g.FillEllipse(brush, 0, 0, 2 * HALF_DISKS_HEIGHT, 2 * HALF_DISKS_HEIGHT);
                g.FillEllipse(brush, width - 2 * HALF_DISKS_HEIGHT, 0, 2 * HALF_DISKS_HEIGHT, 2 * HALF_DISKS_HEIGHT);
                pictureBox.Image = b;
                X = x;
                Y = y;
            }
            //Та же прорисовка, но размещение на groupBox
            public void PaintDisk(GroupBox groupBox, Brush brush, int x, int y)
            {
                pictureBox.Location = new Point(x, y);
                groupBox.Controls.Add(pictureBox);
                Bitmap b = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics g = Graphics.FromImage(b);
                g.FillRectangle(brush, HALF_DISKS_HEIGHT, 0, width - 2 * HALF_DISKS_HEIGHT, 2 * HALF_DISKS_HEIGHT);
                g.FillEllipse(brush, 0, 0, 2 * HALF_DISKS_HEIGHT, 2 * HALF_DISKS_HEIGHT);
                g.FillEllipse(brush, width - 2 * HALF_DISKS_HEIGHT, 0, 2 * HALF_DISKS_HEIGHT, 2 * HALF_DISKS_HEIGHT);
                pictureBox.Image = b;
                X = x;
                Y = y;
            }
            int tempX, tempY;           //Переменные для хранения предудущей позиции диска на форме или pictureBox 
            //Событие на нажатие мыши
            public void MouseDown(object sender, MouseEventArgs e)
            {
                if (board.Rods[NumberRods][board.Rods[NumberRods].Count - 1] == this)
                {
                    isDown = true;
                    tempX = e.X;
                    tempY = e.Y;
                }
            }
            //Событие на перемещение мыши
            public void MouseMove(object sender, MouseEventArgs e)
            {
                if (isDown)
                {
                    var pt = pictureBox.Location;
                    pt.Offset(e.X - tempX, e.Y - tempY);
                    pictureBox.Location = pt;
                }
            }
            //Событие на отпускание кнопки мыши
            public void MouseUp(object sender, MouseEventArgs e)
            {
                if (isDown)
                {
                    if (pictureBox.Location.X > board.RODS_X[0] - board.MAXSIZEDISK && pictureBox.Location.X < board.RODS_X[0] + board.MAXSIZEDISK && pictureBox.Location.Y < board.RODS_Y)
                    {
                        board.MoveRing(NumberRods, 0);
                    }
                    if (pictureBox.Location.X > board.RODS_X[1] - board.MAXSIZEDISK && pictureBox.Location.X < board.RODS_X[1] + board.MAXSIZEDISK && pictureBox.Location.Y < board.RODS_Y)
                    {
                        board.MoveRing(NumberRods, 1);
                    }
                    if (pictureBox.Location.X > board.RODS_X[2] - board.MAXSIZEDISK && pictureBox.Location.X < board.RODS_X[2] + board.MAXSIZEDISK && pictureBox.Location.Y < board.RODS_Y)
                    {
                        board.MoveRing(NumberRods, 2);
                    }
                }
                isDown = false;
                board.PaintRodWithDisksForms();
            }
        };
        int countDisk;                                      //Количество дисков        
        List<Disk>[] Rods = new List<Disk>[3];              //Список стержней
        int MINSIZEDISK = 20;                               //Минимальный размер диска
        int MAXSIZEDISK;                                    //Максимальный Размер диска
        int DIFFERENCE_SIZE_DISKS = 25;                     //Разница размеров дисков
        int[] RODS_X = new int[4];                          //Координаты стержней 
        int RODS_Y;                                         //Координаты стержней
        int MAX_Y_RODS;                                     //Высота стержня
        int DEPTH_BOARD = 15, DEPTH_ROD = 10;               //Ширина стержней и основной доски               
        Graphics graphics;                                  //Элемент графики
        Bitmap bitmap;                                      //Изображения для фона
        Brush brush;                                        //Заливка
        int countMove = 0;                                  //Количество ходов
        Form form;                                          //Форма на которой загружается доска
        GroupBox groupBox;                                  //GroupBox на которой загружается доска
        bool show = false;                                  //Вывод перещений
        Color colorDisk = Color.FromArgb(61, 138, 247);     //Цвет диска
        Color colorRod = Color.Black;                       //Цвет стержня
        public Thread th1, th2, th3;                        //Потоки
        //Конструктор
        public Board(int size_X, int size_Y)
        {
            bitmap = new Bitmap(size_X, size_Y);
        }
        //Конструктор
        public Board(Graphics g)
        {
            this.graphics = g;
            brush = new SolidBrush(colorDisk);
        }
        //Функция для заполнения стержней дисками
        public void Run(int countDisk, bool show)
        {
            this.countDisk = countDisk;
            this.show = show;
            for (int i = 0; i < 3; i++)
            {
                Rods[i] = new List<Disk>();
            }
            for (int i = 0; i < countDisk; i++)
            {
                Rods[0].Add(new Disk(MINSIZEDISK + DIFFERENCE_SIZE_DISKS * (countDisk - i), this));
                MAXSIZEDISK = Rods[0].Last().width;
            }
        }
        //Отрисовка дисков на форме
        public void PaintRodWithDisks(Form form)
        {
            brush = new SolidBrush(colorDisk);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Rods[i].Count; j++)
                {
                    Rods[i][j].PaintDisk(form, brush, RODS_X[i] - Rods[i][j].width / 2 - Disk.HALF_DISKS_HEIGHT / 2, RODS_Y - (j + 1) * 2 * Disk.HALF_DISKS_HEIGHT - j);
                }
            }
            this.form = form;
        }
        //Отрисовка дисков на groupBox
        public void PaintRodWithDisks(GroupBox groupBox)
        {
            brush = new SolidBrush(colorDisk);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Rods[i].Count; j++)
                {
                    Rods[i][j].PaintDisk(groupBox, brush, RODS_X[i] - Rods[i][j].width / 2 - Disk.HALF_DISKS_HEIGHT / 2, RODS_Y - (j + 1) * 2 * Disk.HALF_DISKS_HEIGHT - j);
                }
            }
            this.groupBox = groupBox;
        }
        //Отрисовка формы на форме(уже заданой)
        public void PaintRodWithDisksForms()
        {
            brush = new SolidBrush(colorDisk);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Rods[i].Count; j++)
                {
                    Rods[i][j].PaintDisk(form, brush, Rods[i][j].X, Rods[i][j].Y);
                }
            }
        }
        //Отрисовка формы на groupBox(уже заданой)
        public void PaintRodWithDisksGroupBoxs()
        {
            brush = new SolidBrush(colorDisk);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Rods[i].Count; j++)
                {
                    Rods[i][j].PaintDisk(groupBox, brush, RODS_X[i] - Rods[i][j].width / 2 - Disk.HALF_DISKS_HEIGHT / 2, RODS_Y - (j + 1) * 2 * Disk.HALF_DISKS_HEIGHT - j);
                }
            }
        }
        //Отрисовка стержней
        public void PaintBoard(Graphics g, int x, int y, int sizeX)
        {
            Disk tempDisk = new Disk();
            brush = new SolidBrush(colorRod);
            DEPTH_BOARD = 15;
            DEPTH_ROD = 10;
            int HEIGHT_ROD = (2 * countDisk + 1) * Disk.HALF_DISKS_HEIGHT;
            g.FillRectangle(brush, x + DEPTH_BOARD / 2, y, sizeX, DEPTH_BOARD);
            g.FillEllipse(brush, x, y, DEPTH_BOARD, DEPTH_BOARD);
            g.FillEllipse(brush, x + sizeX, y, DEPTH_BOARD, DEPTH_BOARD);
            g.FillRectangle(brush, x + sizeX / 2 - DEPTH_ROD / 2, y - HEIGHT_ROD, DEPTH_ROD, HEIGHT_ROD);
            g.FillEllipse(brush, x + sizeX / 2 - DEPTH_ROD / 2, y - HEIGHT_ROD - DEPTH_ROD / 2, DEPTH_ROD, DEPTH_ROD);
            g.FillRectangle(brush, x + sizeX / 4 - DEPTH_ROD, y - HEIGHT_ROD, DEPTH_ROD, HEIGHT_ROD);
            g.FillEllipse(brush, x + sizeX / 4 - DEPTH_ROD, y - HEIGHT_ROD - DEPTH_ROD / 2, 10, 10);
            g.FillRectangle(brush, x + sizeX * 3 / 4 - DEPTH_BOARD / 2, y - HEIGHT_ROD, DEPTH_ROD, HEIGHT_ROD);
            g.FillEllipse(brush, x + sizeX * 3 / 4 - DEPTH_BOARD / 2, y - HEIGHT_ROD - DEPTH_ROD / 2, 10, 10);
            RODS_X[0] = x + sizeX / 4;
            RODS_X[1] = x + sizeX / 2;
            RODS_X[2] = x + sizeX * 3 / 4;
            RODS_X[3] = x + sizeX;
            RODS_Y = y;
            MAX_Y_RODS = y - HEIGHT_ROD;
        }
        //Функция для перемещение диска
        public bool MoveRing(int outputRod, int inputRod)
        {
            //Проверка на возможность перемещения
            if (Rods[2].Count != countDisk && Rods[outputRod].Count != 0 && (Rods[inputRod].Count == 0 || Rods[inputRod].Last().width > Rods[outputRod].Last().width))
            {
                if (show)
                {
                    for (int i = Rods[outputRod][Rods[outputRod].Count - 1].Y; i > MAX_Y_RODS - 3 * Disk.HALF_DISKS_HEIGHT; i--)
                    {
                        var pt = Rods[outputRod][Rods[outputRod].Count - 1].pictureBox.Location;
                        pt.Offset(Rods[outputRod][Rods[outputRod].Count - 1].X, i);
                        Rods[outputRod][Rods[outputRod].Count - 1].pictureBox.Location = pt;
                    }
                    for (int i = Rods[outputRod][Rods[outputRod].Count - 1].X; i < RODS_X[inputRod] - Rods[outputRod][Rods[outputRod].Count - 1].width / 2; i++)
                    {
                        var pt = Rods[outputRod][Rods[outputRod].Count - 1].pictureBox.Location;
                        pt.Offset(i, Rods[outputRod][Rods[outputRod].Count - 1].Y);
                        Rods[outputRod][Rods[outputRod].Count - 1].pictureBox.Location = pt;
                    }
                    Rods[inputRod].Add(Rods[outputRod][Rods[outputRod].Count - 1]);
                    Rods[outputRod].RemoveAt(Rods[outputRod].Count - 1);
                    Rods[inputRod][Rods[inputRod].Count - 1].NumberRods = inputRod;
                    PaintRodWithDisksGroupBoxs();
                }
                else
                {
                    Rods[inputRod].Add(Rods[outputRod][Rods[outputRod].Count - 1]);
                    Rods[outputRod].RemoveAt(Rods[outputRod].Count - 1);
                    Rods[inputRod][Rods[inputRod].Count - 1].X = RODS_X[inputRod] - Rods[inputRod][Rods[inputRod].Count - 1].width / 2 - DEPTH_ROD / 3;
                    Rods[inputRod][Rods[inputRod].Count - 1].Y = RODS_Y - Rods[inputRod].Count * 2 * Disk.HALF_DISKS_HEIGHT - Rods[inputRod].Count + 1;
                    Rods[inputRod][Rods[inputRod].Count - 1].NumberRods = inputRod;
                }
                countMove++;  
                return true;
            }
            else
                return false;
        }
        //Геттер и сеттеры на размер дисков
        public int GetMaxSizeDisk()
        {
            return MAXSIZEDISK;
        }
        public void SetMaxSizeDisk(int maxSize)
        {
            MAXSIZEDISK = maxSize;
        }
        public void SetMinSizeDisk(int minSize)
        {
            MINSIZEDISK = minSize;
        }
        public void SetDifferenceSizeDisk(int differenceSizeDisk)
        {
            DIFFERENCE_SIZE_DISKS = differenceSizeDisk;
        }
        public void SetHalfWidthDisk(int halfWidthDisk)
        {
            Disk.HALF_DISKS_HEIGHT = halfWidthDisk;
        }
        //Рекурсивный алгоритм
        private void RecursiveMethod(int countDisk, int positionOutput, int positionInput)
        {
            if (countDisk == 0)
            {
                return;
            }
            int otherPosition = 3 - positionInput - positionOutput;
            RecursiveMethod(countDisk - 1, positionOutput, otherPosition);
            MoveRing(positionOutput, positionInput);
            RecursiveMethod(countDisk - 1, otherPosition, positionInput);
        }
        //Запуск рекурсивного алгоритма
        public void Recursive_Algorithm()
        {
            RecursiveMethod(Rods[0].Count, 0, 2);
            th1.Abort();
        }
        //Запуск алгоритма треугольника
        public void Triangle_Algorithm()
        {
            int countSmallDisk = 0, pastCountSmallDisk = 0;
            while (Rods[2].Count != countDisk)
            {
                countSmallDisk = (countSmallDisk + 1) % 3;
                if (MoveRing(pastCountSmallDisk, countSmallDisk))
                {
                    pastCountSmallDisk = countSmallDisk;
                    if (countSmallDisk == 0)
                    {
                        if (MoveRing(1, 2)) ;
                        else MoveRing(2, 1);
                    }
                    if (countSmallDisk == 1 && Rods[1].Count != countDisk)
                    {
                        if (MoveRing(0, 2)) ;
                        else MoveRing(2, 0);
                    }
                    if (countSmallDisk == 2)
                    {
                        if (MoveRing(0, 1)) ;
                        else MoveRing(1, 0);
                    }
                }
            }
            th2.Abort();
        }
        //Проверка на завершение игры
        public bool Check_End_Game()
        {
            return Rods[2].Count == countDisk;
        }
        //Запуск циклического алгоритма
        public void Cycle_Algorithm()
        {
            if (countDisk % 2 == 0)
            {
                while (Rods[2].Count != countDisk)
                {
                    if (MoveRing(0, 1)) ;
                    else if (MoveRing(1, 0)) ;
                    if (MoveRing(0, 2)) ;
                    else if (MoveRing(2, 0)) ;
                    if (MoveRing(1, 2)) ;
                    else if (MoveRing(2, 1)) ;
                }
            }
            else
            {
                while (Rods[2].Count != countDisk)
                {
                    if (MoveRing(0, 2)) ;
                    else if (MoveRing(2, 0)) ;
                    if (MoveRing(0, 1)) ;
                    else if (MoveRing(1, 0)) ;
                    if (MoveRing(1, 2)) ;
                    else if (MoveRing(2, 1)) ;
                }
            }
            th3.Abort();
        }
        //Геттер на количество ходов в доске
        public int GetCountMove()
        {
            return countMove;
        }
    }
}
