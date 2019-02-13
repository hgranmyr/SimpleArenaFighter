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
        public int Health = infoGen.Next(1,10);
        public int Strength = infoGen.Next(1,10);
        public int Damage = infoGen.Next(1,10);

        public void CreateGladiator()
        {
        }
    }
}
