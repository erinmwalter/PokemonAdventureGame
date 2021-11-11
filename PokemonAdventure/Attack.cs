using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventure
{
    class Attack
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public List<Type> Strengths { get; set; } = new List<Type>();
        public List<Type> Weaknesses { get; set; } = new List<Type>();
        public double Accuracy { get; set; } = 0.5;

        public bool IsSuccessful { get; set; } = true;

        public Attack(string Name, Type Type)
        {
            this.Name = Name;
            this.Type = Type;
            Strengths = PokemonDatabase.GetStrengths(this.Type);
            Weaknesses = PokemonDatabase.GetWeaknesses(this.Type);
        }

       
    }
}
