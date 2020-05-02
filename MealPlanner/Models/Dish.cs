using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MealPlanner.Models
{
    public class Dish
    {
        public enum ServingMeasurement { oz = 0, ml = 1 }
        public Dish() { }

        public Dish(string name, Serving servingSize, int calories, int carbohydrates, int protein, int fat, List<string> directions)
        {
            Name = name;
            ServingSize = servingSize;
        }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("serving")]
        public Serving ServingSize { get; set; }

        [JsonRequired]
        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("carbohydrates")]
        public int Carbohydrates { get; set; }

        [JsonProperty("protein")]
        public int Protein { get; set; }

        [JsonProperty("fat")]
        public int Fat { get; set; }

        [JsonProperty("directions")]
        public IList<Step> Directions { get; set; }

        public class Serving
        {
            public Serving() { }
            public Serving(int quantity, ServingMeasurement measurement)
            {
                Quantity = quantity;
                Measurement = measurement;
            }

            [JsonProperty("quantity")]
            public int Quantity { get; set; }

            [JsonProperty("measurement")]
            public ServingMeasurement Measurement { get; set; }
        }

        public class Step
        {
            [JsonProperty("number")]
            public int Number { get; set; }

            [JsonProperty("direction")]
            public string Direction { get; set; }
        }

    }
}
