using System;

namespace guess
{
    class Program
    {
        static void Main(string[] args)
        {

            int NumGuesses = 0;
            int GuessLimit = 10;
            string Input;
            int Guess = 0;
            int Max = 11;
            Random rnd = new Random();
            bool Playing = true;
            
            while(Playing)
            {
                Console.WriteLine("Pick a maximum number to guess between 10 and 1000.");
                string Choice = Console.ReadLine();
                int.TryParse(Choice, out Max);
                if(Max < 10 || Max > 1000)
                {
                    Max = 999999999+1;
                    GuessLimit = 1;
                    Console.WriteLine($"You think this is a GAME!?! Max number is {Max} and the number of guesses is {GuessLimit}");
                }
                GuessLimit = Max/10+2;
                int CompChoice = rnd.Next(1, Max+1);
                NumGuesses = 0;
                

                while( NumGuesses < GuessLimit)
                {
                    bool ValidInput = false;
                    while(!ValidInput)
                    {
                        Console.WriteLine($"Pick a number between 1 and {Max-1}?");
                        Input = Console.ReadLine();
                        int.TryParse(Input, out Guess);
                        if(Guess > 0 && Guess < Max)
                        {
                            ValidInput = true;
                        }
                    }
                    NumGuesses++;
                    
                    if(CompChoice > Guess)
                    {
                        Console.WriteLine($"{Guess} is too low. Try another Number.\nThere are {GuessLimit - NumGuesses} remaining.");
                    }
                    else if(CompChoice < Guess)
                    {
                        Console.WriteLine($"{Guess} is too high. Try another Number.\nThere are {GuessLimit - NumGuesses} remaining.");
                    }
                    else
                    {
                        Console.WriteLine($"{Guess} is the correct answer. \nIt took {NumGuesses} to get it right.");
                        break;
                    }
                }
                bool Valid = false;
                while(!Valid)
                {
                    Console.WriteLine("Do you want to try again? Y/N");
                    string PlayAgain = Console.ReadLine().ToLower();
                    if(PlayAgain == "n" || PlayAgain == "no")
                    {
                        Playing = false;
                        Valid = true;
                    }
                    else if(PlayAgain == "y" || PlayAgain == "yes")
                    {
                        Valid = true;
                    }
                }
            }
        }
    }
}
