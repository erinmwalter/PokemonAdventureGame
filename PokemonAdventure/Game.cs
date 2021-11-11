using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventure
{
    //this class houses the main game functionality
    //player will select a trainer, and catch pokemon, train pokemon, and battle gym leaders
     class Game
    {
        //property for the game's trainer to be housed once selected
        PokemonTrainer Trainer { get; set; }

        //initializes the new game by setting trainer and starting main game play.
        public void StartNewGame()
        {
            Console.WriteLine("Your adventure begins...");
            SetTrainer();
            Helper.Pause("Press any key to begin!");
            Console.Clear();
            GamePlay();
        }

        //lets user choose trainer from preset list or create custom trainer
        public void SetTrainer()
        {
            Console.WriteLine("First, Choose your trainer:");
            DisplayTrainers();
            int choice = Helper.GetValidIntInput("Make your Selection: ", 0, PresetTrainers.PresetTrainerList.Count - 1);
            Trainer = PresetTrainers.PresetTrainerList[choice];
            //if user chooses custom then overwrites preset name of "create your own" to name of their choice.
            if(Trainer.Name == "Create Your Own")
            {
                string name = Helper.GetInput("Enter Trainer Name: ");
                Trainer.Name = name;
            }
            Console.WriteLine($"Congratulations, you selected {Trainer.Name}");

        }

        //allows user to see list of all trainers available to pick from
        public void DisplayTrainers()
        {
            for(int i = 0; i < PresetTrainers.PresetTrainerList.Count; i++)
            {
                Console.WriteLine($"{i}: {PresetTrainers.PresetTrainerList[i].Name}");
            }
        }

        //main game play method that drives game forward. 
        public void GamePlay()
        {
            bool endGame = false;
            while (!endGame)
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
                        Trainer.TrainPokemon();
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
                        endGame = Helper.Continue("Are you sure you want to quit?");
                        break;

                }
            }
            Console.WriteLine("Game Ended. Returning to main menu...");

        }

        //main game menu that allows user to choose next thing they want to do
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
