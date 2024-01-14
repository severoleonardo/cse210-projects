/*
Assignment: Prompt the user for their first name. Then, prompt them for their last name. Display the text back all on one line saying, "Your name is last-name, first-name, last-name"

| What is your first name? Scott
| What is your last name? Burton
|
| Your name is Burton, Scott Burton.

Goal: write a program that asks for your name and repeats it back in this way.
*/ 
using System;

class Program
{
    
    static void Main(string[] args)
    
    {
        Console.WriteLine("What is your first name?");     
        string firstName = Console.ReadLine();
    
        Console.WriteLine("What is your last name?"); 
        string lastName = Console.ReadLine();

        Console.Write($"Your name is {lastName}, {firstName} {lastName}.");
    }
}