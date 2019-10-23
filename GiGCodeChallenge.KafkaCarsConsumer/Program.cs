using GiGCodeChallenge.Services;
using System;
using System.Threading;

namespace GiGCodeChallenge.KafkaCarsConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to KafkaCarsConsumer Console");
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
                    var c = new KafkaConsumerService(endpoint, string.Format("{0}_group", topic));
                    c.Subscribe(topic);
                    Console.WriteLine("Starting consuming...");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    while (true)
                    {
                        var cancToken = new CancellationTokenSource();
                        try
                        {

                            Console.WriteLine();
                            var m = c.Consume(cancToken);
                            Console.WriteLine(string.Format("Consumed: {0}", m));
                        }
                        catch (OperationCanceledException)
                        {
                            c.Unsubscribe();
                        }
                        catch (Exception ce)
                        {
                            throw ce;
                        }
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
