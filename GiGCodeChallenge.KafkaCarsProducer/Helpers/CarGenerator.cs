using GiGCodeChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiGCodeChallenge.KafkaCarsProducer.Helpers
{
    internal static class CarGenerator
    {
        internal static IKafkaMessage GenerateCar()
        {
            var randomNumber = new Random();
            var car = new Car
            {
                BrandName = GetBrand(randomNumber.Next(1, 21)),
                DoorsNumber = randomNumber.Next(2, 6),
                Model = GetModel(5),
                IsSportsCar = Convert.ToBoolean(randomNumber.Next(0, 2))
            };

            return car;
        }


        private static string GetBrand(int brandId)
        {
            switch (brandId)
            {
                case 1:
                    return "BMW";
                case 2:
                    return "Porsche";
                case 3:
                    return "Bugatti";
                case 4:
                    return "Ferrari";
                case 5:
                    return "Chrysler";
                case 6:
                    return "Mercedes";
                case 7:
                    return "Lamborghini";
                case 8:
                    return "Rover";
                case 9:
                    return "Aston Martin";
                case 10:
                    return "Bentley";
                case 11:
                    return "Renault";
                case 12:
                    return "Alfa Romeo";
                case 13:
                    return "Tesla";
                case 14:
                    return "Fiat";
                case 15:
                    return "Maserati";
                case 16:
                    return "Toyota";
                case 17:
                    return "Volvo";
                case 18:
                    return "Volkswagen";
                case 19:
                    return "Audi";
                case 20:
                    return "Ford";
                default:
                    return "Skoda";
            }
        }

        private static string GetModel(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToUpper();
        }
    }
}
