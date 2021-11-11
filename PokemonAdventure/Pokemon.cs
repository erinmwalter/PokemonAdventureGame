using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventure
{
    class Pokemon
    {
        public string Name { get; set; } 
        public Type Type { get; set; }
        public int Level { get; set; }
        public int ExperienceNeeded => Level * 100;
        public int HP => Level * 10;
        public List<Attack> Attacks { get; set; } = new List<Attack>();

        public Pokemon(string Name, Type Type, int Level)
        {
            this.Name = Name;
            this.Type = Type;
            this.Level = Level;
            Attacks.Add(new Attack("Tackle", Type.Normal));
        }

        public void SetAttacks(List<Attack> attacks)
        {
            Attacks = attacks;
        }


        public override string ToString()
        {
            return $"{Name}, Type: {Type}, Level: {Level}, HP:{HP}, EXP needed to Level up: {ExperienceNeeded}";
        }
    }
}
