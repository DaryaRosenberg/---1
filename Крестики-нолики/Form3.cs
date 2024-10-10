using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Крестики_нолики
{
    public partial class Form3 : Form
    {
        private Button[,] buttons;
        private char[,] board;
        private char currentPlayer;
        
        public Form3()
        {
            InitializeComponent();
            InitializeGame();
            this.Height = 700;
            this.Width = 900;
        }
        
        private void InitializeGame()
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(300, 300);
            

            buttons = new Button[5, 5];
            board = new char[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new System.Drawing.Size(100, 100);
                    buttons[i, j].Location = new System.Drawing.Point(i * 100, j * 100);
                    buttons[i, j].Click += button1_Click;
                    this.Controls.Add(buttons[i, j]);
                    board[i, j] = ' ';
                   
                }
            }
            
            this.ResumeLayout(false);
            currentPlayer = 'X';
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = button.Location.X / 100;
            int col = button.Location.Y / 100;

            if (row >= 0 && row < 5 && col >= 0 && col < 5 && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                button.Text = currentPlayer.ToString();
                button.Enabled = false;

                if (CheckWin(currentPlayer))
                {
                    MessageBox.Show($"Игрок {currentPlayer} выиграл!");
                    return;
                }
                else if (CheckDraw())
                {
                    MessageBox.Show("Ничья!");
                    return;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    MakeComputerMove();
                }
            }
           

        }
        private void MakeComputerMove()
        {
            int bestScore = -1;
            int bestRow = -1;
            int bestCol = -1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        board[i, j] = 'O';
                        int score = EvaluateBoard('O');
                        board[i, j] = ' ';

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestRow = i;
                            bestCol = j;
                        }
                    }
                }
            }
            board[bestRow, bestCol] = 'O';
            buttons[bestRow, bestCol].Text = "O";
            buttons[bestRow, bestCol].Enabled = false;

            if (CheckWin('O'))
            {
                MessageBox.Show("Компьютер выиграл!");               

                return;
            }
            else if (CheckDraw())
            {
                MessageBox.Show("Ничья!");
                return;
            }
            else
            {
                currentPlayer = 'X';
            }
            
        }
        

        private int EvaluateBoard(char player)
        {
            
            return 0;
        }

        private bool CheckWin(char player)
        {
            // Проверка строк
            for (int i = 0; i < 5; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player && board[i, 3] == player && board[i, 4] == player)
                    return true;
            }
            // Проверка столбцов
            for (int i = 0; i < 5; i++)
            {
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player && board[3, i] == player && board[4, i] == player)
                    return true;
            }

            // Проверка диагоналей
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player && board[3, 3] == player && board[4, 4] == player)
                return true;
            if (board[0, 4] == player && board[1, 3] == player && board[2, 2] == player && board[3, 1] == player && board[4, 0] == player)
                return true;

            return false;
        
        }
        private bool CheckDraw()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы StartForm
            StartForm form = new StartForm();
            //Показываем
            form.ShowDialog();
            // Закрываем Form3 и запускаем StartForm как главную форму
            this.Close();
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
    }
}