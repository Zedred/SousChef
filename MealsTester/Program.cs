using System;
using MealLib;
using CommandLine;

namespace MealsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            MealCSVReader csvReader = new MealCSVReader();
            Console.WriteLine("Meal Testing CLI");

            Parser.Default.ParseArguments<Options>(args)
                          .WithParsed<Options>(o =>
                          {
                              Console.WriteLine("Reading " + o.MealsFile);
                              csvReader.ReadDishesFile(o.MealsFile);
                          });
        }

        public class Options
        {
            [Option('f', "file", Required = true, HelpText = "Location of meals spreadsheet")]
            public string MealsFile { get; set; }
        }


    }
}
