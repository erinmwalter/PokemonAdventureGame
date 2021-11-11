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

        //gets one or more attacks and adds to pokemon's list of attacks
        public void SetAttacks(params Attack[] attacks)
        {
            foreach (Attack attack in attacks)
            {
                if (attack.Type == Type || attack.Type == Type.Normal)
                {
                    Attacks.Add(attack);
                    Console.WriteLine($"Taught {Name} {attack}!");
                }
                else
                {
                    Console.WriteLine($"Unable to teach {Name} {attack.Name}. Attack type must be {Type} or Normal type.");
                }
            }
        }

        //main driver of pokemon menu that will allow users to choose to train, or upgrade pokemon
        public void PokemonMenu()
        {
            bool goOn = true;
            while (goOn)
            {
                DisplayMenu();
                string choice = Helper.GetInput("Make a selection: ");
                switch (choice)
                {
                    case "1":
                        DisplayAllStats();
                        break;
                    case "2":
                        Console.WriteLine("Battle functionality will be available in future.");
                        break;
                    case "3":
                        Attack newAttack = GetAttack();
                        SetAttacks(newAttack);
                        break;
                    case "4":
                        goOn = false;
                        Console.WriteLine("Returning to main menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid selection, try again...");
                        break;
                }
            }
        }

        public Attack GetAttack()
        {
            string name = Helper.GetInput("Enter name of attack: ");
            Attack newAttack = new Attack(name, Type);
            return newAttack;
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"You have selected {Name}");
            Console.WriteLine("1. See Current stats");
            Console.WriteLine("2. Battle wild pokemon");
            Console.WriteLine("3. Teach new Attack");
            Console.WriteLine("4. Return to main menu");
        }

        public void DisplayAllStats()
        {
            Console.WriteLine(ToString());
            foreach(Attack attack in Attacks)
            {
                Console.WriteLine(attack);
            }
        }
        //override of tostring for displaying pokemon information
        public override string ToString()
        {
            return $"{Name}, Type: {Type}, Level: {Level}, HP:{HP}, EXP needed to Level up: {ExperienceNeeded}";
        }
    }
}
