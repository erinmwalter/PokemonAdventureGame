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
            while (true)
            {
                GameMenu();
                string choice = Helper.GetInput("Enter your selection: ");
                switch (choice)
                {
                    case "1":
                        //catch wild pokemon
                        break;
                    case "2":
                        //pick pokemon to train and battle rando pokemon
                        break;
                    case "3":

                }
            }
        }

        public void GameMenu()
        {
            Console.WriteLine($"Welcome, {Trainer.Name}. ");
            Console.WriteLine("1. Catch Wild Pokemon");
            Console.WriteLine("2. Train Pokemon");
            Console.WriteLine("3. View All Pokemon");
            Console.WriteLine("4. Release Pokemon");
            Console.WriteLine("5. Battle Next Gym Leader");
        }


    }
}
