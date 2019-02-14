using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArenaFighter
{
    class Opponent : Character
    {
        public Opponent(string name, int hp, int str, int dmg)
        {
            this.name = name;
            this.hp = hp;
            this.str = str;
            this.dmg = dmg;
        }
    }
}
