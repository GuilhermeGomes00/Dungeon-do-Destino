using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Game.Cont
{
    public static class Dice
    {
        public static Random rng = new Random();

        public static int Roll(int min, int max)
        {
            return rng.Next(min, max + 1);
        }
    }
    
}