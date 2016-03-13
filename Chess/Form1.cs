using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chess.Game;

namespace Chess
{
    public partial class Form1 : Form
    {
        Figure figure = null;
        private Teams team = Teams.black;
        private int stepCout = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            *Ініціалізація шахматної дошки(DataGridView)
            */
            dataGridView1.ColumnCount = 9;
            dataGridView1.RowCount = 9;
            dataGridView1.Rows[0].Height = 20;
            dataGridView1.Columns[0].Width = 20;
            char coloumnName = 'A';
            char rowName = '8';
            for (int i = 1; i < 9; i++)
            {
                dataGridView1.Columns[i].Width = 50;
                dataGridView1.Rows[i].Height = 50;
                dataGridView1[i, 0].Value = coloumnName++;
                dataGridView1[0, i].Value = rowName--;
            }

            initialize();
            showBoard();
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {   
            int x = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex.ToString());
            int y = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            //MessageBox.Show(figure.name);
            if ((getFigure(x, y) != null) && (figure ==null))
            {
                changeTeam(team);
                figure = Game.getFigure(x, y, team);
                if (figure == null)
                {
                    changeTeam(team);
                }
            }
            if ((getFigure(x, y) == null) && (figure != null))
            {
                if (play(figure.x, figure.y, x, y, team) == 0)
                {
                    figure = null;
                    showBoard();
                    MessageBox.Show("good");
                }
                else
                {
                    //MessageBox.Show(play(figure.x, figure.y, x, y, team).ToString()+" Bad");
                    changeTeam(team);
                    figure = null;
                }
            }

            //получение координат ячейки!
            //MessageBox.Show(dataGridView1.CurrentCell.ColumnIndex.ToString());
        }

        /*
        *Відображення фігур на дошці
        */
        private void showBoard()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (Game.getFigure(i, j) != null)
                        dataGridView1[i, j].Value = Game.getFigure(i, j).name+"x="+Game.getFigure(i,j).x;
                    else
                    {
                        dataGridView1[i, j].Value = null;
                    }
                }
            }
        }

        /*
        *Зміна поточного значення поля Teams
        */
        private void changeTeam(Teams team)
        {
            if (team == Teams.black)
            {
                this.team = Teams.white;
            }
            else
            {
                this.team = Teams.black;
            }
            //return team;
        }
    }
}
