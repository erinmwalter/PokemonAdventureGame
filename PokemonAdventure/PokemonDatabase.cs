using System.Collections.Generic;

namespace PokemonAdventure
{
    class PokemonDatabase
    {
        public static Pokemon GetPokemon(int level)
        {
            List<Pokemon> wildPokemonDatabase = DatabaseBuilder();

            int randomNum = Helper.GenerateRandom(0, wildPokemonDatabase.Count);
            Pokemon chosen = wildPokemonDatabase[randomNum];
            chosen.Level = level;
            //gets random number from 0-count of database and returns random pokemon.
            //gets a level of the trainer to return the pokemon at that level.
            return chosen;
        }

        public static List<Pokemon> DatabaseBuilder()
        {
            List<Pokemon> pokemonDatabase = new List<Pokemon>();

            pokemonDatabase.Add(new Pokemon("Caterpie", Type.Bug, 5));
            pokemonDatabase.Add(new Pokemon("Weedle", Type.Bug, 5));
            pokemonDatabase.Add(new Pokemon("Bulbasaur", Type.Grass, 5));
            pokemonDatabase.Add(new Pokemon("Bellsprout", Type.Grass, 5));
            pokemonDatabase.Add(new Pokemon("Dratini", Type.Dragon, 5));
            pokemonDatabase.Add(new Pokemon("Pikachu", Type.Electric, 5));
            pokemonDatabase.Add(new Pokemon("Magnemite", Type.Electric, 5));
            pokemonDatabase.Add(new Pokemon("Mankey", Type.Fighting, 5));
            pokemonDatabase.Add(new Pokemon("Machop", Type.Fighting, 5));
            pokemonDatabase.Add(new Pokemon("Charmander", Type.Fire, 5));
            pokemonDatabase.Add(new Pokemon("Growlithe", Type.Fire, 5));
            pokemonDatabase.Add(new Pokemon("Gastly", Type.Ghost, 5));
            pokemonDatabase.Add(new Pokemon("Sandshrew", Type.Ground, 5));
            pokemonDatabase.Add(new Pokemon("Diglett", Type.Ground, 5));
            pokemonDatabase.Add(new Pokemon("Articuno", Type.Ice, 5));
            pokemonDatabase.Add(new Pokemon("Rattata", Type.Normal, 5));
            pokemonDatabase.Add(new Pokemon("Snorlax", Type.Normal, 5));
            pokemonDatabase.Add(new Pokemon("Nidoran", Type.Poison, 5));
            pokemonDatabase.Add(new Pokemon("Koffing", Type.Poison, 5));
            pokemonDatabase.Add(new Pokemon("Abra", Type.Psychic, 5));
            pokemonDatabase.Add(new Pokemon("Drowzee", Type.Psychic, 5));
            pokemonDatabase.Add(new Pokemon("Geodude", Type.Rock, 5));
            pokemonDatabase.Add(new Pokemon("Onix", Type.Rock, 5));
            pokemonDatabase.Add(new Pokemon("Onix", Type.Rock, 5));
            pokemonDatabase.Add(new Pokemon("Squirtle", Type.Water, 5));
            pokemonDatabase.Add(new Pokemon("Poliwag", Type.Water, 5));

            return pokemonDatabase;

        }

