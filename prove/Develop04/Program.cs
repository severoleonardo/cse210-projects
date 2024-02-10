// For exceeding requirements I added another kind of activity: 
// The MeditationActivity class represents an activity focused on guiding the user through a calming meditation experience.
// It inherits from the Activity class beucase it shares common behavior with other activities in the program, such as Breathing Activity.
// I also added comments to the code to explain the purpose of each method and the logic behind it.

using System;
using System.Collections.Generic;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        { 
            Console.WriteLine("\nWelcome to your Mindfulness App!"); // Display welcome message
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Listing Activity");
            Console.WriteLine("  3. Reflecting Activity");
            Console.WriteLine("  4. Meditation Activity");
            Console.WriteLine("  5. Exit");

            Console.Write("Enter the number of the activity you would like to do: ");
            string choice = Console.ReadLine(); // Get user choice

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity(); // Create instance of BreathingActivity
                    breathingActivity.Run(); // Run BreathingActivity
                    break;
                case "2":
                    ListingActivity listingActivity = new ListingActivity(); // Create instance of ListingActivity
                    listingActivity.Run(); // Run ListingActivity
                    break;
                case "3":
                    ReflectingActivity reflectingActivity = new ReflectingActivity(); // Create instance of ReflectingActivity
                    reflectingActivity.Run(); // Run ReflectingActivity
                    break;
                case "4":
                    MeditationActivity meditationActivity = new MeditationActivity(); // Create instance of MeditationActivity
                    meditationActivity.Run(); // Run MeditationActivity
                    break;
                case "5":
                    Console.WriteLine("\nExiting the program. Please wait...");
                    DelayedExit(5); // Delayed exit with a farewell message
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                    break;
            }
        }
    } 

    static void DelayedExit(int seconds)
    {
        Console.WriteLine("Thank you for using the Mundfulness Program. See you next time!"); // Display farewell message
        Thread.Sleep(seconds * 1000); // Convert seconds to milliseconds
        Environment.Exit(0); // Exit the program
    }
}