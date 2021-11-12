using System;
using System.Collections.Generic;

namespace PokemonAdventure
{
    class PokemonTrainer : AutomatedPokemonTrainer
    {

        public List<Pokemon> Pokedex { get; set; } = new List<Pokemon>();

        public override int TrainerLevel => GetAverageLevel();

        public PokemonTrainer(string Name) : base(Name)
        {


        }


        //overloaded add pokemon to add multiple pokemon to pokedex
        public override void AddPokemon(params Pokemon[] pokemon)
        {
            foreach (Pokemon p in pokemon)
            {
                ActivePokemon.Add(p);
            }
        }

        //sets average level of trainer by looking at all levels of current pokemon
        //and taking the average of those. used when determining levels of wild pokemon
        public override int GetAverageLevel()
        {
            int sum = 0;
            if (Pokedex.Count == 0)
            {
                return 1;
            }
            else
            {
                foreach (Pokemon pokemon in Pokedex)
                {
                    sum += pokemon.Level;
                }
                return sum / Pokedex.Count;
            }
        }

        //method for catching new pokemon from wild
        public void CatchNewPokemon()
        {
            Pokemon wildPokemon = PokemonDatabase.GetPokemon(TrainerLevel);
            Console.WriteLine($"A wild {wildPokemon.Name} appeared!");
            Console.WriteLine(wildPokemon);
            int choice = Helper.GetValidIntInput("Would you like to [1]Try to Catch or [2]Run Away: ", 1, 2);
            switch (choice)
            {
                case 1:
                    bool Success = TryToCatch(wildPokemon);
                    if (Success)
                    {
                        Console.WriteLine($"Adding {wildPokemon.Name} to Pokedex!");
                        ActivePokemon.Add(wildPokemon);
                    }
                    break;
                case 2:
                    Console.WriteLine("Got away safely!");
                    break;

            }
        }

        //called while trying to catch pokemon, user currently has 1 in 3 chance to catch
        //pokemon, otherwise it's recursively called to try again, or the pokemon flees
        public bool TryToCatch(Pokemon pokemon)
        {
            int randNumber = Helper.GenerateRandom(1, 4);
            Helper.Pause("Press any key to throw pokeball...");
            if (randNumber == 1)
            {
                Console.WriteLine($"{pokemon.Name} escaped! {pokemon.Name} has fled!");
                return false;
            }
            else if (randNumber == 2)
            {
                Console.WriteLine($"{pokemon.Name} escaped! Try again! ");
                return TryToCatch(pokemon);
            }
            else
            {
                Console.WriteLine($"Success! {pokemon.Name} captured!");
                return true;
            }
        }


        //method to display all pokemon in trainer's current pokedex
        public void ViewPokedex()
        {
            ViewActiveList();
            Console.WriteLine($"{Name}'s Pokedex: ");
            if (Pokedex.Count == 0)
            {
                Console.WriteLine("Nothing in pokedex");
            }
            else
            {
                for (int i = 0; i < Pokedex.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {Pokedex[i]}");
                }
            }
        }

        public void ViewActiveList()
        {
            Console.WriteLine($"{Name}'s Active Pokemon List:");
            for (int i = 0; i < ActivePokemon.Count; i++)
            {
                Console.WriteLine($"{i + 1 }: {ActivePokemon[i]}");
            }
        }

        //method to delete pokemon from pokedex.
        public void ReleasePokemon()
        {
            ViewPokedex();
            int choice = Helper.GetValidIntInput("Choose which pokemon to release: ", 1, Pokedex.Count);
            Pokemon toRemove = Pokedex[choice - 1];
            Pokedex.Remove(toRemove);
            Console.WriteLine($"Successfully released {toRemove.Name} to the wild");

        }

        //method that will let users choose a pokemon from their pokedex
        //and train or battle with that pokemon
        public int ChoosePokemon()
        {
            ViewPokedex();
            int choice = Helper.GetValidIntInput("Choose a pokemon: ", 1, Pokedex.Count);
            return choice;
        }

        //method will take users to main pokemon menu to train, teach attacks, etc.
        public void ViewPokemonInfo()
        {
            int index = ChoosePokemon();
            Pokedex[index - 1].PokemonMenu();
        }

        public override Pokemon SetActivePokemon()
        {
            ViewActiveList();
            int choice = Helper.GetValidIntInput("Select Pokemon for Battle: ", 1, ActivePokemon.Count);

            return ActivePokemon[choice-1];

        }
    }
}
