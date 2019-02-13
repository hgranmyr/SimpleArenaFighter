using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;

namespace SimpleArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Dice dice = new Dice();
            Opponent opponent = new Opponent();
            InfoGenerator iGen = new InfoGenerator();
            Battle fight = new Battle();
            Round turn = new Round();

            Console.WriteLine(
                "Welcome to arena fighter!\n" +
                "Enter a name for your gladiator:"
                );

            player.Name = Console.ReadLine();
            opponent.Name = iGen.NextFirstName();

            Console.Clear();

            Console.WriteLine(
               " --- Player ---\n"+
               " Name: " + player.Name + "\n"+
               " Health: " + player.Health + "\n"+
               " Strenght: " + player.Strength + "\n"+
               " Damgage:" + player.Damage
                );

            bool keepAlive = true;
            while (keepAlive)
            {
                Console.WriteLine(
                    "\n\n" +
                    " What do you want to do?\n" +
                    " 1: Fight\n" +
                    " 2: Retire"
                    );
                int selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Fight();
                        break;
                    case 2:
                        Retire();
                        break;
                    default:
                        Console.WriteLine("Not a valid selection.");
                        break;
                }

                void Fight()
                {
                    Console.Clear();
                    Console.WriteLine(
                       "\n --- Player ---\n" +
                       " Name: " + player.Name + "\n" +
                       " Health: " + player.Health + "\n" +
                       " Strenght: " + player.Strength + "\n" +
                       " Damgage:" + player.Damage
                        );
                    Console.WriteLine(
                       "\n --- Opponent ---\n" +
                       " Name: " + opponent.Name + "\n" +
                       " Health: " + opponent.Health + "\n" +
                       " Strenght: " + opponent.Strength + "\n" +
                       " Damgage:" + opponent.Damage
                        );
                    Console.ReadKey(true);
                    Console.Clear();

                    while (player.Health > 0 && opponent.Health > 0)
                    {

                        dice.RollDice();
                        int playerRoll = dice.diceRoll;
                        dice.RollDice();
                        int opponentRoll = dice.diceRoll;
                        Console.WriteLine("Rolls:\n" + player.Name + " " + playerRoll + " vs " + opponent.Name + " " + opponentRoll);
                        Console.WriteLine(
                               "\n\n" +
                               player.Name + ": " + player.Strength + " + " + playerRoll + "\n" +
                               opponent.Name + ": " + opponent.Strength + " + " + opponentRoll
                               );
                        Console.ReadKey(true);
                        if (player.Strength > opponent.Strength)
                        {
                            Console.WriteLine("\n--------------------");
                            Console.WriteLine(player.Name + " attack " + opponent.Name + ", " + opponent.Name + " takes " + player.Damage + " damage!");
                            opponent.Health = opponent.Health - player.Damage;
                            Console.WriteLine(opponent.Name + " " + opponent.Health);
                            Console.ReadKey(true);
                        }
                        else if (opponent.Strength > player.Strength)
                        {
                            Console.WriteLine("\n--------------------");
                            Console.WriteLine(opponent.Name + " attack " + player.Name + ", " + player.Name + " takes " + opponent.Damage + " damage!");
                            player.Health = player.Health - opponent.Damage;
                            Console.WriteLine(player.Name + " " + player.Health);
                            Console.ReadKey(true);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("You have died.\n Game over.");
                        Console.ReadKey(true);

                    }
                    else if (opponent.Health <= 0)
                    {
                        Console.WriteLine(player.Name + " has defeated " + opponent.Name);
                        Console.ReadKey(true);

                    }
                }
            }

            void Retire()
            {

            }

            Console.Clear();
            Console.WriteLine("Bye!");


            Console.ReadKey(true);
        }
    }
}
