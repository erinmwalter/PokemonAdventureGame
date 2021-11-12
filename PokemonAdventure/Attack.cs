using System.Collections.Generic;

namespace PokemonAdventure
{
    class Attack
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public List<Type> Strengths { get; set; } = new List<Type>();
        public List<Type> Weaknesses { get; set; } = new List<Type>();
        public double Accuracy { get; set; } = 0.5;

        public bool IsSuccessful => UpdateIsSuccessful();

        public Attack(string Name, Type Type)
        {
            this.Name = Name;
            this.Type = Type;
            Strengths = PokemonDatabase.GetStrengths(this.Type);
            Weaknesses = PokemonDatabase.GetWeaknesses(this.Type);
        }

        public bool UpdateIsSuccessful()
        {
            int minForSuccess = (int)(Accuracy * 10);
            int random = Helper.GenerateRandom(1, 11);
            if (random <= minForSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public override string ToString()
        {
            string output = "";
            output += $"Attack: {Name}, Type: {Type}\n   Super effective against: ";
            foreach (Type type in Strengths)
            {
                output += $"{type}  ";
            }
            if (Strengths.Count == 0)
            {
                output += "None";
            }
            output += "\n   Weak against: ";
            foreach (Type type in Weaknesses)
            {
                output += $"{type}  ";
            }
            if (Weaknesses.Count == 0)
            {
                output += "None";
            }
            output += $"\n   Accuracy: {Accuracy * 100}%\n";
            return output;
        }

        public double GetEffectiveness(Type opponentType)
        {
            if (Strengths.Contains(opponentType))
            {
                return 2;
            }
            else if (Weaknesses.Contains(opponentType))
            {
                return 0.5;
            }
            else
            {
                return 1;
            }
        }


    }
}
