using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokemonAdventure
{
    class AutomatedPokemonTrainer
    {
        public string Name { get; set; }
        public List<Pokemon> ActivePokemon = new List<Pokemon>();
        public virtual int TrainerLevel => GetAverageLevel();

        //various constructors overloaded differently
        public AutomatedPokemonTrainer()
        {

        }

        public AutomatedPokemonTrainer(string Name)
        {
            this.Name = Name;
            
        }

        public AutomatedPokemonTrainer(string Name, params Pokemon[] active)
        {
            this.Name = Name;
            this.ActivePokemon = active.ToList();
        }

        //method to add a single pokemon to pokedex
        public void AddPokemon(Pokemon pokemon)
        {
            ActivePokemon.Add(pokemon);
        }

        //overloaded add pokemon to add multiple pokemon to pokedex
        public virtual void AddPokemon(params Pokemon[] pokemon)
        {
            foreach (Pokemon p in pokemon)
            {
                ActivePokemon.Add(p);
            }
        }

        //sets average level of trainer by looking at all levels of current pokemon
        //and taking the average of those. used when determining levels of wild pokemon
        public virtual int GetAverageLevel()
        {
            int sum = 0;
            if (ActivePokemon.Count == 0)
            {
                return 1;
            }
            else
            {
                foreach (Pokemon pokemon in ActivePokemon)
                {
                    sum += pokemon.Level;
                }
                return sum / ActivePokemon.Count;
            }
        }

        public virtual Pokemon SetActivePokemon()
        {
            int random = Helper.GenerateRandom(0, ActivePokemon.Count);
            return ActivePokemon[random];
        }

        public virtual int TakeTurn(Pokemon pokemon, Type opponentType)
        {
            Attack chosenAttack = GetAttack(pokemon);
            int damage = pokemon.CalculateDamage(chosenAttack, opponentType) * pokemon.Level;
            if (chosenAttack.IsSuccessful)
            {
                return damage;
            }
            else
            {
                return 0;
            }
        }

        public virtual Attack GetAttack(Pokemon pokemon)
        {
            int choice = Helper.GenerateRandom(0, pokemon.Attacks.Count);

            return pokemon.Attacks[choice];
        }


        
    }
}
