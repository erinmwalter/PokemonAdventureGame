using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventure
{
     class Game
    {
        PokemonTrainer Trainer { get; set; }
        public void StartNewGame()
        {
            Console.WriteLine("Your adventure begins...");
            SetTrainer();
            Helper.Pause("Press any key to begin!");
            GamePlay();
        }

        public void SetTrainer()
        {
            Console.WriteLine("First, Choose your trainer:");
            DisplayTrainers();
            int choice = Helper.GetValidIntInput("Make your Selection: ", 0, PresetTrainers.PresetTrainerList.Count - 1);
            Trainer = PresetTrainers.PresetTrainerList[choice];
            Console.WriteLine($"Congratulations, you selected {Trainer.Name}");

        }

        public void DisplayTrainers()
        {
            for(int i = 0; i < PresetTrainers.PresetTrainerList.Count; i++)
            {
                Console.WriteLine($"{i}: {PresetTrainers.PresetTrainerList[i].Name}");
            }
        }

        public void GamePlay()
        {
            bool goOn = true;
            while (goOn)
            {
                GameMenu();
                string choice = Helper.GetInput("Enter your selection: ");
                switch (choice)
                {
                    case "1":
                        //catch wild pokemon
                        Trainer.CatchNewPokemon();
                        break;
                    case "2":
                        //pick pokemon to train and battle rando pokemon
                        Console.WriteLine("Pokemon Traiing functionality comming soon");
                        break;
                    case "3":
                        Trainer.ViewPokedex();
                        break;
                    case "4":
                        //remove pokemon from pokedex
                        Trainer.ReleasePokemon();
                        break;
                    case "5":
                        //gym battle
                        Console.WriteLine("Gym Battle Functionality Coming Soon.");
                        break;
                    case "6":
                        goOn = Helper.Continue("Are you sure you want to quit?");
                        break;

                }
            }
            Console.WriteLine("Game Ended. Returning to main menu...");

        }

        public void GameMenu()
        {
            Console.WriteLine($"Welcome, {Trainer.Name}. ");
            Console.WriteLine("1. Catch Wild Pokemon");
            Console.WriteLine("2. Train Pokemon");
            Console.WriteLine("3. View All Pokemon");
            Console.WriteLine("4. Release Pokemon");
            Console.WriteLine("5. Battle Next Gym Leader");
            Console.WriteLine("6. Quit Game --Warning Save Game functionality not available yet.");
        }


    }
}
