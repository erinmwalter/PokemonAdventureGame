﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventure
{
    //these are a collection of preset trainers that the user can choose from if they do not wish to build their own character. 
    //will also implement a "choose random trainer" feature in the future to randomly select  between these preset trainers. 
    class PresetTrainers
    {
        public static List<PokemonTrainer> PresetTrainerList = InitializeTrainerList();

        
        public static List<PokemonTrainer> InitializeTrainerList()
        {
            List<PokemonTrainer> trainers = new List<PokemonTrainer>();
            trainers.Add(AshKetchum());
            trainers.Add(RivalGary());
            trainers.Add(BugCatcher());
            trainers.Add(Sailor());

            return trainers;
        }
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

        public static PokemonTrainer BugCatcher()
        {
            PokemonTrainer bugCatcher = new PokemonTrainer("Bug Catcher");
            Pokemon weedle =new Pokemon("Weedle", Type.Bug, 5);
            Pokemon caterpie = new Pokemon("Caterpie", Type.Bug, 5);
            Pokemon nidoran = new Pokemon("Nidoran", Type.Poison, 5);
            bugCatcher.AddPokemon(weedle, caterpie, nidoran);

            return bugCatcher;
        }

        public static PokemonTrainer Sailor()
        {
            PokemonTrainer sailor = new PokemonTrainer("Sailor");
            Pokemon horsea = new Pokemon("Horsea", Type.Water, 5);
            Pokemon shellder = new Pokemon("Shellder", Type.Water, 5);
            Pokemon tentacool = new Pokemon("Tentacool", Type.Water, 5);
            sailor.AddPokemon(horsea, shellder, tentacool);

            return sailor;
        }

       

    }
}