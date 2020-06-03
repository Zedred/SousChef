using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace SousChef.DataAccess
{
    public class MealCSVReader : IDisposable
    {
        public MealCSVReader() : base() { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void ReadDishesFile(string FilePath, ref SortedDictionary<string, string> DishDictionary)
        {
            using(TextReader reader = new StreamReader(FilePath))
            {
                using(CsvReader dishReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var dishes = dishReader.GetRecords<string>();
                    
                    foreach(var dish in dishes)
                    {
                        DishDictionary.Add(dish, dish);
                    }
                }
            }
        }
    }
}
