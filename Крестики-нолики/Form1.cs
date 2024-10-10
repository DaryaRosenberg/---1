using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[5,5];
        private int player;
        public Form1()
        {
            InitializeComponent();
            this.Height = 700;
            this.Width = 900;
            player = 1;
            label1.Text = "Текущий ход: игрок 1";
            for (int i = 0; i < buttons.Length / 5; i++)
            {
                for (int j = 0; j < buttons.Length / 5; j++)
                { 
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(100, 100);

                
                }

            }
            setButtons();

        }

        private void setButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j].Location = new Point(12 + 100 * j, 12 + 100 * i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font= new Font (new FontFamily("Microsoft Sans Serif"), 50);
                    this.Controls.Add(buttons[i, j]);
                }

            }
        }     

        private void button1_Click(object sender, EventArgs e)
        {
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "x");
                    player = 0;
                    label1.Text = "Текущий ход: игрок 2";
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "o");
                    player = 1;
                    label1.Text = "Текущий ход: игрок 1";
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            Check();
            //MessageBox.Show(sender.GetType().GetProperty("Name").GetValue(sender).ToString());

        }

        private void Check()
        {
            // Проверка горизонтальных линий
            for (int i = 0; i < 5; i++)
            {
                if (buttons[i, 0].Text == buttons[i, 1].Text &&
                    buttons[i, 1].Text == buttons[i, 2].Text &&
                    buttons[i, 2].Text == buttons[i, 3].Text &&
                    buttons[i, 3].Text == buttons[i, 4].Text &&
                    buttons[i, 0].Text != "")
                {
                    MessageBox.Show("Вы победили!");
                    return; // Выход из функции, если победа
                }
            }

            // Проверка вертикальных линий
            for (int j = 0; j < 5; j++)
            {
                if (buttons[0, j].Text == buttons[1, j].Text &&
                    buttons[1, j].Text == buttons[2, j].Text &&
                    buttons[2, j].Text == buttons[3, j].Text &&
                    buttons[3, j].Text == buttons[4, j].Text &&
                    buttons[0, j].Text != "")
                {
                    MessageBox.Show("Вы победили!");
                    return; // Выход из функции, если победа
                }
            }

            // Проверка диагоналей
            // Главная диагональ
            if (buttons[0, 0].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 2].Text &&
                buttons[2, 2].Text == buttons[3, 3].Text &&
                buttons[3, 3].Text == buttons[4, 4].Text &&
                buttons[0, 0].Text != "")
            {
                MessageBox.Show("Вы победили!");
                return; // Выход из функции, если победа
            }
            // Вторая диагональ
            if (buttons[0, 4].Text == buttons[1, 3].Text &&
                buttons[1, 3].Text == buttons[2, 2].Text &&
                buttons[2, 2].Text == buttons[3, 1].Text &&
                buttons[3, 1].Text == buttons[4, 0].Text &&
                buttons[0, 4].Text != "")
            {
                MessageBox.Show("Вы победили!");
                return; // Выход из функции, если победа
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы StartForm
            StartForm form = new StartForm();
            //Показываем
            form.ShowDialog();
            // Закрываем Form1 и запускаем StartForm как главную форму
            this.Close();
        }
    }
}    

