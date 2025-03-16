using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class RulesGame : Form
    {
        public RulesGame()
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
        //Загрзка формы и инициализация полей
        private void RulesGame_Load(object sender, EventArgs e)
        { 
            this.Location = new Point(PlayGame.parentX + 375, PlayGame.parentY + 150);
        }
    }
}
