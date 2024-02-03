// Practicing the principle of inheritance by creating a base class and derived classes.
using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Assignment
        Assignment assignment = new Assignment("\nSamuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        // Test MathAssignment
        MathAssignment mathAssignment = new MathAssignment("\nRoberto Rodriguez", "Fractions", "7.3", new string[] { "8-19" });
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetMathHomeworkList());

        // Test WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("\nMary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}