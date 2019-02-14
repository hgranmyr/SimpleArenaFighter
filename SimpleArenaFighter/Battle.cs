using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArenaFighter
{
    class Battle
    {

        public void AddFight(string victory)
        {
            log.Add(victory);
        }

        public List<string> log = new List<string>();
    }
}
