using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы Form1
            Form1 form1 = new Form1();
            //Показываем
            form1.ShowDialog();
            // Закрываем StartForm и запускаем Form1 как главную форму
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы Form1
            Form2 form2 = new Form2();
            //Показываем
            form2.ShowDialog();
            // Закрываем StartForm и запускаем Form1 как главную форму
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы Form1
            Form3 form3 = new Form3();
            //Показываем
            form3.ShowDialog();
            // Закрываем StartForm и запускаем Form1 как главную форму
            this.Close();
        }
    }
    
}
