using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    public class Rook : Figure
    {
        public Rook(int rank, int x, int y, string name) : base(5, x, y, "Rook", Teams.black)
        {
        }

        public override int step(int x, int y, Teams team)
        {
            if ((x == base.x) || (y == base.y))
            {
                base.x = x;
                base.y = y;
            }
            return 1;
        }
    }
}