        public static List<Type> GetWeaknesses(Type type)
        {
            List<Type> attackWeaknesses;
            switch (type)
            {
                case Type.Fire:
                    attackWeaknesses = new List<Type> { Type.Fire, Type.Water, Type.Rock, Type.Dragon };
                    return attackWeaknesses;
                case Type.Water:
                    attackWeaknesses = new List<Type> { Type.Water, Type.Grass, Type.Dragon };
                    return attackWeaknesses;
                case Type.Electric:
                    attackWeaknesses = new List<Type> { Type.Electric, Type.Grass, Type.Dragon, Type.Ground };
                    return attackWeaknesses;
                case Type.Grass:
                    attackWeaknesses = new List<Type> { Type.Fire, Type.Grass, Type.Poison, Type.Flying, Type.Bug, Type.Dragon };
                    return attackWeaknesses;
                case Type.Ice:
                    attackWeaknesses = new List<Type> { Type.Water, Type.Ice, Type.Dragon };
                    return attackWeaknesses;
                case Type.Fighting:
                    attackWeaknesses = new List<Type> { Type.Poison, Type.Flying, Type.Psychic, Type.Bug, Type.Ghost};
                    return attackWeaknesses;
                case Type.Poison:
                    attackWeaknesses = new List<Type> { Type.Poison, Type.Ground, Type.Rock, Type.Ghost };
                    return attackWeaknesses;
                case Type.Ground:
                    attackWeaknesses = new List<Type> { Type.Grass, Type.Flying, Type.Bug };
                    return attackWeaknesses;
                case Type.Flying:
                    attackWeaknesses = new List<Type> { Type.Electric, Type.Rock};
                    return attackWeaknesses;
                case Type.Psychic:
                    attackWeaknesses = new List<Type> { Type.Psychic };
                    return attackWeaknesses;
                case Type.Bug:
                    attackWeaknesses = new List<Type> { Type.Fire, Type.Fighting, Type.Flying, Type.Rock };
                    return attackWeaknesses;
                case Type.Rock:
                    attackWeaknesses = new List<Type> { Type.Fighting, Type.Ground };
                    return attackWeaknesses;
                case Type.Normal:
                    attackWeaknesses = new List<Type> { Type.Rock, Type.Ghost };
                    return attackWeaknesses;
                default:
                    //ghost and dragon have no weakneses
                    attackWeaknesses = new List<Type>();
                    return attackWeaknesses;
            }


        }

        public static List<Type> GetStrengths(Type type)
        {
            List<Type> attackStrengths;
            switch (type)
            {
                case Type.Fire:
                    attackStrengths = new List<Type> { Type.Grass, Type.Ice, Type.Bug };
                    return attackStrengths;
                case Type.Water:
                    attackStrengths = new List<Type> { Type.Fire, Type.Ground, Type.Rock };
                    return attackStrengths;
                case Type.Electric:
                    attackStrengths = new List<Type> { Type.Water, Type.Flying };
                    return attackStrengths;
                case Type.Grass:
                    attackStrengths = new List<Type> { Type.Water, Type.Ground, Type.Rock };
                    return attackStrengths;
                case Type.Ice:
                    attackStrengths = new List<Type> { Type.Grass, Type.Flying, Type.Dragon };
                    return attackStrengths;
                case Type.Fighting:
                    attackStrengths = new List<Type> { Type.Normal, Type.Ice, Type.Rock };
                    return attackStrengths;
                case Type.Poison:
                    attackStrengths = new List<Type> { Type.Grass, Type.Bug };
                    return attackStrengths;
                case Type.Ground:
                    attackStrengths = new List<Type> { Type.Fire, Type.Electric, Type.Poison, Type.Rock };
                    return attackStrengths;
                case Type.Flying:
                    attackStrengths = new List<Type> {Type.Grass, Type.Poison, Type.Bug,};
                    return attackStrengths;
                case Type.Psychic:
                    attackStrengths = new List<Type> { Type.Fighting, Type.Poison };
                    return attackStrengths;
                case Type.Bug:
                    attackStrengths = new List<Type> { Type.Grass, Type.Poison, Type.Psychic };
                    return attackStrengths;
                case Type.Rock:
                    attackStrengths = new List<Type> { Type.Fire, Type.Ice, Type.Flying, Type.Bug };
                    return attackStrengths;
                case Type.Ghost:
                    attackStrengths = new List<Type> { Type.Ghost };
                    return attackStrengths;
                case Type.Dragon:
                    attackStrengths = new List<Type> { Type.Dragon };
                    return attackStrengths;
                default:
                    //defaulting to "normal type" for now
                    attackStrengths = new List<Type>();
                    return attackStrengths;
            }
        }
    }
}
