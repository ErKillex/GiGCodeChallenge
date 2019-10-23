using GiGCodeChallenge.Domain;
using GiGCodeChallenge.Services;
using System;
using System.Threading;

namespace GiGCodeChallenge.KafkaCarsProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to KafkaCarsProducer Console");
            Console.ForegroundColor = ConsoleColor.Green;

            string endpoint = string.Empty;
            string topic = string.Empty;

            //default use for quickly test 
            //string endpoint = "192.168.99.100:9092";
            //string topic = "cars";

            while (true)
            {
                #region commands
                if (!IsValidEndpoint(endpoint))
                {
                    Console.WriteLine("Write the kafka server endpoint (eg: 192.168.99.100:9092)");
                    endpoint = Console.ReadLine();
                    if (!IsValidEndpoint(endpoint))
                    {
                        Console.WriteLine("Error: invalid endpoint address!");
                        continue;
                    }
                }
                if (string.IsNullOrEmpty(topic))
                {
                    Console.WriteLine("Write the topic name");
                    topic = Console.ReadLine();
                    if (string.IsNullOrEmpty(topic))
                    {
                        Console.WriteLine("Error: invalid topic name!");
                        continue;
                    }
                }
                Console.WriteLine("Press 'Enter' to start or 'Esc' to exit");
                var start = Console.ReadKey();
                if (start.Key == ConsoleKey.Escape)
                    break;
                #endregion
                if (start.Key == ConsoleKey.Enter)
                {
                    var p = new KafkaProducerService(endpoint);
                    Console.WriteLine("Starting producer");
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        //generate a car
                        var car = Helpers.CarGenerator.GenerateCar();
                        var offset = p.SendMessageAsync(topic, car);
                        Console.WriteLine(string.Format("Produced offset: {0} - Car: {1}", offset, car.Message()));
                        Thread.Sleep(500);
                    }
                }
            }
        }

        #region validators
        static bool IsValidEndpoint(string endpoint)
        {
            if (endpoint.Trim().Split(":").Length != 2 && endpoint.Trim().Split(":")[0].Split(".").Length != 4)
                return false;
            return true;
        }
        #endregion
    }
}
