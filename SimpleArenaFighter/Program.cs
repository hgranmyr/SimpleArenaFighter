using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;

namespace SimpleArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {

            Round dice = new Round();
            InfoGenerator iGen = new InfoGenerator();
            Battle battle = new Battle();
            List<Opponent> defeated = new List<Opponent>();


            Player CreatePlayer()
            {
                return new Player(Console.ReadLine(), iGen.Next(1, 6), iGen.Next(1, 6), iGen.Next(1, 6));
            }

            Opponent GenerateOpponent()
            {
                return new Opponent(iGen.NextFirstName(), iGen.Next(1, 6), iGen.Next(1, 6), iGen.Next(1, 6));
            }


            Console.WriteLine(
                "Welcome to arena fighter!\n" +
                "Enter a name for your gladiator:"
                );
            Player player = CreatePlayer();




            bool keepAlive = true;
            while (keepAlive)
            {
                Console.Clear();
                Console.WriteLine(
                   " --- Player ---\n" +
                   " Name: " + player.name + "\n" +
                   " Health: " + player.hp + "\n" +
                   " Strenght: " + player.str + "\n" +
                   " Damgage:" + player.dmg
                   );

                Console.WriteLine(
                    "\n\n" +
                    " What do you want to do?\n" +
                    " F : Fight\n" +
                    " R : Retire"
                    );
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                string selection = consoleKey.Key.ToString();

                if (selection == "F")
                {
                    Fight();
                }
                else if (selection == "R")
                {
                    Retire();
                    keepAlive = false;
                }
                else
                {
                    Console.WriteLine("Not a valid selection.");
                    Console.ReadKey(true);
                }

            }


            void Fight()
            {
                Opponent opponent = GenerateOpponent();

                Console.Clear();
                Console.WriteLine(
                   "\n --- Player ---\n" +
                   " Name: " + player.name + "\n" +
                   " Health: " + player.hp + "\n" +
                   " Strenght: " + player.str + "\n" +
                   " Damgage:" + player.dmg
                    );
                Console.WriteLine(
                   "\n --- Opponent ---\n" +
                   " Name: " + opponent.name + "\n" +
                   " Health: " + opponent.hp + "\n" +
                   " Strenght: " + opponent.str + "\n" +
                   " Damgage:" + opponent.dmg
                    );
                Console.ReadKey(true);
                Console.Clear();

                while (player.hp > 0 && opponent.hp > 0)
                {

                    dice.RollDice();
                    int playerRoll = dice.diceRoll;
                    int pValue = player.str + playerRoll;

                    dice.RollDice();
                    int opponentRoll = dice.diceRoll;
                    int oValue = opponent.str + opponentRoll;

                    Console.WriteLine("\n--------------------");
                    Console.WriteLine("Rolls:\n" + player.name + " " + playerRoll + " vs " + opponent.name + " " + opponentRoll);
                    Console.WriteLine(
                           "\n\n" +
                           player.name + ": " + player.str + " + " + playerRoll + "(" + pValue + ")" + "\n" +
                           opponent.name + ": " + opponent.str + " + " + opponentRoll + "(" + oValue + ")"
                           );
                    Console.ReadKey(true);
                    if (pValue > oValue)
                    {
                        Console.WriteLine("\n--------------------");
                        Console.WriteLine(player.name + " attack " + opponent.name + ", " + opponent.name + " takes " + player.dmg + " damage!");
                        opponent.hp = opponent.hp - player.dmg;
                        Console.WriteLine(opponent.name + " " + opponent.hp);
                        Console.ReadKey(true);
                    }
                    else if (oValue > pValue)
                    {
                        Console.WriteLine("\n--------------------");
                        Console.WriteLine(opponent.name + " attack " + player.name + ", " + player.name + " takes " + opponent.dmg + " damage!");
                        player.hp = player.hp - opponent.hp;
                        Console.WriteLine(player.name + " " + player.hp);
                        Console.ReadKey(true);
                    }
                    else if (pValue == oValue)
                    {
                        Console.WriteLine("The players circle each other without attacking.");
                    }
                    else
                    {
                        break;
                    }
                }
                if (player.hp <= 0)
                {
                    Console.WriteLine("You have died.\n Game over.");
                    Console.ReadKey(true);
                    keepAlive = false;
                    Retire();
                }
                else if (opponent.hp <= 0)
                {
                    defeated.Add(opponent);
                    Console.WriteLine(player.name + " has defeated " + opponent.name);
                    Console.ReadKey(true);

                }
            }

            void Retire()
            {
                Console.Clear();
                int count = 0;
                int score = 0;

                foreach (var opponent in defeated)
                {
                    count++;
                    string victory = count + ": " + opponent.name;

                    battle.AddFight(victory);
                }

                foreach (var item in battle.log)
                {
                    score++;
                }

                Console.WriteLine(
                    "Your score is: " + score + "\n"+
                    "You have defeated the following gladiators: "
                    );
                foreach (var item in battle.log)
                {
                    Console.WriteLine(item + "\n");
                }
                Console.ReadKey(true);
            }

            Console.Clear();
            Console.WriteLine(" Thanks for using the software. \n Bye!");


            Console.ReadKey(true);
        }
    }
}
