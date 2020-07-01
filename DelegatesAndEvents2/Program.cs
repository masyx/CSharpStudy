using System;

namespace DelegatesAndEvents2
{
    //Class that subscribes to an event
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Please enter the threshold number:");
            var conversionSucceeded = int.TryParse(Console.ReadLine(), out int threshold);

            var counter = new Counter();
            if (conversionSucceeded)
                counter.Threshold = threshold;

            // Subscribe to the event
            counter.ThresholdReached += new EventHandler<ThresholdReachedEventArgs>(Counter_ThresholdReached);


            Console.WriteLine("Press 'a' to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("Adding one");
                counter.Add(1);
            }
        }

        // Define what actions to take when the event is raised.
        // This is EVENT HANDLER
        private static void Counter_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"The threshold of {e.Threshold} is reached at {e.TimeReached:F}");
            Environment.Exit(0);
        }
    }
}
