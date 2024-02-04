using System;

class Program
{
    static void Main(string[] args)
    {
       BreathingActivity breathingActivity = new BreathingActivity();
       breathingActivity.Run();

       ListingActivity listingActivity = new ListingActivity();
       listingActivity.Run();

       ReflectingActivity reflectingActivity = new ReflectingActivity();
       reflectingActivity.Run();
    }
}