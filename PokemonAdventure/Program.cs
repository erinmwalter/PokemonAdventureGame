using System;

namespace PokemonAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Welcome to the Pokemon Adventure Game!");
            bool goOn = true;
            while (goOn)
            {
                //displays main menu, lets user choose option of where to go
                DisplayMenu();
                string choice = Helper.GetInput("Make your selection: ");
                switch (choice)
                {
                    case "1":
                        game.StartNewGame();
                        break;
                    case "2":
                        Console.WriteLine("Error: no game to load. Try Again.");
                        break;
                    case "3":
                        Console.WriteLine("Program Exit Selected. Goodbye!");
                        goOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }
            }

        }

        //home menu page display
        public static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Exit");
        }
    }
}
