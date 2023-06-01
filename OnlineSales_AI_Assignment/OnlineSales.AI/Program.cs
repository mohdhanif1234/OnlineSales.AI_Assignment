using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSales.AI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            // Input the probabilities
            List<KeyValuePair<string, int>> probs = new List<KeyValuePair<string, int>>()
        {
            new KeyValuePair<string, int>("Head", 35),
            new KeyValuePair<string, int>("Tail", 65)
        };

            // Number of occurrences to simulate
            int numberOfOccurrences = 1000;

            // Simulate the event
            Dictionary<string, int> occurrCnt = SimulateEvent(probs, numberOfOccurrences);

            // Output the results
            Console.WriteLine("Simulation Results:");
            foreach (var outcome in occurrCnt)
            {
                Console.WriteLine("{0} appeared {1} times", outcome.Key, outcome.Value);
            }

            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("Task 2");
            Console.ReadLine();
        }
        static Dictionary<string, int> SimulateEvent(List<KeyValuePair<string, int>> probs, int numberOfOccurrences)
        {
            Dictionary<string, int> occurrCnt = new Dictionary<string, int>();

            // Initialize the occurrence count dictionary
            foreach (var outcome in probs)
            {
                occurrCnt[outcome.Key] = 0;
            }

            // Generate the occurrences based on probabilities
            Random random = new Random();
            for (int i = 0; i < numberOfOccurrences; i++)
            {
                int randomNum = random.Next(1, 101); // Generating a random number between 1 and 100

                int cumProb = 0;
                foreach (var outcome in probs)
                {
                    cumProb += outcome.Value;
                    if (randomNum <= cumProb)
                    {
                        occurrCnt[outcome.Key]++;
                        break;
                    }
                }
            }

            return occurrCnt;
        }
    }     
}
