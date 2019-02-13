using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;

namespace SimpleArenaFighter
{
    class Character
    {

        static InfoGenerator infoGen = new InfoGenerator();

        public string Name { get; set; }
        public int hp = infoGen.Next(1, 10);
        public int str = infoGen.Next(1, 10);
        public int dmg = infoGen.Next(1, 10);

        public Character()
        {
        }
    }
}
