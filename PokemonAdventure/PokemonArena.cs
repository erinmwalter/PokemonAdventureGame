using System;

namespace PokemonAdventure
{
    class PokemonArena
    {
        //properties for the two trainers going to battle in the arena:
        public PokemonTrainer Trainer { get; set; }
        public AutomatedPokemonTrainer Opponent { get; set; }
        public Pokemon ActiveTrainerPokemon { get; set; }
        public Pokemon ActiveOpponentPokemon { get; set; }

        public PokemonArena(PokemonTrainer Trainer, AutomatedPokemonTrainer Opponent)
        {
            this.Trainer = Trainer;
            this.Opponent = Opponent;
            ActiveTrainerPokemon = Trainer.SetActivePokemon();
            ActiveOpponentPokemon = Opponent.SetActivePokemon();
        }

        public void GoToBattle()
        {
            Console.WriteLine($"{Opponent.Name} challenges {Trainer.Name} to a battle!");
            Console.WriteLine($"I choose you, {ActiveTrainerPokemon.Name}!!");
            Helper.Pause("Press any key to begin!");
            while (ActiveTrainerPokemon.HP >= 0 && ActiveOpponentPokemon.HP >=0)
            {
                
                TrainerTurn();
                if (ActiveOpponentPokemon.HP <= 0)
                {
                    //this is set up so if the opponent pokemon dies before 
                    //their turn, game auto ends.
                    break;
                }
                OpponentTurn();
                Console.WriteLine(ActiveTrainerPokemon);
                Console.WriteLine(ActiveOpponentPokemon);

            }
            bool isTrainerWinner = GetWinStatus();
            if (isTrainerWinner)
            {
                int EXPtoGain = ActiveOpponentPokemon.Level * 15;
                ActiveTrainerPokemon.ExperienceNeeded -= EXPtoGain;
                Console.WriteLine($"{ActiveTrainerPokemon.Name} defeats {ActiveOpponentPokemon.Name}!");
                Console.WriteLine($"Gaining {EXPtoGain}EXP points.");

            }
            else
            {
                Console.WriteLine($"{ActiveOpponentPokemon.Name} defeats {ActiveTrainerPokemon.Name}!");
                Console.WriteLine($"You have lost the battle.");
            }

        }

        public bool GetWinStatus()
        {
            if (ActiveTrainerPokemon.HP > ActiveOpponentPokemon.HP)
            {
                return true;
            }
            return false;
        }
        public void TrainerTurn()
        {
            Console.WriteLine($"{Trainer.Name}'s turn:");
            int choice = Helper.GetValidIntInput("[1]Attack [2]Change Pokemon: ", 1, 2);
            switch (choice)
            {
                case 1:
                    AttackSequence(Trainer, ActiveOpponentPokemon);
                    break;
                case 2:
                    Console.WriteLine("to be implemented");
                    break;
            }
        }
        public void OpponentTurn()
        {
            Console.WriteLine($"{Opponent.Name}'s turn");
            AttackSequence(Opponent, ActiveTrainerPokemon);
        }

        public void AttackSequence(AutomatedPokemonTrainer active, Pokemon opponent)
        {

            int damage = active.TakeTurn(ActiveTrainerPokemon, opponent.Type);
            if (damage == 0)
            {
                Console.WriteLine("Attack missed!");
            }
            else
            {
                Console.WriteLine($"Dealing {damage}!");
            }
            DealDamage(damage, opponent);
        }

        public void DealDamage(int damage, Pokemon opponent)
        {
            opponent.HP -= damage;
            if(opponent.HP <= 0)
            {
                Console.WriteLine($"{opponent.Name} has fainted!");
            }
        }
    }

    

    //public Attack ChooseAttack()
    //{
    //    Console.WriteLine("Attacks:");
    //    for(int i=0; i < Trainer.Attacks.Count; )
    //}
    //1) select attack

    //2) get strength
    //3) roll for accuracy
    //4) deal damage if 
}
