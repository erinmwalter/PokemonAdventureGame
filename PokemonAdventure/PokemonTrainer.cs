using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonAdventure
{
    class PokemonTrainer
    {
        public string Name { get; set; }
        public List<Pokemon> Pokedex { get; set; } = new List<Pokemon>();

        public int TrainerLevel => GetAverageLevel();

        public PokemonTrainer(string Name)
        {
            this.Name = Name;
        }

        public PokemonTrainer(string Name, params Pokemon[] Pokedex)
        {
            this.Name = Name;
            this.Pokedex = Pokedex.ToList();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokedex.Add(pokemon);
        }

        public int GetAverageLevel()
        {
            int sum = 0;
            if (Pokedex.Count == 0)
            {
                return 1;
            }
            else
            {
                foreach(Pokemon pokemon in Pokedex)
                {
                    sum += pokemon.Level;
                }
                return sum / Pokedex.Count;
            }
        }
        //public Pokemon GeneratehWildPokemon()
        //{
        //    Pokemon wildPokemon = PokemonList.GetRandomPokemon(TrainerLevel);
        //}

        public void RemovePokemon(Pokemon pokemon)
        {
            foreach(Pokemon p in Pokedex)
            {
                if (p == pokemon)
                {
                    Pokedex.Remove(p);
                    Console.WriteLine($"Successfully released {p.Name} to the wild");
                    return;
                }
            }
            Console.WriteLine($"Could not locate {pokemon.Name} in Pokedex. Unable to relese.");
        }

        public void AddPokemon(params Pokemon[] pokemon)
        {
            foreach (Pokemon p in pokemon)
            {
                Pokedex.Add(p);
            }
        }

        public void ViewPokedex()
        {
            Console.WriteLine($"{Name}'s Pokedex: ");
            for (int i = 0; i < Pokedex.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Pokedex[i]}");
            }
        }
    }
}
