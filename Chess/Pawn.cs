using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Math;

namespace Chess
{
    public class Pawn: Figure
    {
        public Pawn(int x, int y, Teams team): base (1,x,y,"Pawn", team)
        {
        }

        /*
        *Крок пішака
        */
        public override int step(int x, int y, Teams team)
        {
            if (stepCout == 0)
            {
                // Перший крок пішака(на 2 значення вперед)
                if (base.Team == Teams.white)
                {
                    if (x == base.x && (y - base.y) <= 2 && (y - base.y) > 0)
                    {
                        MessageBox.Show((y - base.y).ToString()+" 1");
                        //СОХРАНЕНИЕ КООРДИНАТ ПО Х!!!
                        base.y = y;
                        stepCout++;
                        return 0;
                    }
                     
                }
                else
                {
                    if (x == base.x && (y-base.y) >=-2 && (y - base.y) < 0)
                    {
                        //СОХРАНЕНИЕ КООРДИНАТ ПО Х!!!
                        MessageBox.Show((base.y-y).ToString() + " 2");
                        base.y = y;
                        stepCout++;
                        return 0;
                    }
                }
            }else 
            {
                if (base.Team == Teams.black)
                {
                    if ((x == base.x) && ((base.y - y) == 1))
                    {
                        //MessageBox.Show((y - base.y).ToString() + " 3");
                        base.y = y;
                        stepCout++;
                        return 0;
                    }
                   /* else
                    {
                        MessageBox.Show("asd");
                        return 1;
                    }*/
                }
                else
                {
                    if ((x == base.x) && ((y-base.y) == 1))
                    {
                        //MessageBox.Show((base.y-y).ToString() + " 4");
                        base.y = y;
                        stepCout++;
                        return 0;
                    }
                    /*else
                    {
                        MessageBox.Show("qwe");
                        return 1;
                    }*/
                }
                return 1;
            }
            return 1;
        }

        public override int takeOn(int x, int y, Teams team)
        {
            return base.takeOn(x, y, team);
        }
    }
}