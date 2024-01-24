using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Ask the user for numbers and append them to the list until 0 is entered
        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
                break;

            numbers.Add(input);
        }

        // 1# Compute the sum of the numbers in the list
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // 2# Compute the average of the numbers in the list
        double average = (double)sum / numbers.Count;

        // 3# Find the maximum number in the list
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
                max = num;
        }

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
