using System;

class Program
{
    static void Main(string[] args)
    {
        // 1# Ask the user for the magic number
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generates a number between 1 and 100

        // 2# Add a loop to keep playing until the user guesses correctly
        bool guessedCorrectly = false;

        while (!guessedCorrectly)
        {
            // 3# Ask the user for a guess
            Console.Write("What is your guess? ");
            int userGuess = int.Parse(Console.ReadLine());

            //  Check if the guess is higher, lower, or correct
            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                guessedCorrectly = true;
            }
        }
    }
}


