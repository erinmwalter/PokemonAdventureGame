using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAdventure
{
    class Helper
    {
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static bool Continue(string prompt)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine().ToLower().Trim();
            if(answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid, enter y or n. Try Again.");
                return Continue(prompt);
            }
        }

        public static int GenerateRandom(int min, int max)
        {
            Random rand = new Random();
            int randomNum = rand.Next(min, max);

            return randomNum;
        }

        public static int GetValidIntInput(string prompt, int min, int max)
        {
            int value;
            
            while(true)
            {
                try
                {
                    Console.Write(prompt);
                    value = int.Parse(Console.ReadLine());
                    if(value >= min && value <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid Input. Value must be between {min} and {max}. Try again.");
                        continue;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter integer value, try again.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Number must be between {min} and {max}");
                    continue;
                }

            }
            return value;
        }

        public static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
