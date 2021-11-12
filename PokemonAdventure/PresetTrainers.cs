using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventure
{
    //these are a collection of preset trainers that the user can choose from if they do not wish to build their own character. 
    //will also implement a "choose random trainer" feature in the future to randomly select  between these preset trainers. 
    class PresetTrainers
    {
        public static List<PokemonTrainer> PresetTrainerList = InitializeTrainerList();

        //Initializes the above list of pokemon trainers that are built below.
        public static List<PokemonTrainer> InitializeTrainerList()
        {
            List<PokemonTrainer> trainers = new List<PokemonTrainer>();
            trainers.Add(AshKetchum());
            trainers.Add(RivalGary());
            trainers.Add(BugCatcher());
            trainers.Add(Sailor());
            trainers.Add(CustomTrainer());

            return trainers;
        }

        //ash ketchum the hero of pokemon!
        public static PokemonTrainer AshKetchum()
        {
            //builds a preset character that a user can choose to play
            PokemonTrainer ash = new PokemonTrainer("Ash");
            Pokemon pikachu = new Pokemon("Pikachu", Type.Electric, 5);
            Pokemon bulbasaur = new Pokemon("Bulbasaur", Type.Grass, 5);
            Pokemon charmander = new Pokemon("Charmander", Type.Fire, 5);
            Pokemon squirtle = new Pokemon("Squirtle", Type.Water, 5);
            ash.AddPokemon(pikachu, bulbasaur, charmander, squirtle);

            return ash;
        }

        //Gary, the jerk rival of Ash
        public static PokemonTrainer RivalGary()
        {
            PokemonTrainer rival = new PokemonTrainer("Gary");
            Pokemon pidgeotto = new Pokemon("Pidgeotto", Type.Flying, 5);
            Pokemon abra = new Pokemon("Abra", Type.Psychic, 5);
            Pokemon rattata = new Pokemon("Rattata", Type.Normal, 5);
            Pokemon wartortle = new Pokemon("Wartortle", Type.Normal, 7);
            rival.AddPokemon(pidgeotto, abra, rattata, wartortle);

            return rival;
        }

        //random bug catcher type trainer for anyone who likes bug pokemon
        public static PokemonTrainer BugCatcher()
        {
            PokemonTrainer bugCatcher = new PokemonTrainer("Bug Catcher");
            Pokemon weedle =new Pokemon("Weedle", Type.Bug, 5);
            Pokemon caterpie = new Pokemon("Caterpie", Type.Bug, 5);
            Pokemon nidoran = new Pokemon("Nidoran", Type.Poison, 5);
            bugCatcher.AddPokemon(weedle, caterpie, nidoran);

            return bugCatcher;
        }

        //water loving trainer may select this Sailor trainer
        public static PokemonTrainer Sailor()
        {
            PokemonTrainer sailor = new PokemonTrainer("Sailor");
            Pokemon horsea = new Pokemon("Horsea", Type.Water, 5);
            Pokemon shellder = new Pokemon("Shellder", Type.Water, 5);
            Pokemon tentacool = new Pokemon("Tentacool", Type.Water, 5);
            sailor.AddPokemon(horsea, shellder, tentacool);

            return sailor;
        }

        //If the player wants to create their own trainer, this will
        //generate three random pokemon for them to start out with.
        public static PokemonTrainer CustomTrainer()
        {
            
            PokemonTrainer custom = new PokemonTrainer("Create Your Own");
            Pokemon randomA = PokemonDatabase.GetPokemon(5);
            Pokemon randomB = PokemonDatabase.GetPokemon(5);
            Pokemon randomC = PokemonDatabase.GetPokemon(5);
            custom.AddPokemon(randomA, randomB, randomC);

            return custom;

        }

        //water loving trainer may select this Sailor trainer
        public static AutomatedPokemonTrainer AutoSailor()
        {
            AutomatedPokemonTrainer sailor = new AutomatedPokemonTrainer("Sailor");
            Pokemon horsea = new Pokemon("Horsea", Type.Water, 5);
            Pokemon shellder = new Pokemon("Shellder", Type.Water, 5);
            Pokemon tentacool = new Pokemon("Tentacool", Type.Water, 5);
            sailor.AddPokemon(horsea, shellder, tentacool);

            return sailor;
        }

    }
}
