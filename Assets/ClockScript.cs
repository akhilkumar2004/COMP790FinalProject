using System;

class Program
{
    static void Main()
    {
        // Get the current time
        DateTime now = DateTime.Now;

        // Check if the current time is exactly 17:00:00
        if (now.ToString("HH:mm:ss") == "17:00:00")
        {
            Console.WriteLine("CLOSED!");
        }
        else
        {
            // Print the current time
            string currentTime = now.ToString("hh:mm:ss");
            Console.WriteLine("Current time- " + currentTime);
        }
    }
}