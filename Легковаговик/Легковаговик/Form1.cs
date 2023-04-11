using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Легковаговик.Class1;

namespace Легковаговик
{
    public partial class Form1 : Form
    {
        private CloudManager _cloudManager;
        private Timer _timer;

        public Form1()
        {
            InitializeComponent();

            // Создаем менеджер облаков
            _cloudManager = new CloudManager();

            // Создаем таймер для обновления экрана
            _timer = new Timer();
            _timer.Interval = 50;
            _timer.Tick += timer1_Tick;
            _timer.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Рисуем облака на экране
            _cloudManager.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Добавляем новое облако по клику мыши
            CloudType type = CloudType.small; // Тип облака, можно задать любой
            Point position = e.Location; // Позиция облака
            _cloudManager.AddCloud(type, position);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Обновляем положение облаков
            _cloudManager.Update(10, 0);

            // Перерисовываем экран
            pictureBox1.Invalidate();
        }
    }
}
