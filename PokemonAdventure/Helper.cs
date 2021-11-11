using System;
using System.Collections.Generic;
using System.Text;

//this class contains a number of helper methods to help with getting and validating method as well as
//a couple other methods that are commonly used throughout the program

namespace PokemonAdventure
{
    class Helper
    {
        //returns a string of input to user. no validation included
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        //allows user to enter y or no and returns a bool according to user's answer
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

        //generates a random number betwen [min, max) . 
        public static int GenerateRandom(int min, int max)
        {
            Random rand = new Random();
            int randomNum = rand.Next(min, max);

            return randomNum;
        }

        //gets int value as well as validates that the input is good by taking in a min and max value
        //for the range that the int can be in
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

        //simple pause method to pause the UI during the game
        //user can pass in whatever method and will need user to press any key to continue game forward.
        public static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
