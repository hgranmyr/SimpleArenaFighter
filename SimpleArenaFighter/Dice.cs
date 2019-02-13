using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;

namespace SimpleArenaFighter
{
    class Dice
    {
        public InfoGenerator iGen = new InfoGenerator();
        public int diceRoll;

        public int RollDice()
        {
            diceRoll = iGen.Next(1, 6);
            return diceRoll;
        }

    }
}
