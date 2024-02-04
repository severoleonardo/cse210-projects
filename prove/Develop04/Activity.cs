using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }   

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} - {_description}");
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        PauseForSeconds(3);
    }

    protected virtual void SetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    protected void PrepareToBegin()
    {
         // Additional preparation logic can be added in the derived classes
    }

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed {_name} in {_duration} seconds.");
        PauseForSeconds(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("+");
            Thread.Sleep(500);
            Console.Write("\b \b"); // Erase the + character
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }

    protected void PauseForSeconds(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }
}