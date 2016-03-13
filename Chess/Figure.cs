using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    public abstract class Figure
    {
        private int rank;
        private Teams team;
        public int x;
        public int y;
        protected int stepCout = 0;
        public string name;

        protected Figure(int rank, int x, int y, string name, Teams team)
        {
            this.rank = 1;
            this.x = x;
            this.y = y;
            this.name = name;
            this.team = team;
        }

        public Teams Team
        {
            get { return team; }

           protected set
            { team = value; }
        }

        protected bool State
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public virtual int step(int x, int y, Teams team)
        {
            throw new System.NotImplementedException();
        }

        public virtual int takeOn(int x, int y, Teams team)
        {
            throw new System.NotImplementedException();
        }
    }
}