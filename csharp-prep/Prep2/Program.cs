/*
Assignment: Write a program that determines the letter grade for a course according to the following scale:

A >= 90
B >= 80
C >= 70
D >= 60
F < 60

*/ 
using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for input (core requirement *)
        Console.WriteLine("Enter your grade percentage: "); 
        string studentInput = Console.ReadLine();
        
        int grade;
        string letter; // Variable to store the letter grade (core requirement *)

        // Check if the input is a valid integer (stretch challenge **)
        if (int.TryParse(studentInput, out grade)) 
        {
            // Determine letter grade (core requirement *)
            if ( grade >= 90)
            {
                if (grade == 100)
                {
                    letter = "A+";
                }
                else
                {
                    letter = "A";
                }
            }
            else if ( grade >= 80)
            {
                letter = "B";
            }
            else if ( grade >= 70)
            {
                letter = "C";
            }
            else if ( grade >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Determine the sign (+, -, or none) (stretch challenge **)
            string sign = "";
            if (letter != "F")
            {
                int lastDigit = grade % 10;
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit <= 3)
                {
                    sign = "-";
                }
            }

            // Print the determined letter grade (core requirement *)
            Console.WriteLine($"Your grande is {letter}{sign}");

            // Check if the user have at least a 70 to pass (core requirement *)
            if (grade >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course!");
            }
            else
            {
                Console.WriteLine("Don't give up! You can try again next time.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for grade percentage.");
        }
    }
}