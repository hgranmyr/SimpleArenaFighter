using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;

namespace SimpleArenaFighter
{
    class Character
    {
        public string name;
        public int hp;
        public int str;
        public int dmg;

        static InfoGenerator infoGen = new InfoGenerator();

        public Character()
        {
        }
    }
}
