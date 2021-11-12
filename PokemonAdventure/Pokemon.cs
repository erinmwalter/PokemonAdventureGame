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
        public int ExperienceNeeded { get; set; }
        public int HP { get; set; }
        public List<Attack> Attacks { get; set; } = new List<Attack>();

        public Pokemon(string Name, Type Type, int Level)
        {
            this.Name = Name;
            this.Type = Type;
            this.Level = Level;
            HP = Level * 10;
            ExperienceNeeded = Level * 100;
            Attacks.Add(new Attack("Tackle", Type.Normal));
        }

        //gets one or more attacks and adds to pokemon's list of attacks
        //used in child class as override to auto set attack list for opponent
        public virtual void SetAttacks(params Attack[] attacks)
        {
            foreach (Attack attack in attacks)
            {
                if (attack.Type == Type || attack.Type == Type.Normal)
                {
                    Attacks.Add(attack);
                    Console.WriteLine($"Taught {Name} {attack.Name}!");
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
                        Attack newAttack = SetNewAttack();
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

        //gets name of attack from user and auto-adds type matching pokemon's type
        // to Attacks list
        public Attack SetNewAttack()
        {
            string name = Helper.GetInput("Enter name of attack: ");
            Attack newAttack = new Attack(name, Type);
            return newAttack;
        }

        //displays main menu for individual pokemon functionality
        public void DisplayMenu()
        {
            Console.WriteLine($"You have selected {Name}");
            Console.WriteLine("1. See Current stats");
            Console.WriteLine("2. Battle wild pokemon");
            Console.WriteLine("3. Teach new Attack");
            Console.WriteLine("4. Return to main menu");
        }

        //displays all stats and attacks for each pokemon
        public void DisplayAllStats()
        {
            Console.WriteLine(ToString());
            foreach(Attack attack in Attacks)
            {
                Console.WriteLine(attack);
            }
        }

        public int CalculateDamage(Attack attack, Type opponentType)
        {
            int damage = Level / 5;
            double effectiveness = attack.GetEffectiveness(opponentType);
            damage = (int)(effectiveness * damage);
            return damage;
            //just telling it that the base damage is 1/5 of the trainer's level 
            
        }
        //override of tostring for displaying pokemon information
        public override string ToString()
        {
            return $"{Name}, Type: {Type}, Level: {Level}, HP:{HP}, EXP needed to Level up: {ExperienceNeeded}";
        }
    }
}
