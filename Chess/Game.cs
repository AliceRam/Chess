using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public static class Game
    {
        private static readonly Figure [,] board = new Figure[8,8];
        /*
        *Заповнення масиву(дошки) відповідними фігурами
        */
        public static void initialize()
        {
            //МАСИВ ПОЧИНАЄТЬСЯ З "0"!
            for (int i = 0; i < 8; i++)
            {
                board[i, 1] = new Pawn(i + 1, 2, Teams.white);
                board[i, 6] = new Pawn(i + 1, 7, Teams.black);

            }
        }

        /*
        *Виконнаня дій користувача(крок фігури, захоплення фігури)
        */
        public static int play(int x, int y, int X, int Y, Teams team)
        {
           // while (true) УМОВИ ПРИ ЯКИХ ВІДБУВАТЕМЕТЬСЯ ГРА
            if (getFigure(X, Y) == null)
            {
                if (getFigure(x, y, team).step(X, Y, team) == 0)
                {
                    board[X - 1, Y - 1] = getFigure(x, y);
                    board[x - 1, y - 1] = null;
                    return 0;
                }
                else
                {
                    MessageBox.Show("Неможливий крок");
                    return 1;
                }
                
            }
            return 1;
        }

        /*
        *Повертає вибрану фігуру, враховуючи команду
        */
        public static Figure getFigure(int i, int j, Teams team)
        {
            if (board[i - 1, j - 1].Team == team)
            {
                return board[i - 1, j - 1];
            }
            else
            {
                MessageBox.Show("Хід команди" +' '+team.ToString());
                return null;
            }
        }

        /*
        *Повертає обрану фігуру
        */
        public static Figure getFigure(int i, int j)
        {
            return board[i - 1, j - 1];
        }
    }
}