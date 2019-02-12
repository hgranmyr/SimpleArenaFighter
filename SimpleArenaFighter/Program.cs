using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;

namespace SimpleArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Character gladiator = new Character();
            InfoGenerator iGen = new InfoGenerator();
            Battle fight = new Battle();
            Round turn = new Round();

            Console.WriteLine(
                "Welcome to arena fighter!\n" +
                "Enter a name for your gladiator:"
                );


            gladiator.Name = Console.ReadLine();

            Console.WriteLine(
               "Name: " + gladiator.Name + "\n"+
               "Health: " + gladiator.Health + "\n"+
               "Strenght: " + gladiator.Strength + "\n"+
               "Damgage:" + gladiator.Damage
                );

            Console.WriteLine(
                "What do you want to do?\n" +
                "1: Fight\n" +
                "2: Retire"
                );
            int selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    Fight();
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Not a valid selection.");
                    break;
            }
            Console.Clear();
            Console.WriteLine("Bye!");


            Console.ReadKey(true);
        }
    }
}
