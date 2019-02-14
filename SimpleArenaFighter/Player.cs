using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArenaFighter
{
    class Player : Character
    {

        public Player(string name, int hp, int str, int dmg)
        {
            this.name = name;
            this.hp = hp;
            this.str = str;
            this.dmg = dmg;

        }
    }
}
