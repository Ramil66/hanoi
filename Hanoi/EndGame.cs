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
    public partial class EndGame : Form
    {
        public EndGame()
        {
            InitializeComponent();
        }
        //Действие на нажатие кнопки(Закрытие формы)
        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Таймер для изменения свойства Opacity формы для пояления формы
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                timer1.Stop();
            }
            else
            {
                Opacity += 0.03d;
            }
        }
        //Загрзка формы
        private void EndGame_Load(object sender, EventArgs e)
        {
            this.Location = new Point(PlayGame.parentX + 350, PlayGame.parentY + 150);
            time.Text = Data.date.ToString("mm:ss");
            move.Text = Data.countMove.ToString();
        }
    }
}
